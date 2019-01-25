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
    public partial class Titles : System.Web.UI.Page
    {
         SqlConnection con = new SqlConnection(connectionStrings.bedir);
        
        static String name_unchanged;
        static String session;
        static int seniority;
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
                    if (seniority == 4) subAdminAdapter();
                    loadAllTitles();

                    //all_titles_listbox_SelectedIndexChanged(sender, e);
                }
            }
        }
        protected void subAdminAdapter()
        {
            txt_titles_room.ReadOnly = true;
            btn_hide_title.Visible = false;

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

        protected void loadAllTitles()
        {
            all_titles_listbox.Items.Clear();
            
            var c2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = c2.CreateCommand();
            if (seniority == 4) {
                cmd2.CommandText = "select Name from TITLE where DepartmentID=(select DepartmentID from WRITER where Name =@name) order by LastUpdate desc";
                cmd2.Parameters.AddWithValue(@"name", session);
            }
            else cmd2.CommandText = "select Name from TITLE order by LastUpdate desc";
            c2.Open();
            var rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                all_titles_listbox.Items.Add(rdr2.GetString(0));
            }
            c2.Close();

        }

        protected void all_titles_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = all_titles_listbox.SelectedItem.ToString();
            name_unchanged = name;
            //int departmentID;
            SqlConnection c0 = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd = c0.CreateCommand();
            cmd.CommandText = "select Name, ID, Date, LastUpdate, DepartmentID, Useful, Useless, Visible, IsActive from TITLE where Name= @name";
            cmd.Parameters.AddWithValue(@"name", name);
            c0.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_titles_name.Text = reader.GetString(0);
                name_unchanged = reader.GetString(0);
                lbl_titles_entrycount.Text = getEntryCount(reader.GetInt32(1)).ToString();
                txt_titles_room.Text = getDepartment(reader.GetInt32(4));
                lbl_titles_followers.Text = getFollowers(reader.GetInt32(1)).ToString();
                lbl_titles_lastupdate.Text = reader.GetDateTime(3).ToString();
                lbl_titles_started.Text = reader.GetDateTime(2).ToString();
                lbl_titles_useful.Text = reader.GetInt32(5).ToString();
                lbl_titles_useless.Text = reader.GetInt32(6).ToString();
                lbl_titles_visible.Text = evetHayir(reader.GetBoolean(7));
                lbl_titles_isactive.Text = evetHayir(reader.GetBoolean(8));
            }

            reader.Close();
            c0.Close();
        }
        protected String evetHayir(Boolean x)
        {
            if (x) return "Evet";
            return "Hayir";
        }

        protected int getFollowers(int id)
        {
            int result = 0;
            var c5 = new SqlConnection(connectionStrings.bedir);
            // if (c5.State == ConnectionState.Open) c5.Close();
            var cmd5 = c5.CreateCommand();
            cmd5.CommandText = "select Count(ID) from FOLTITLE where TitleID=@id";
            cmd5.Parameters.AddWithValue(@"id", id);
            c5.Open();
            var rdr5 = cmd5.ExecuteReader();
            if (rdr5.Read())
            {
                result = rdr5.GetInt32(0);
            }
            c5.Close();
            return result;
        }
        protected String getDepartment(int id)
        {
            String result = "";
            var c4 = new SqlConnection(connectionStrings.bedir);
            // if (c4.State == ConnectionState.Open) c4.Close();
            var cmd4 = c4.CreateCommand();
            cmd4.CommandText = "select Name from DEPARTMENT where ID=@id";
            cmd4.Parameters.AddWithValue(@"id", id);
            c4.Open();
            var rdr4 = cmd4.ExecuteReader();
            if (rdr4.Read())
            {
                result = rdr4.GetString(0);
            }
            c4.Close();
            return result;
        }
        protected int getEntryCount(int id)
        {
            int result = 0;
            var c3 = new SqlConnection(connectionStrings.bedir);
            // if (c3.State == ConnectionState.Open) c3.Close();
            var cmd3= c3.CreateCommand();
            cmd3.CommandText = "select Count(ID) from ENTRY where TitleID=@id";
            cmd3.Parameters.AddWithValue(@"id", id);
            c3.Open();
            var reader2 = cmd3.ExecuteReader();
            if (reader2.Read())
            {
                result = reader2.GetInt32(0);
            }
            else
            {
                result = -1;
            }

            c3.Close();
            return result;
        }

        protected void btn_stop_title_Click(object sender, EventArgs e)
        {
            String name = txt_titles_name.Text;
           
            var c6 = new SqlConnection(connectionStrings.bedir);
            // if (c3.State == ConnectionState.Open) c3.Close();
            var cmd6 = c6.CreateCommand();
            if(lbl_titles_isactive.Text=="Evet")
            cmd6.CommandText = "update TITLE set Name=@name, IsActive='False' where Name=@name_u";
            else cmd6.CommandText = "update TITLE set Name=@name, IsActive='True' where Name=@name_u";
            cmd6.Parameters.AddWithValue(@"name", name);
            cmd6.Parameters.AddWithValue(@"name_u", name_unchanged);
            c6.Open();
            try
            {
                var save1 = cmd6.ExecuteNonQuery();
                lbl_titles_save_status.Text = "başlık başarıyla güncellendi.";
            }
            catch(Exception ex)
            {
                lbl_titles_save_status.Text = ex.Message.ToString();
            }
            c6.Close();
        
        }

        protected void btn_hide_title_Click(object sender, EventArgs e)
        {
            String name = txt_titles_name.Text;

            var c7 = new SqlConnection(connectionStrings.bedir);
            // if (c3.State == ConnectionState.Open) c3.Close();
            var cmd7= c7.CreateCommand();
            if(lbl_titles_visible.Text=="Evet")
            cmd7.CommandText = "update TITLE set Name=@name, Visible='False' where Name=@name_u";
            else cmd7.CommandText = "update TITLE set Name=@name, Visible='True' where Name=@name_u";
            cmd7.Parameters.AddWithValue(@"name", name);
            cmd7.Parameters.AddWithValue(@"name_u", name_unchanged);
            c7.Open();
            try
            {
                var save1 = cmd7.ExecuteNonQuery();
                lbl_titles_save_status.Text = "başlık başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                lbl_titles_save_status.Text = ex.Message.ToString();
            }
            c7.Close();

        }

        protected void btn_room_save_Click(object sender, EventArgs e)
        {
            String name = txt_titles_name.Text;

            var c8 = new SqlConnection(connectionStrings.bedir);
            // if (c3.State == ConnectionState.Open) c3.Close();
            var cmd8= c8.CreateCommand();
            cmd8.CommandText = "update TITLE set Name=@name where Name=@name_u";
            cmd8.Parameters.AddWithValue(@"name", name);
            cmd8.Parameters.AddWithValue(@"name_u", name_unchanged);
            c8.Open();
            try
            {
                var save1 = cmd8.ExecuteNonQuery();
                lbl_titles_save_status.Text = "başlık başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                lbl_titles_save_status.Text = ex.Message.ToString();
            }
            c8.Close();

        }
    }
}