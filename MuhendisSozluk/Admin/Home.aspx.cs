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
    public partial class Home : System.Web.UI.Page
    {
            //static int entryID;
            static int writerID;
            static int titleID;
         static int seniority;
        static int dep_id=-1;
        static String subAdmin;
        static string name_unchanged;
        SqlConnection con = new SqlConnection(connectionStrings.bedir);
     
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!this.IsPostBack)
            {

                object user = Session["username"];

                if (user == null )
                {
                    Response.Redirect("/Admin/AdminLogin.aspx");
                }
                else if(!(getSeniority(user.ToString()) == 4 || getSeniority(user.ToString()) == 5))
                {
                    Response.Redirect("/User/MyProfile.aspx");
                }
                else
                {
                    
                    fillDdlSeniority();
                    fillDdlDepartment();
                    
                }
                seniority = getSeniority(user.ToString());
                if (seniority == 4)
                {
                    subAdmin = user.ToString();
                    subAdminAdapter();
                    dep_id = getDepByName(subAdmin);
                    btn_profile_name.Text = getDepartment(dep_id) + " başkanı " + subAdmin;
                   
                }
                else btn_profile_name.Text ="moderatör " + user.ToString();

            }
        }
        protected void subAdminAdapter()
        {
            dep_id = getDepByName(subAdmin);
            btn_adm_menu_dep.Visible = false;
            btn_home_entry_delete.Visible = false;
            txt_search_entry_contents.ReadOnly = true;
            ddl_search_title_department.Visible = false;
            btn_home_title_hide.Visible = false;
            ddl_search_writer_seniority.Visible = false;
            txt_search_writer_password.Visible = false;
            btn_search_writer_block_10.Visible = false;
            btn_search_writer_block_101.Visible = false;
            btn_search_writer_destroy.Visible = false;
        }
        protected int getDepByName(string name)
        {
            int result =0;
            SqlConnection c11 = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd11 = c11.CreateCommand();
            cmd11.CommandText = "select DepartmentID from WRITER where Name=@name";
            cmd11.Parameters.AddWithValue(@"name", name);
            c11.Open();
            var reader = cmd11.ExecuteReader();
            if (reader.Read())  result = reader.GetInt32(0);
            else result = -1;
            c11.Close();
            return result;
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
        protected void fillDdlDepartment()
        {
            var connection_ddl = new SqlConnection(connectionStrings.bedir);
            var command_ddl = connection_ddl.CreateCommand();
            command_ddl.CommandText = "select Name from DEPARTMENT";
            connection_ddl.Open();
            var reader = command_ddl.ExecuteReader();
            while (reader.Read())
            {
                ddl_search_title_department.Items.Add(reader.GetString(0));
            }
            connection_ddl.Close();
        }
        protected void fillDdlSeniority()
        {

            var connection_ddl = new SqlConnection(connectionStrings.bedir);
            var command_ddl = connection_ddl.CreateCommand();
            command_ddl.CommandText = "select Name from SENIORITY";
            connection_ddl.Open();
            var reader = command_ddl.ExecuteReader();
            while (reader.Read())
            {
                ddl_search_writer_seniority.Items.Add(reader.GetString(0));
            }
            connection_ddl.Close();
        }


        protected void btn_adm_menu_users_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Writers.aspx");
        }

        protected void btn_adm_menu_dep_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Rooms.aspx");
        }

        protected void btn_adm_menu_titles_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Titles.aspx");
        }
        protected void btn_adm_menu_entries_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Entries.aspx");
        }

        protected void txt_admin_search_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void btn_admin_search_Click(object sender, EventArgs e)
        {
            String key = txt_admin_search.Text;
            

            if (key.StartsWith("#"))
            {
                searchEntry(key.Substring(1));
            }
            else if (key.StartsWith("@"))
            {
                searchWriter(key.Substring(1));
            }
            else
            {
                searchTitle(key);
            }
        }
        public void searchEntry(String key)
        {
            
            int number = Int32.Parse(key);
            var cmd = con.CreateCommand();
            cmd.CommandText = "select * from ENTRY where ID = @number";
            cmd.Parameters.AddWithValue(@"number", number);
            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
               
                if ( string.IsNullOrEmpty(rdr.GetInt32(8).ToString())) lbl_search_entry_writer.Text="";
               else lbl_search_entry_writer.Text = getWriter(rdr.GetInt32(8));
                if (DBNull.Value.Equals(rdr.GetInt32(0))) lbl_search_entry_number.Text = "";
               else lbl_search_entry_number.Text = rdr.GetInt32(0).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(3))) lbl_search_entry_like.Text = "";
                else lbl_search_entry_like.Text = rdr.GetInt32(3).ToString() ;
                if (DBNull.Value.Equals(rdr.GetValue(4))) lbl_search_entry_dislike.Text = "";
               else lbl_search_entry_dislike.Text = rdr.GetInt32(4).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(2))) lbl_search_entry_fav.Text = "";
               else lbl_search_entry_fav.Text = rdr.GetInt32(2).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(6))) lbl_search_entry_rating.Text = "";
               else lbl_search_entry_rating.Text = rdr.GetSqlDouble(6).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(9))) lbl_search_entry_title.Text = "";
               else lbl_search_entry_title.Text = getTitle(rdr.GetInt32(9));
                if (DBNull.Value.Equals(rdr.GetValue(1))) txt_search_entry_contents.Text = "";
                else txt_search_entry_contents.Text = rdr.GetString(1);
               // entryID = rdr.GetInt32(0);
            }
            
            else
            {
                lbl_search_entry_writer.Text = "arama sırasında hata oluştu!";
            }
            con.Close();
        }
        
        protected void searchWriter(String key)
        {
             String name = key;
            var cmd = con.CreateCommand();
            if (seniority == 4)
            {
                cmd.CommandText = "select * from WRITER where Name=@name and DepartmentID=@dep";
                cmd.Parameters.AddWithValue(@"dep", dep_id);
            }
           else  cmd.CommandText = "select * from WRITER where Name = @name";
            cmd.Parameters.AddWithValue(@"name", name);
            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {

                if (string.IsNullOrEmpty(rdr.GetString(1))) txt_search_writer_name.Text = " ";
                else txt_search_writer_name.Text = rdr.GetString(1);
                if (DBNull.Value.Equals(rdr.GetValue(6))) lbl_search_writer_department.Text = " ";
                else lbl_search_writer_department.Text = getDepartment(rdr.GetInt32(6));
                if (DBNull.Value.Equals(rdr.GetInt32(7))) ddl_search_writer_seniority.Text = " ";
                else ddl_search_writer_seniority.SelectedIndex = rdr.GetInt32(7)-1;
                if (DBNull.Value.Equals(rdr.GetValue(5))) lbl_search_writer_rating.Text = "0";
                else lbl_search_writer_rating.Text = rdr.GetSqlDouble(5).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(3))) txt_search_writer_password.Text = " ";
                else txt_search_writer_password.Text = rdr.GetString(3);
                if (DBNull.Value.Equals(rdr.GetValue(0))) lbl_search_writer_suspend.Text = "yok";
                else lbl_search_writer_suspend.Text = getSuspend(rdr.GetInt32(0)).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(0))) lbl_search_writer_followers.Text = "0";
                else lbl_search_writer_followers.Text = getFollowerCount(rdr.GetInt32(0)).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(0))) lbl_search_writer_entrycount.Text = "0";
                else lbl_search_writer_entrycount.Text = getEntryCount(rdr.GetInt32(0)).ToString();
               writerID = rdr.GetInt32(0);

            }

            else
            {
                if (seniority == 4)
                    lbl_search_entry_writer.Text = "bu odada böyle bir yazar yok.";
                else lbl_search_entry_writer.Text = "böyle bir yazar yok";
            }
            con.Close();
        }
        protected void searchTitle(String key)
        {
            String name = key;
            var cmd = con.CreateCommand();
            if (seniority == 4)
            {
                cmd.CommandText = "select * from TITLE where Name=@name and DepartmentID=@dep";
                cmd.Parameters.AddWithValue(@"dep", dep_id);
            }
            else cmd.CommandText = "select * from TITLE where Name = @name";
            cmd.Parameters.AddWithValue(@"name", name);
            
            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                titleID = rdr.GetInt32(0);
                if (string.IsNullOrEmpty(rdr.GetString(1))) txt_search_title_name.Text = " ";
                else txt_search_title_name.Text = rdr.GetString(1);
                if (DBNull.Value.Equals(rdr.GetValue(8))) lbl_search_title_writer.Text = " ";
                else lbl_search_title_writer.Text = getWriter(rdr.GetInt32(8));
                if (DBNull.Value.Equals(rdr.GetInt32(9))) ddl_search_title_department.Text = " ";
                else ddl_search_title_department.SelectedIndex = rdr.GetInt32(9)-1;
                if (DBNull.Value.Equals(rdr.GetValue(6))) lbl_search_title_useful.Text = "0";
                else lbl_search_title_useful.Text = rdr.GetInt32(6).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(7))) lbl_search_title_useless.Text = "0";
                else lbl_search_title_useless.Text = rdr.GetInt32(7).ToString();
                if (DBNull.Value.Equals(rdr.GetValue(4))) lbl_search_title_visible.Text = " ";
                else  lbl_search_title_visible.Text = boolEvetHayir(rdr.GetBoolean(4));
                if (DBNull.Value.Equals(rdr.GetValue(5))) lbl_search_title_active.Text = " ";
                else lbl_search_title_active.Text = boolEvetHayir(rdr.GetBoolean(5));
                if (DBNull.Value.Equals(rdr.GetValue(2))) lbl_search_title_date.Text = " ";
                else lbl_search_title_date.Text = rdr.GetDateTime(2).ToString();
               

            }
           

            else
            {
                
            }
con.Close();
        }
        String boolEvetHayir (Boolean x){
            if (x) return "evet";
            return "hayır";
        }
        String getWriter(int id)
        {
            String result = null;
            SqlConnection con2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = con2.CreateCommand();
            cmd2.CommandText = "select Name from WRITER where ID = @id";
            cmd2.Parameters.AddWithValue(@"id",id);
            con2.Open();
            var rdr2 = cmd2.ExecuteReader();
            if (rdr2.Read())
            {
                result = rdr2.GetString(0);
            }
            else
            {
                result = "yazar bulunamadı!";
            }
            con2.Close();
            return result;
        }
        String getDepartment(int id)
        {
            String result = null;
            SqlConnection con2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = con2.CreateCommand();
            cmd2.CommandText = "select Name from DEPARTMENT where ID = @id";
            cmd2.Parameters.AddWithValue(@"id", id);
            con2.Open();
            var rdr2 = cmd2.ExecuteReader();
            if (rdr2.Read())
            {
                result = rdr2.GetString(0);
            }
            else
            {
                result = "oda bulunamadı!";
            }
            con2.Close();
            return result;
        }
        String getTitle(int id)
        {
            String result = null;
            SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
            var cmd3 = con3.CreateCommand();
            cmd3.CommandText = "select Name from TITLE where ID = @id";
            cmd3.Parameters.AddWithValue(@"id", id);
            con3.Open();
            var rdr3 = cmd3.ExecuteReader();
            if (rdr3.Read())
            {
                result = rdr3.GetString(0);
            }
            else
            {
                result = "yazar bulunamadı!";
            }
            con3.Close();
            return result;
        }
        int getFollowerCount(int id)
        {
            int result = 0;
            SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
            var cmd3 = con3.CreateCommand();
            cmd3.CommandText = "select count(FollowerID) from FOLWRITER where FollowedID = @id";
            cmd3.Parameters.AddWithValue(@"id", id);
            con3.Open();
            var rdr3 = cmd3.ExecuteReader();
            if (rdr3.Read())
            {
                result = rdr3.GetInt32(0);
            }
            else
            {
                result = 0;
            }
            con3.Close();
            return result;
        }
        int getEntryCount(int id)
        {
            int result = 0;
            SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
            var cmd3 = con3.CreateCommand();
            cmd3.CommandText = "select count(ID) from ENTRY where WriterID = @id";
            cmd3.Parameters.AddWithValue(@"id", id);
            con3.Open();
            var rdr3 = cmd3.ExecuteReader();
            if (rdr3.Read())
            {
                result = rdr3.GetInt32(0);
            }
            else
            {
                result = 0;
            }
            con3.Close();
            return result;
        }
        String getSuspend(int id) 
        {
            String result = "yok";
            SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
            var cmd3 = con3.CreateCommand();
            cmd3.CommandText = "select Until from BLOCKWRITER where WriterID = @id";
            cmd3.Parameters.AddWithValue(@"id", id);
            con3.Open();
            var rdr3 = cmd3.ExecuteReader();
            if (rdr3.Read())
            {
                if (rdr3.GetDateTime(0) > DateTime.Now)
                    result = rdr3.GetDateTime(0).ToLongDateString();
                else result = "bitmiş";
            }
            else
            {
                result = "almamış";
            }
            con3.Close();
            return result;
        }

        protected void btn_home_entry_save_Click(object sender, EventArgs e)//ENTRY KAYDETME
        {
            String Contents = txt_search_entry_contents.Text;
            int entryID = Int32.Parse(lbl_search_entry_number.Text);
            if (txt_search_entry_contents.Text!=null) { 
            SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
            var cmd3 = con3.CreateCommand();
            cmd3.CommandText = "update ENTRY set Contents=@Contents where ID=@id ";
            cmd3.Parameters.AddWithValue(@"Contents", Contents);
            cmd3.Parameters.AddWithValue(@"id", entryID);
                con3.Open();
                try
                {
                    var saver = cmd3.ExecuteNonQuery();
                    lbl_search_entry_save_status.Text = "entry bilgileri başarıyla güncellendi.";
                }
                catch(Exception ex)
                {
                    lbl_search_entry_save_status.Text = ex.Message.ToString();
                }
                con3.Close();
                //entryID = 0;
            }
                else{
                lbl_search_entry_save_status.Text = "entry yok. entry arayın ve düzenleyin.";
                }
           
        }

        protected void btn_home_entry_delete_Click(object sender, EventArgs e)//ENTRY SİLME
        {
            int id = Int32.Parse(lbl_search_entry_number.Text);
            if (txt_search_entry_contents.Text != null)
            {
                SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
                var cmd3 = con3.CreateCommand();
                cmd3.CommandText = "delete from ENTRY where ID=@id ";
                cmd3.Parameters.AddWithValue(@"id", id);
                con3.Open();
                try
                {
                    var deleter = cmd3.ExecuteNonQuery();
                    lbl_search_entry_save_status.Text = "entry başarıyla silindi.";
                }
                catch (Exception ex)
                {
                    lbl_search_entry_save_status.Text = ex.Message.ToString();
                }
                con3.Close();
                //entryID = 0;
            }
            else
            {
                lbl_search_entry_save_status.Text = "entry yok. entry arayın ve düzenleyin.";
            }
        }

        protected void btn_home_entry_hide_Click(object sender, EventArgs e)
        {
            String Contents = txt_search_entry_contents.Text;
            int entryID = Int32.Parse(lbl_search_entry_number.Text);
            if (txt_search_entry_contents.Text != null)
            {
                SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
                var cmd3 = con3.CreateCommand();
                cmd3.CommandText = "update ENTRY set Contents=@Contents, Visible='False' where ID=@id ";
                cmd3.Parameters.AddWithValue(@"Contents", Contents);
                cmd3.Parameters.AddWithValue(@"id", entryID);
                con3.Open();
                try
                {
                    var saver = cmd3.ExecuteNonQuery();
                    lbl_search_entry_save_status.Text = "entry başarıyla gizlendi.";
                }
                catch (Exception ex)
                {
                    lbl_search_entry_save_status.Text = ex.Message.ToString();
                }
                con3.Close();
                //entryID = 0;
            }
            else
            {
                lbl_search_entry_save_status.Text = "entry yok. entry arayın ve düzenleyin.";
            }
        }//ENTRY GİZLEME

        protected void btn_home_title_save_Click(object sender, EventArgs e)
        {
            String name = txt_search_title_name.Text;
            int departmentid = ddl_search_title_department.SelectedIndex + 1;
            if (txt_search_title_name.Text != null)
            {
                SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
                var cmd3 = con3.CreateCommand();
                cmd3.CommandText = "update TITLE set Name=@name, DepartmentID=@departmentid where ID=@id ";
                cmd3.Parameters.AddWithValue(@"name",name);
                cmd3.Parameters.AddWithValue(@"departmentid", departmentid);
                cmd3.Parameters.AddWithValue(@"id", titleID);
                con3.Open();
                try
                {
                    var saver = cmd3.ExecuteNonQuery();
                    lbl_search_title_save_status.Text = "başlık bilgileri başarıyla güncellendi.";
                }
                catch (Exception ex)
                {
                    lbl_search_title_save_status.Text = ex.Message.ToString();
                }
                con3.Close();
                //entryID = 0;
            }
            else
            {
                lbl_search_title_save_status.Text = "başlık yok. başlık arayın ve düzenleyin.";
            }

        }//BAŞLIK KAYDETME

        protected void btn_home_title_stop_Click(object sender, EventArgs e)
        {
            String name = txt_search_title_name.Text;
            int departmentid = ddl_search_title_department.SelectedIndex + 1;

            if (txt_search_title_name.Text != null)
            {
                SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
                var cmd3 = con3.CreateCommand();
                cmd3.CommandText = "update TITLE set Name=@name, DepartmentID=@departmentid, IsActive='False' where ID=@id ";
                cmd3.Parameters.AddWithValue(@"name", name);
                cmd3.Parameters.AddWithValue(@"departmentid", departmentid);
                cmd3.Parameters.AddWithValue(@"id", titleID);
                con3.Open();
                try
                {
                    var saver = cmd3.ExecuteNonQuery();
                    lbl_search_title_save_status.Text = "başlık bilgileri başarıyla güncellendi.";
                }
                catch (Exception ex)
                {
                    lbl_search_title_save_status.Text = ex.Message.ToString();
                }
                con3.Close();
                //entryID = 0;
            }
            else
            {
                lbl_search_title_save_status.Text = "başlık yok. başlık arayın ve düzenleyin.";
            }
        }// BAŞLIK DURDURMA

        protected void btn_home_title_hide_Click(object sender, EventArgs e)
        {
            String name = txt_search_title_name.Text;
            int departmentid = ddl_search_title_department.SelectedIndex + 1;

            if (txt_search_title_name.Text != null)
            {
                SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
                var cmd3 = con3.CreateCommand();
                cmd3.CommandText = "update TITLE set Name=@name, DepartmentID=@departmentid, Visible='False' where ID=@id ";
                cmd3.Parameters.AddWithValue(@"name", name);
                cmd3.Parameters.AddWithValue(@"departmentid", departmentid);
                cmd3.Parameters.AddWithValue(@"id", titleID);
                con3.Open();
                try
                {
                    var saver = cmd3.ExecuteNonQuery();
                    lbl_search_title_save_status.Text = "başlık bilgileri başarıyla güncellendi.";
                }
                catch (Exception ex)
                {
                    lbl_search_title_save_status.Text = ex.Message.ToString();
                }
                con3.Close();
                //entryID = 0;
            }
            else
            {
                lbl_search_title_save_status.Text = "başlık yok. başlık arayın ve düzenleyin.";
            }
        }//BAŞLIK GİZLEME

        protected void btn_search_writer_block_3_Click(object sender, EventArgs e)
        {
            String name = txt_search_writer_name.Text;
            int seniority = ddl_search_writer_seniority.SelectedIndex + 1;
            String password = txt_search_writer_password.Text;

            var con3 = new SqlConnection(connectionStrings.bedir);
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
                lbl_search_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            var date = DateTime.Now;
            var span = new System.TimeSpan(3, 0, 0, 0);
            DateTime until = date + span;
            var con4 = new SqlConnection(connectionStrings.bedir);
            var cmd4 = con4.CreateCommand();
            con4.Open();
            if (lbl_search_writer_suspend.Text == "NO_SUSPEND")
                cmd4.CommandText = "insert into BLOCKWRITER (WriterID, IsTimed, Until) values ((select ID from WRITER where Name=@name), 'True', @until)";
            else
                cmd4.CommandText = "update BLOCKWRITER set , IsTimed='True', Until = @until where WriterID=(select ID from WRITER where Name=@name)";

            cmd4.Parameters.AddWithValue(@"name", name);
            cmd4.Parameters.AddWithValue(@"until", until);
            try
            {
                var inserter = cmd4.ExecuteNonQuery();
                lbl_search_writer_save_status.Text = "yazar başarıyla 3 gün uzaklaştırıldı.";
            }
            catch (Exception ex)
            {
                lbl_search_writer_save_status.Text = ex.Message.ToString();
            }
        }//3 GÜN UZAKLAŞTIRMA

        protected void btn_search_writer_block_10_Click(object sender, EventArgs e)
        {
            String name = txt_search_writer_name.Text;
            int seniority = ddl_search_writer_seniority.SelectedIndex + 1;
            String password = txt_search_writer_password.Text;

            var con3 = new SqlConnection(connectionStrings.bedir);
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
               // lbl_search_writer_save_status.Text = "yazar başarıyla 3 gün uzaklaştırıldı.";
            }
            catch (Exception ex)
            {
                lbl_search_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            var date = DateTime.Now;
            var span = new System.TimeSpan(10, 0, 0, 0);
            DateTime until = date + span;
            var con4 = new SqlConnection(connectionStrings.bedir);
            var cmd4 = con4.CreateCommand();
            con4.Open();
            if (lbl_search_writer_suspend.Text == "NO_SUSPEND")
                cmd4.CommandText = "insert into BLOCKWRITER (WriterID, IsTimed, Until) values ((select ID from WRITER where Name=@name), 'True', @until)";
            else
                cmd4.CommandText = "update BLOCKWRITER set , IsTimed='True', Until = @until where WriterID=(select ID from WRITER where Name=@name)";

            cmd4.Parameters.AddWithValue(@"name", name);
            cmd4.Parameters.AddWithValue(@"until", until);
            try
            {
                var inserter = cmd4.ExecuteNonQuery();
                lbl_search_writer_save_status.Text = "yazar başarıyla 10 gün uzaklaştırıldı.";
            }
            catch (Exception ex)
            {
                lbl_search_writer_save_status.Text = ex.Message.ToString();
            }
        }//10 GÜN UZAKLAŞTIRMA
        protected void btn_search_writer_block_101_Click(object sender, EventArgs e)
        {
            String name = txt_search_writer_name.Text;
            int seniority = ddl_search_writer_seniority.SelectedIndex + 1;
            String password = txt_search_writer_password.Text;

            var con3 = new SqlConnection(connectionStrings.bedir);
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
               // 
            }
            catch (Exception ex)
            {
                lbl_search_writer_save_status.Text = ex.Message.ToString();
            }
            con3.Close();
            var date = DateTime.Now;
            var span = new System.TimeSpan(101, 0, 0, 0);
            DateTime until = date + span;
            var con4 = new SqlConnection(connectionStrings.bedir);
            var cmd4 = con4.CreateCommand();
            con4.Open();
            if (lbl_search_writer_suspend.Text == "NO_SUSPEND")
                cmd4.CommandText = "insert into BLOCKWRITER (WriterID, IsTimed, Until) values ((select ID from WRITER where Name=@name), 'True', @until)";
            else
                cmd4.CommandText = "update BLOCKWRITER set , IsTimed='True', Until = @until where WriterID=(select ID from WRITER where Name=@name)";

            cmd4.Parameters.AddWithValue(@"name", name);
            cmd4.Parameters.AddWithValue(@"until", until);
            try
            {
                var inserter = cmd4.ExecuteNonQuery();
                lbl_search_writer_save_status.Text = "yazar başarıyla 101 gün uzaklaştırıldı.";
            }
            catch (Exception ex)
            {
                lbl_search_writer_save_status.Text = ex.Message.ToString();
            }
        }//101 GÜN UZAKLAŞTIRMA

        protected void btn_search_writer_save_Click(object sender, EventArgs e)
        {
            String name = txt_search_writer_name.Text;
            String password = txt_search_writer_password.Text;
            int seniorityid = ddl_search_writer_seniority.SelectedIndex + 1;
            if (txt_search_writer_name.Text != null)
            {
                SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
                var cmd3 = con3.CreateCommand();
                cmd3.CommandText = "update WRITER set Name=@name, SeniorityID=@seniorityid, Password=@password where ID=@id ";
                cmd3.Parameters.AddWithValue(@"name", name);
                cmd3.Parameters.AddWithValue(@"seniorityid", seniorityid);
                cmd3.Parameters.AddWithValue(@"password", password);
                cmd3.Parameters.AddWithValue(@"id", writerID);
                con3.Open();
                try
                {
                    var saver = cmd3.ExecuteNonQuery();
                    lbl_search_writer_save_status.Text = "yazar başarıyla kaydedildi.";
                }
                catch (Exception ex)
                {
                    lbl_search_writer_save_status.Text = ex.Message.ToString();
                }
                con3.Close();
            }
        }//YAZAR KAYDETME

        protected void btn_search_writer_destroy_Click(object sender, EventArgs e)
        {
            String name = txt_search_writer_name.Text;
            String control = checkWriterHead(name);
            if (control == "NO")
            {
                var con3 = new SqlConnection(connectionStrings.bedir);
                var cmd3 = con3.CreateCommand();
                cmd3.CommandText = "delete from WRITER where Name=@name";
                con3.Open();
                try
                {
                    var deleter = cmd3.ExecuteNonQuery();
                    lbl_search_writer_save_status.Text = "yazar başarıyla imha edildi.";
                }
                catch (Exception ex)
                {
                    lbl_search_writer_save_status.Text = ex.Message.ToString();
                }
            }
            else {
                lbl_search_writer_save_status.Text = "bu yazar " + control + " başkanı. önce odaya yeni başkan atayın.";
            }
        }
        protected String checkWriterHead(string name)
        {
            String result = "";
            var con3 = new SqlConnection(connectionStrings.bedir);
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

        protected void btn_profile_name_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/Myprofile.aspx");
        }
    }
}