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
    public partial class Signup : System.Web.UI.Page
    {
        String username;
        String email;
        String password;
        bool gender;
        String department;
         
        protected void fillDropDownList()
        {
            var connection_ddl = new SqlConnection(connectionStrings.bedir);
            var command_ddl = connection_ddl.CreateCommand();
            command_ddl.CommandText = "select Name from DEPARTMENT";
            connection_ddl.Open();
            var reader = command_ddl.ExecuteReader();
            while (reader.Read())
            {
                ddl_signup_department.Items.Add(reader.GetString(0));
            }
            connection_ddl.Close();
        }
        protected int getDepartmentId(String department)
        {
            int departmentid;
            var connection_signup = new SqlConnection(connectionStrings.bedir);
            var command_signup = connection_signup.CreateCommand();
            connection_signup.Open();
            command_signup.CommandText = "select ID from DEPARTMENT where Name = @name";
            command_signup.Parameters.AddWithValue("@name", department);
            var reader = command_signup.ExecuteReader();
            if (reader.Read())
            {
                departmentid = reader.GetInt32(0);
            }
            else
            {
                departmentid = 1;
            }
            
            return departmentid;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                fillDropDownList();
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

        protected void btn_signup_enter_Click(object sender, EventArgs e)
        {
            username = txt_signup_name.Text;
            email = txt_signup_mail.Text;
            password = txt_signup_password.Text;
            gender = check_signup_gender_lady.Checked;
            department = ddl_signup_department.SelectedItem.Text;
            int departmentid = getDepartmentId(department);

            var connection_signup = new SqlConnection(connectionStrings.bedir);
            var command_signup = connection_signup.CreateCommand();
            connection_signup.Open();
            command_signup.CommandText = "insert into WRITER (Name, Email, Password, Gender, DepartmentID) values (@name, @email, @password, @gender, @department)";
            command_signup.Parameters.AddWithValue("@name", username);
            command_signup.Parameters.AddWithValue("@email", email);
            command_signup.Parameters.AddWithValue("@password", password);
            command_signup.Parameters.AddWithValue("@gender", gender);
            command_signup.Parameters.AddWithValue("@department", departmentid);
            try{
                var writer = command_signup.ExecuteNonQuery(); }
              catch(Exception ex)
            {
                lbl_signup_warning.Text = ex.Message.ToString();
            }
            connection_signup.Close();
            Session.Add("username", username);
            Response.Redirect("/default.aspx");
            //Response.Redirect("/User/MyAccount.aspx");
            
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
    }
}