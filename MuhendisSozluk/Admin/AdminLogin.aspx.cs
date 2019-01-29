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
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_admlogin_enter_Click(object sender, EventArgs e)
        {
            String email = txt_admlogin_mail.Text.ToString();
            String password = txt_admlogin_password.Text.ToString();
            String login_user;


            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select Name from WRITER where Email=@email and Password=@password and SeniorityID=5";
            cmd.Parameters.AddWithValue(@"email", email);
            cmd.Parameters.AddWithValue(@"password", password);
            con.Open();
            try {
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    login_user = reader.GetString(0);
                }
                else
                {
                    login_user = null;
                    lbl_admlogin_error.Text = "kullanıcı adı veya parola hatalı. hatalı olmasa bile hatalı.";
                }
                if (login_user != null)
                {
                    Session.Add("username", login_user);
                    con.Close();
                    Response.Redirect("/Admin/Home.aspx");

                }
            }
            catch(Exception ex)
            {
                lbl_admlogin_error.Text=ex.Message.ToString();
            }
            con.Close();
        }
    }
}
