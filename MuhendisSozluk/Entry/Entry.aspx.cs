using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuhendisSozluk.Entry
{
    public partial class Entry : System.Web.UI.Page
    {
        String con = connectionStrings.bedir;
        static int number2 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                object user = Session["username"];
                if (user != null)
                {
                    btn_default_profile.Text = "makamım";
                    btn_default_loginout.Text = "çıkış yap";

                }
                else
                {
                    btn_default_profile.Text = "kayıt ol";
                    btn_default_loginout.Text = "giriş yap";
                }

                if (RouteData.Values["number"] != null)
                {
                    number2 = Int32.Parse(RouteData.Values["number"].ToString());
                    fill();
                   
                }
                else Response.Redirect("~/default.aspx");


            }
        }

        protected void fill()
        {
            DataSet ds_title = loadSolKanat();
            title_repeater.DataSource = ds_title;
            title_repeater.DataBind();

            loadOneEntry(number2);
        }

        public void loadOneEntry(int number)
        {
            DataSet ds = GetOneEntry(number);
            search_entry_repeater.DataSource = ds;
            search_entry_repeater.DataBind();
        }

        private DataSet GetOneEntry(int number)
        {
            SqlConnection con1 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select * from ENTRY where ID=@number", con1);
            da.SelectCommand.Parameters.AddWithValue(@"number", number);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        private DataSet loadSolKanat()
        {
            SqlConnection con2 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select Top 25 Name from TITLE where Visible='True' order by LastUpdate asc", con2);
            // da.SelectCommand.Parameters.AddWithValue(@"name", title);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        
        protected void btn_user_search_Click(object sender, EventArgs e)
        {
            String key = txt_user_search.Text;


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
            String url = "~/entry/" + Helper.SEOUrl(key);
            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            int number = Int32.Parse(key);
            var cmd = con.CreateCommand();
            cmd.CommandText = "select ID from ENTRY where ID = @number";
            cmd.Parameters.AddWithValue(@"number", number);
            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Response.Redirect(url);
            }

            else
            {
                lbl_user_search.Text = "bu entry imha edildi ya da hiç yazılmadı!";
            }
            con.Close();
        }

        protected void searchWriter(String key)
        {
            String url = "~/yazar/" + Helper.SEOUrl(key);

            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            var cmd = con.CreateCommand();
            cmd.CommandText = "select ID from WRITER where Url = @number";
            cmd.Parameters.AddWithValue(@"number", key);
            con.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Response.Redirect(url);
            }

            else
            {
                lbl_user_search.Text = "bu yazar imha edildi ya da hiç var olmadı!";
            }
            con.Close();
        }

        protected void searchTitle(String key)
        {
            
            SqlConnection con2 = new SqlConnection(connectionStrings.bedir);
            String name = Helper.SEOUrl(key);
            String url = "~/" + name;
            var cmd = con2.CreateCommand();

            cmd.CommandText = "select ID from TITLE where Url = @name";
            cmd.Parameters.AddWithValue(@"name", name);

            con2.Open();
            var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Response.Redirect(url);
            }

            else
            {
                lbl_user_search.Text = "bu başlık imha edildi ya da hiç açılmadı.";
            }
            con2.Close();
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
                if (getSeniority(user.ToString()) == 4)
                {
                    Response.Redirect("/Admin/Home.aspx");
                }
                Response.Redirect("/User/MyProfile.aspx");
            }
        }

        protected int getSeniority(String name)
        {
            int result = 0;
            SqlConnection c1 = new SqlConnection(con);
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
                user = null;
                Response.Redirect("/default.aspx");
            }

        }

    }
}