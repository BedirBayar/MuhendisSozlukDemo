using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MuhendisSozluk.Title;


namespace MuhendisSozluk
{
    public partial class _default : System.Web.UI.Page
    {
        String con = @"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True; ";
        String title2 = "";
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
                fill();
                if (RouteData.Values["TITLE"] != null)
                {
                    title2 = (RouteData.Values["TITLE"].ToString());
                    loadEntries(title2);


                }
                //loadSolKanat();


                //var connect = new SqlConnection(con);
                //var cmd = connect.CreateCommand();
                //cmd.CommandText = "select Contents from ENTRY where TitleID = (select top 1 ID from TITLE order by LastUpdate asc)";
                //connect.Open();
                //var reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    bulletedlist_entries.Items.Add(reader.GetString(0));
                //}
                //connect.Close();

                //var connect2 = new SqlConnection(con);
                //var cmd2 = connect2.CreateCommand();
                //cmd2.CommandText = "select top 1 Name from TITLE order by LastUpdate asc";
                //connect2.Open();
                //var reader2 = cmd2.ExecuteReader();
                //while (reader2.Read())
                //{
                //    lbl_default_title_name.Text=reader2.GetString(0);
                //}
                //connect2.Close();
            }
        } //default.aspx.cs
        protected void fill()
        {
            DataSet ds_title = loadSolKanat();
            title_repeater.DataSource = ds_title;
            title_repeater.DataBind();

            DataSet ds = fillEntriesFirst();
            entry_repeater.DataSource = ds;
            entry_repeater.DataBind();

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

        private DataSet loadSolKanat()
        {
            SqlConnection con2 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select Top 25 Name from TITLE where Visible='True' order by LastUpdate asc", con2);
            // da.SelectCommand.Parameters.AddWithValue(@"name", title);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void loadEntries(String url)
        {
            DataSet ds = GetaData(url);
            entry_repeater.DataSource = ds;
            entry_repeater.DataBind();
            //bulletedlist_entries.Items.Clear();

            //var connection = new SqlConnection(connectionStrings.bedir);
            //var command = connection.CreateCommand();
            //command.CommandText = "select Contents, Visible from ENTRY where TitleID = (select ID from TITLE where Name=@title) order by Date desc";
            //command.Parameters.AddWithValue("@title", title);

            //connection.Open();
            //var reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    if (reader.GetBoolean(1)) { 
            //    bulletedlist_entries.Items.Add(reader.GetString(0));
            //    }
            //}
            //connection.Close();
        }
        private DataSet GetaData(String url)
        {
            SqlConnection con1 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select * from ENTRY where TitleID=(select ID from TITLE where Url= @url)", con1);
            da.SelectCommand.Parameters.AddWithValue(@"url", url);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        private DataSet fillEntriesFirst()
        {
            SqlConnection con1 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select * from ENTRY where TitleID = (select top 1 ID from TITLE order by LastUpdate asc) and Visible='True'", con1);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //burası lissolkanat
        //protected void listSolKanat_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //        loadEntries(listSolKanat.SelectedItem.ToString());
        //    lbl_default_title_name.Text = listSolKanat.SelectedItem.ToString();


        //}



        protected void btn_entry_send_Click(object sender, EventArgs e)
        {
            object user = Session["username"];
            if (user != null)
            {
                DateTime date = DateTime.Now;
                String content = txt_write_entry.Text;
                int writerid = getWriterID(user.ToString());
                int titleid = getTitleID(lbl_default_title_name.Text);

                if (titleid != -1)
                {
                    var connect = new SqlConnection(con);
                    var cmd = connect.CreateCommand();
                    cmd.CommandText = "insert into ENTRY (Date, Contents, WriterID, WriterName, TitleID, TitleName, Visible, FavCount, LikeCount, DislCount) values (@date, @content, @writerid, @writername, @titleid, @titlename, 'True', 0, 0, 0)";
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@writerid", writerid);
                    cmd.Parameters.AddWithValue("@writername", user.ToString());
                    cmd.Parameters.AddWithValue("@titleid", titleid);
                    cmd.Parameters.AddWithValue("@titlename", lbl_default_title_name.Text);
                    connect.Open();
                    try
                    {
                        var reader = cmd.ExecuteNonQuery();
                        TitleLayer.setTitleUpdate(titleid);
                        txt_write_entry.Text = "";
                        loadEntries(lbl_default_title_name.Text);
                    }
                    catch (Exception ex)
                    {

                    }
                    connect.Close();
                }
                else
                {
                    lbl_entrysend_status.Text = "bu başlığa entry girişi durduruldu.";
                }
            }
            else
            {
                Response.Redirect("/User/Login.aspx");
            }
        }
        protected int getWriterID(String writerName)
        {
            int result;
            var connection = new SqlConnection(connectionStrings.bedir);
            var command = connection.CreateCommand();
            command.CommandText = "select ID from WRITER where Name = @name";
            command.Parameters.AddWithValue("@name", writerName);

            connection.Open();
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            else
            {
                result = 0;
            }
            connection.Close();
            return result;
        }
        protected int getTitleID(String titleName)
        {
            int result;
            var connection = new SqlConnection(connectionStrings.bedir);
            var command = connection.CreateCommand();
            command.CommandText = "select ID, IsActive from TITLE where Name=@title";
            command.Parameters.AddWithValue("@title", titleName);

            connection.Open();
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetBoolean(1))
                {
                    result = reader.GetInt32(0);
                }
                else
                {
                    result = -1;
                }
            }
            else
            {
                result = 0;
            }
            connection.Close();
            return result;

        }

        protected void btn_left_title_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            String title = btn.Text;
            loadEntries(title);
            lbl_default_title_name.Text = title;
        }

        protected void btn_title_send_Click(object sender, EventArgs e)
        {
            object user = Session["username"];

            DateTime date = DateTime.Now;
            String name = txt_write_title.Text;
            int writerid = getWriterID(user.ToString());
            String url = Helper.SEOUrl(name);


            var connect = new SqlConnection(con);
            var cmd = connect.CreateCommand();
            cmd.CommandText = "insert into TITLE (Date, Name, WriterID, Visible, IsActive, Useful, Useless, Url) values (@date, @content, @writerid, 1, 1, 0, 0, @url)";
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@content", name);
            cmd.Parameters.AddWithValue("@writerid", writerid);
            cmd.Parameters.AddWithValue("@url", url);
            connect.Open();
            try
            {
                var reader = cmd.ExecuteNonQuery();

                loadEntries(name);
            }
            catch (Exception ex)
            {
                lbl_entrysend_status.Text = ex.Message.ToString();
            }
            connect.Close();

            loadSolKanat();

        }
    }//master.cs

}