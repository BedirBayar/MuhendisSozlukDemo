using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace MuhendisSozluk.Admin
{
    public partial class Writers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(connectionStrings.bedir);
        static DateTime def_time= DateTime.Parse("2001 - 01 - 01 00:00:00.000");
        static String name_unchanged;
        static int seniority;
        static string session;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                object user = Session["username"];
                if (user == null)
                {
                    Response.Redirect("/Admin/AdminLogin.aspx");

                }
                else if (!(getSeniority(user.ToString()) == 4 || getSeniority(user.ToString()) == 5))
                {
                    Response.Redirect("/User/MyProfile.aspx");
                }
                else
                {

                    session = user.ToString();
                    seniority = getSeniority(session);
                    loadAllUsers();
                    loadDdl();
                    if (seniority == 4) subAdminAdapter();
                    all_users_listbox_SelectedIndexChanged(sender, e);
                }

            }
        }
        protected void subAdminAdapter()
        {
            txt_op_username.ReadOnly = true;
            ddl_op_seniority.Visible = false;
            txt_op_department.ReadOnly = true;
            txt_op_rating.ReadOnly = true;
            btn_block_10.Visible = false;
            btn_block_101.Visible = false;
            btn_destroy.Visible = false;
            txt_op_password.Visible = false;
            btn_block_3.Width = btn_writer_save.Width;
        }
        protected int getSeniority(String name)
        {
            int result = 0;
            SqlConnection c1 = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd1 = c1.CreateCommand();
            cmd1.CommandText = "select SeniorityID from WRITER where Name=@name";
            cmd1.Parameters.AddWithValue(@"name", name);
            c1.Open();
            var rdr = cmd1.ExecuteReader();
            if (rdr.Read())
            {
                result = rdr.GetInt32(0);
            }
            else result = -1;
            c1.Close();
            return result;
        }

        private void loadAllUsers()
        {

            all_users_listbox.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            if (seniority == 4) { cmd.CommandText = "select Name from WRITER where DepartmentID=(select DepartmentID from WRITER where Name =@name) order by SeniorityID asc";
                cmd.Parameters.AddWithValue(@"name", session);
            }
            else cmd.CommandText = "select Name from WRITER order by ID asc";
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                all_users_listbox.Items.Add(reader.GetString(0));
            }
            con.Close();
            all_users_listbox.SelectedIndex = 0;

        }
        private void loadDdl()
        {
            ddl_op_seniority.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Name from SENIORITY order by ID asc";
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ddl_op_seniority.Items.Add(reader.GetString(0));
            }
            con.Close();
        }
        
        protected void all_users_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = all_users_listbox.SelectedItem.ToString();
            name_unchanged = name;
            //int departmentID;
            DateTime timed;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Name, SeniorityID, Password, Rating, DepartmentID, ID from WRITER where Name= @name";
            cmd.Parameters.AddWithValue(@"name", name);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_op_username.Text=reader.GetString(0);
                ddl_op_seniority.SelectedIndex = reader.GetInt32(1)-1;
                txt_op_password.Text = reader.GetString(2);
                txt_op_rating.Text = reader.GetDouble(3).ToString();
                txt_op_department.Text = getDepartment(reader.GetInt32(4));
               lbl_op_followers.Text = getFollowersCount(reader.GetInt32(5)).ToString();
                lbl_op_entrycount.Text = getEntryCount(reader.GetInt32(5)).ToString();
            }
            reader.Close();
            var cmd2 = con.CreateCommand();
            cmd2.CommandText = "select Until from BLOCKWRITER where WriterID = (select ID from WRITER where Name =@name)";
            cmd2.Parameters.AddWithValue(@"name", name);
            var reader2 = cmd2.ExecuteReader();
           if (reader2.Read())
            {
                timed = reader2.GetDateTime(0);
            }
            else
            {
                timed = DateTime.Parse("2001 - 01 - 01 00:00:00.000");
            }
           
            con.Close();
            if (timed == def_time)
            {
                lbl_op_suspend.Text = "NO_SUSPEND";
            }
            else if (DateTime.Compare(timed, DateTime.Now) > 0)
            {
                lbl_op_suspend.Text = timed.ToShortDateString();
            }
            else if (DateTime.Compare(timed, DateTime.Now) <= 0)
            {
                lbl_op_suspend.Text = "uzaklaştırma bitmiş.";
            }
            
           
        }
       private String getDepartment(int a)
        {
            var con2 = new SqlConnection(connectionStrings.bedir);
            //con.Close();
            
            var cmd = con2.CreateCommand();
            cmd.CommandText = "select Name, IsEngineer from DEPARTMENT where ID= @id";
            cmd.Parameters.AddWithValue(@"id", a);
            con2.Open();
            var reader = cmd.ExecuteReader();

            //if (!reader.GetBoolean(1)) return "Mühendis Değil";
            //else
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            else return "Hata";
            
        }
        private int getFollowersCount(int a)
        {
            // con.Close();
            var con2 = new SqlConnection(connectionStrings.bedir);
            var cmd = con2.CreateCommand();
            cmd.CommandText = "select Count(ID) from FOLWRITER where FollowedID=@id ";
            cmd.Parameters.AddWithValue(@"id", a);
            con2.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
                return reader.GetInt32(0);
            else return -1;
        }
        private int getEntryCount(int a)
        {
            //con.Close();
            var con2 = new SqlConnection(connectionStrings.bedir);

            var cmd = con2.CreateCommand();
            cmd.CommandText = "select Count(ID) from ENTRY where WriterID=@id ";
            cmd.Parameters.AddWithValue(@"id", a);
            con2.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read()) { 
                var temp= reader.GetInt32(0);
            con2.Close();
            return temp;
            }
            else return -1;
        }

        protected void btn_block_3_Click(object sender, EventArgs e)
        {
            
            String name = txt_op_username.Text;
            int seniority = ddl_op_seniority.SelectedIndex + 1;
            String password = txt_op_password.Text;

            var con3 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd3 = con3.CreateCommand();
            con3.Open();
            cmd3.CommandText = "update WRITER set Name=@name, SeniorityID=@seniority, Password=@password where Name =@name_u";
            cmd3.Parameters.AddWithValue(@"name", name);
            cmd3.Parameters.AddWithValue(@"name_u", name_unchanged);
            cmd3.Parameters.AddWithValue(@"seniority", seniority);
            cmd3.Parameters.AddWithValue(@"password", password);
            try
            {
                var updater = cmd3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            var date = DateTime.Now;
            var span = new System.TimeSpan(3, 0, 0, 0);
            DateTime until = date + span;
            var con4 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd4 = con4.CreateCommand();
            con4.Open();
            if (lbl_op_suspend.Text == "NO_SUSPEND")
                cmd4.CommandText = "insert into BLOCKWRITER (WriterID, IsTimed, Until) values ((select ID from WRITER where Name=@name), 'True', @until)";
            else
                cmd4.CommandText = "update BLOCKWRITER set , IsTimed='True', Until = @until where WriterID=(select ID from WRITER where Name=@name)";

            cmd4.Parameters.AddWithValue(@"name", name);
            cmd4.Parameters.AddWithValue(@"until", until);
            try
            {
                var inserter = cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
        }

        protected void btn_block_10_Click(object sender, EventArgs e)
        {
            String name = txt_op_username.Text;
            int seniority = ddl_op_seniority.SelectedIndex + 1;
            String password = txt_op_password.Text;

            var con3 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd3 = con3.CreateCommand();
            con3.Open();
            cmd3.CommandText = "update WRITER set Name=@name, Seniority=@seniority, Password=@password where Name = @name_u";
            cmd3.Parameters.AddWithValue(@"name", name);
            cmd3.Parameters.AddWithValue(@"name_u", name_unchanged);
            cmd3.Parameters.AddWithValue(@"seniority", seniority);
            cmd3.Parameters.AddWithValue(@"password", password);
            try
            {
                var updater = cmd3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            var date = DateTime.Now;
            var span = new System.TimeSpan(10, 0, 0, 0);
            DateTime until = date + span;
            var con4 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd4 = con4.CreateCommand();
            con4.Open();
            if (lbl_op_suspend.Text == "NO_SUSPEND")
                cmd4.CommandText = "insert into BLOCKWRITER (WriterID, IsTimed, Until) values ((select ID from WRITER where Name=@name), 'True', @until)";
            else
                cmd4.CommandText = "update BLOCKWRITER set IsTimed='True', Until = @until where WriterID=(select ID from WRITER where Name=@name)";
            cmd4.Parameters.AddWithValue(@"name", name);
            cmd4.Parameters.AddWithValue(@"until", until);
            try
            {
                var inserter = cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
        }

        protected void btn_block_101_Click(object sender, EventArgs e)
        {
            String name = txt_op_username.Text;
            int seniority = ddl_op_seniority.SelectedIndex + 1;
            String password = txt_op_password.Text;

            var con3 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd3 = con3.CreateCommand();
            con3.Open();
            cmd3.CommandText = "update WRITER set Name=@name, Seniority=@seniority, Password=@password where Name = @name_u";
            cmd3.Parameters.AddWithValue(@"name", name);
            cmd3.Parameters.AddWithValue(@"name_u", name_unchanged);
            cmd3.Parameters.AddWithValue(@"seniority", seniority);
            cmd3.Parameters.AddWithValue(@"password", password);
            try
            {
                var updater = cmd3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            var date = DateTime.Now;
            var span = new System.TimeSpan(101, 0, 0, 0);
            DateTime until = date + span;
            var con4 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd4 = con4.CreateCommand();
            con4.Open();
            if (lbl_op_suspend.Text == "NO_SUSPEND")
                cmd4.CommandText = "insert into BLOCKWRITER (WriterID, IsTimed, Until) values ((select ID from WRITER where Name=@name), 'True', @until)";
            else
                cmd4.CommandText = "update BLOCKWRITER set , IsTimed='True', Until = @until where WriterID=(select ID from WRITER where Name=@name)";
            cmd4.Parameters.AddWithValue(@"name", name);
            cmd4.Parameters.AddWithValue(@"until", until);
            try
            {
                var inserter = cmd4.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
        }

        protected void btn_destroy_Click(object sender, EventArgs e)
        {
            String control = checkWriterHead(name_unchanged);
            if (control=="NO") { 
            var con3 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd3 = con3.CreateCommand();
            con3.Open();
            cmd3.CommandText = "delete from WRITER where Name =@name";
            cmd3.Parameters.AddWithValue(@"name", name_unchanged);
            try
            {
                var deleter = cmd3.ExecuteNonQuery();
                lbl_writer_save_status.Text = "yazar başarıyla imha edildi!";
            }
            catch(Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            }
            else
            {
                lbl_writer_save_status.Text = "bu yazar "+control+" başkanı. önce odaya yeni başkan atayın.";
            }
        }
        protected String checkWriterHead(string name)
        {
            String result = "";
            var con3 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd3 = con3.CreateCommand();
            con3.Open();
            cmd3.CommandText = "select Name from DEPARTMENT where Head = (select ID from WRITER where Name=@name)";
            cmd3.Parameters.AddWithValue(@"name", name);
            var reader = cmd3.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetString(0);
            }
            else
            {
                result = "NO";
            }
            con3.Close();
            return result;
        }

        protected void btn_writer_save_Click(object sender, EventArgs e)
        {
            String name = txt_op_username.Text;
            int seniority = ddl_op_seniority.SelectedIndex + 1;
            String password = txt_op_password.Text;

            var con3 = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True;");
            var cmd3 = con3.CreateCommand();
            con3.Open();
            cmd3.CommandText = "update WRITER set Name=@name, SeniorityID=@seniority, Password=@password where Name = @name_u";
            cmd3.Parameters.AddWithValue(@"name", name);
            cmd3.Parameters.AddWithValue(@"name_u", name_unchanged);
            cmd3.Parameters.AddWithValue(@"seniority", seniority);
            cmd3.Parameters.AddWithValue(@"password", password);
            try
            {
                var updater = cmd3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lbl_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            
        }
    }
}