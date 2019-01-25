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

    public partial class Rooms : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(connectionStrings.bedir);
        static String name_unchanged;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) {
            object user = Session["username"];
            if (user == null)
            {
                Response.Redirect("/Admin/AdminLogin.aspx");

            }
            else
            {
                loadAllRooms();
                    fillDdlNewRoom();
                all_rooms_listbox_SelectedIndexChanged(sender, e);
            }
            }
        }
        protected void fillDdlNewRoom()
        {
            var c3= new SqlConnection(connectionStrings.bedir);
            var cmd = c3.CreateCommand();
            cmd.CommandText = "select Name from WRITER where SeniorityID=3 or SeniorityID=4 or SeniorityID=5";
            c3.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ddl_op_newroom_head.Items.Add(reader.GetString(0));
            }
            c3.Close();
        }

        private void loadAllRooms()
        {
            all_rooms_listbox.Items.Clear();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Name from DEPARTMENT order by ID asc";
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                all_rooms_listbox.Items.Add(reader.GetString(0));
            }
            con.Close();
            all_rooms_listbox.SelectedIndex = 0;
        }
       
        protected void all_rooms_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = all_rooms_listbox.SelectedItem.ToString();
            name_unchanged = name;
            //int departmentID;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Name, Population, Head, ID from DEPARTMENT where Name= @name";
            cmd.Parameters.AddWithValue(@"name", name);
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_op_roomname.Text = reader.GetString(0);
                lbl_op_population.Text = reader.GetInt32(1).ToString();
                txt_op_leader.Text = getLeader(reader.GetInt32(2));
                lbl_op_no_of_headers.Text = getTitles(reader.GetInt32(3)).ToString();
                lbl_op_no_of_entries.Text = getEntries(reader.GetInt32(3)).ToString();
            }
            
            reader.Close();
            con.Close();
        }
       protected String getLeader(int id)
        {
            String result = "default";
            var con2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = con2.CreateCommand();
            cmd2.CommandText = "select Name from WRITER where ID=@id";
            cmd2.Parameters.AddWithValue(@"id", id);
            con2.Open();
            var reader2 = cmd2.ExecuteReader();
            if(reader2.Read()){
                result = reader2.GetString(0);
            }
            else
            {
                result = "hata oluştu";
            }
            con2.Close();
            return result;
        }
        protected int getTitles (int id)
        {
            int result = 0;
            var con2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = con2.CreateCommand();
            cmd2.CommandText = "select Count(ID) from TITLE where DepartmentID=@id";
            cmd2.Parameters.AddWithValue(@"id", id);
            con2.Open();
            var reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                result = reader2.GetInt32(0);
            }
            else
            {
                result = -1;
            }
            
            con2.Close();
            return result;
        }
        protected int getEntries(int id)
        {
            int result = 0;
            var con2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = con2.CreateCommand();
            cmd2.CommandText = "select Count(Name) from ENTRY inner join TITLE on ENTRY.TitleID=TITLE.ID and TITLE.DepartmentID=@id";
            cmd2.Parameters.AddWithValue(@"id", id);
            con2.Open();
            var reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                result = reader2.GetInt32(0);
            }
            else
            {
                result = -1;
            }

            con2.Close();
            return result;
        }
        protected int findID(String name)
        {
            int result = 0;
            var c2 = new SqlConnection(connectionStrings.bedir);
            var cmd = c2.CreateCommand();
            cmd.CommandText = "select ID from WRITER where Name = @name";
            cmd.Parameters.AddWithValue(@"name",name);
            c2.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            c2.Close();
            return result;
        }

        protected void btn_newroom_save_Click(object sender, EventArgs e)
        {
            String name = txt_op_newroom_name.Text;
            int head = findID(ddl_op_newroom_head.SelectedItem.ToString());
            var c1 = new SqlConnection(connectionStrings.bedir);
            var cmd = c1.CreateCommand();
            cmd.CommandText = "insert into DEPARTMENT (Name, Population, Head, IsEngineer) values (@name, 0, @head, 'True')";
            cmd.Parameters.AddWithValue(@"name",name);
            cmd.Parameters.AddWithValue(@"head",head);
            c1.Open();
            try{
                var insrt = cmd.ExecuteNonQuery();
                lbl_newroom_save_status.Text = "yeni oda başarıyla oluşturuldu.";
            }
            catch(Exception ex)
            {
                lbl_newroom_save_status.Text = ex.Message.ToString();
            }
            c1.Close();
        }
    }
}