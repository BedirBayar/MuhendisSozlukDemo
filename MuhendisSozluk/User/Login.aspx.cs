using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MuhendisSozluk;



namespace MuhendisSozluk.User
{
    public partial class Login : System.Web.UI.Page
    {
        String email;
        String password;
        String login_user=null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //MuhendisSozluk._default def = new MuhendisSozluk._default();
                //def.loadSolKanat();
                loadSolKanat();
            }
        }
        public void loadSolKanat()
        {
            if (ListSolKanat != null)
            {
                ListSolKanat.Items.Clear();
            }
            var connection = new SqlConnection(connectionStrings.bedir);
            var command = connection.CreateCommand();
            command.CommandText = "select top 20 Name from TITLE order by LastUpdate desc";
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListSolKanat.Items.Add(reader.GetString(0));
            }
            connection.Close();
        }

        protected void btn_login_enter_Click(object sender, EventArgs e)
        {
            email = txt_login_mail.Text;
            password = txt_login_password.Text;
            String temp_user;
            int temp_userid=0;

            var connection_login = new SqlConnection(connectionStrings.bedir);
            var command_login = connection_login.CreateCommand();
            connection_login.Open();
            command_login.CommandText = "select Name, ID from WRITER where Email = @email and Password = @password";
            command_login.Parameters.AddWithValue("@email", email);
            command_login.Parameters.AddWithValue("@password", password);

            var reader = command_login.ExecuteReader();
            if (reader.Read())
            {
                temp_user = reader.GetString(0);
                temp_userid = reader.GetInt32(1);
             }
            else
            {
                lbl_login_error.Text = "kullanıcı adı veya parola hatalı";
                return;
            }
            reader.Close();

            command_login.CommandText = "select Until from BLOCKWRITER where WriterID = @id";
            command_login.Parameters.AddWithValue(@"id", temp_userid);
            reader = command_login.ExecuteReader();
            if(reader.Read()){
                if (DateTime.Compare(reader.GetDateTime(0), DateTime.Now) <= 0) {
                login_user = temp_user;
                }
                else
                {
                    lbl_login_error.Text = "şu anda uzaklaştırma cezanız vardır. " + reader.GetDateTime(0) + " tarihinden itibaren giriş yapabilirsiniz.";
                }
            }
            else
            {
                login_user = temp_user;
                //Response.Redirect("/default.aspx");
            }
            connection_login.Close();
            if (login_user != null){
                Session.Add("username", login_user);
                Response.Redirect("/default.aspx");
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
        //abi hata yerini açsana

    }
}