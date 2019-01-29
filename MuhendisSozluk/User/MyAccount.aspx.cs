using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MuhendisSozluk.User
{
    public partial class MyAccount : System.Web.UI.Page
    {
        String con = connectionStrings.bedir;
        static String Name = null;
        static bool gender;
        static String email;
        static String password=null;
        static String new_password=null;
        static  String confirm_password=null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                object user = Session["username"];
                if (user == null)
                {
                    Response.Redirect("/User/Login.aspx");

                }
                else
                {
                    Name = user.ToString();
                    fillMyAccount();
                }
                fill();
            }
        }
        protected void fill()
        {
            DataSet ds_title = loadSolKanat();
            title_repeater.DataSource = ds_title;
            title_repeater.DataBind();
        }
        public DataSet loadSolKanat()
        {
            SqlConnection con2 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select Top 25 Name from TITLE where Visible='True' order by LastUpdate asc", con2);
            // da.SelectCommand.Parameters.AddWithValue(@"name", title);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            //if (ListSolKanat != null)
            //{
            //    ListSolKanat.Items.Clear();
            //}
            //var connection = new SqlConnection(connectionStrings.bedir);
            //var command = connection.CreateCommand();
            //command.CommandText = "select top 20 Name from TITLE order by LastUpdate desc";
            //connection.Open();
            //var reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    ListSolKanat.Items.Add(reader.GetString(0));
            //}
            //connection.Close();
        }

        protected void fillMyAccount()
        {
            lbl_myaccount_username_data.Text = Name;

            var connect = new SqlConnection(con);
            var cmd = connect.CreateCommand();
            cmd.CommandText = "select Name from DEPARTMENT where ID = (select DepartmentID from WRITER where Name = @name)";
            cmd.Parameters.AddWithValue("@name", Name);
            connect.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbl_myaccount_department_data.Text = reader.GetString(0);
            }
            connect.Close();

            var connect2 = new SqlConnection(con);
            var cmd2 = connect2.CreateCommand();
            cmd2.CommandText = "select Email from WRITER where Name= @name";
            cmd2.Parameters.AddWithValue("@name", Name);
            connect2.Open();
            var reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                txt_myaccount_mail.Text = reader2.GetString(0);
            }
            connect2.Close();

            var connect3 = new SqlConnection(con);
            var cmd3 = connect3.CreateCommand();
            cmd3.CommandText = "select Gender from WRITER where Name= @name";
            cmd3.Parameters.AddWithValue("@name", Name);
            connect3.Open();
            var reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                gender = reader3.GetBoolean(0);
            }
            connect3.Close();
            if (gender)
            {
                check_myaccount_lady.Checked = true;
                check_myaccount_gentleman.Checked = false;
            }
            else
            {
                check_myaccount_gentleman.Checked = true;
                check_myaccount_lady.Checked = false;
            }
        }

        protected void btn_myaccount_enter_Click(object sender, EventArgs e)
        {
            gender = check_myaccount_lady.Checked;
            email = txt_myaccount_mail.Text;
            password = txt_myaccount_password.Text;
            new_password = txt_myaccount_newpassword.Text;
            confirm_password = txt_myaccount_confirmpassword.Text;

            if(new_password!=null && confirm_password!=null && new_password.Equals(confirm_password))
            {
                var connect = new SqlConnection(con);
                var cmd = connect.CreateCommand();
                cmd.CommandText = "select Password from WRITER where Name = @name";
                cmd.Parameters.AddWithValue("@name", Name);
                connect.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (password.Equals( reader.GetString(0)))
                    {
                        reader.Close();
                        cmd.CommandText = "update WRITER set Email=@mail, Password=@password, Gender=@gender where Name=@name2";
                        cmd.Parameters.AddWithValue("@name2", Name);
                        cmd.Parameters.AddWithValue("@mail", email);
                        cmd.Parameters.AddWithValue("@password", new_password);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        try {var writer= cmd.ExecuteNonQuery();
                        }
                        catch(Exception ex)
                        {
                            lbl_myaccount_savestate.Text = ex.Message.ToString();
                        }
                        
                        
                    }
                }
            }

       
        }
        protected void btn_default_loginout_Click(object sender, EventArgs e)
        {
            object user = Session["username"];
            if (user == null)
            {
                Response.Redirect("/User/Login.aspx");
            }
            else
            {
                Session.Remove(user.ToString());
                Response.Redirect("/default.aspx");
            }

        }
        protected void btn_default_profile_Click(object sender, EventArgs e)
        {
            object user = Session["username"];
            if (user == null)
            {
                Response.Redirect("/User/Signup.aspx");
            }
            else
            {
                Response.Redirect("/User/MyProfile.aspx");
            }
        }

        protected void btn_left_title_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String title = btn.Text;
            //loadEntries(title);
            //lbl_default_title_name.Text = title;
        }
    }
}