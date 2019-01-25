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
    public partial class MyProfile : System.Web.UI.Page
    {
        String Name;
        List<int> FollowedIDs=new List<int>(new int[0]);
        List<int> FavsIDs = new List<int>(new int[0]);

        //public class Data
        //{

        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            int index = 0;
           
            object user = Session["username"];
            if (user == null) { Response.Redirect("/User/Login.aspx"); }
            else {
                    String name = user.ToString();
            Name = name;
                btn_default_profile.Text = user.ToString();
                btn_default_loginout.Text = "çıkış yap";
            }
           
            if (!this.IsPostBack)
            {
                loadSolKanat();
                //if (myaccount_bulletedlist.SelectedIndex < 0)
                //{
                //    myaccount_bulletedlist.SelectedIndex = index;
                //}
                //else
                //{
                //    index = myaccount_bulletedlist.SelectedIndex;
                //}
                //myentries_editbox.Text = myaccount_bulletedlist.SelectedItem.Text;
                DataSet ds_title = loadSolKanat();
                title_repeater.DataSource = ds_title;
                title_repeater.DataBind();
            }
            
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


        protected void myentries_Click(object sender, EventArgs e)
        {
            //if (!this.IsPostBack) { 
            //myaccount_bulletedlist.Items.Clear();
            //var connect_myaccount = new SqlConnection(connectionStrings.bedir);
            //var command_myaccount = connect_myaccount.CreateCommand();

            //command_myaccount.CommandText = "select Contents from ENTRY where WriterID = (select ID from WRITER where Name=@name)";
            //connect_myaccount.Open();
            //command_myaccount.Parameters.AddWithValue("@name", Name);
            //var reader = command_myaccount.ExecuteReader();
            //while (reader.Read())
            //{
            //    myaccount_bulletedlist.Items.Add(reader.GetString(0));
            //}
            //connect_myaccount.Close();
            //    //  myentries_editbox.Text = myaccount_bulletedlist.SelectedItem.Text;
            //}

        }

        protected void myfavs_Click(object sender, EventArgs e)
        {
            //myaccount_bulletedlist.Items.Clear();
            //var connect_myaccount = new SqlConnection(connectionStrings.bedir);
            //var command_myaccount = connect_myaccount.CreateCommand();

            //command_myaccount.CommandText = "select EntryID from FAVENTRY where WriterID=(select ID from WRITER where Name=@name)";
            //connect_myaccount.Open();
            //command_myaccount.Parameters.AddWithValue("@name", Name);
            //var reader = command_myaccount.ExecuteReader();
            //int i = 0;
            //while (reader.Read())
            //{
            //   FavsIDs.Add(reader.GetInt32(0));
            //    i++;
            //}
            //reader.Close();
            //var command2_myaccount = connect_myaccount.CreateCommand();
            //foreach (var item in FavsIDs)
            //{
            //    int x = item;
            //    command2_myaccount.CommandText = "select Contents from ENTRY where ID= @i";
            //    command2_myaccount.Parameters.AddWithValue("@i", x);
            //    var reader2 = command2_myaccount.ExecuteReader();
            //    while (reader2.Read())
            //    {
            //        myaccount_bulletedlist.Items.Add(reader2.GetString(0));
            //    }
            //    reader2.Close();
            //    command2_myaccount.Parameters.Clear();
            //}
            //connect_myaccount.Close();
        }


        protected void myaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/MyAccount.aspx");
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

        protected void myfollowed_Click(object sender, EventArgs e)
        {
            //myaccount_bulletedlist.Items.Clear();
            //var connect_myaccount = new SqlConnection(connectionStrings.bedir);
            //var command_myaccount = connect_myaccount.CreateCommand();

            //command_myaccount.CommandText = "select FollowedID from FOLWRITER where FollowerID=(select ID from WRITER where Name=@name)";
            //connect_myaccount.Open();
            //command_myaccount.Parameters.AddWithValue("@name", Name);
            //var reader = command_myaccount.ExecuteReader();
            //int i = 0;
            //while (reader.Read())
            //{
            //    FollowedIDs.Add(reader.GetInt32(0));
            //    i++;

            //}
            //reader.Close();
            //var command2_myaccount = connect_myaccount.CreateCommand();
            //foreach (var item in FollowedIDs)
            //{
            //    int x = item;

            //    command2_myaccount.CommandText = "select Name from WRITER where ID= @i";
            //    command2_myaccount.Parameters.AddWithValue("@i", x);
            //    var reader2 = command2_myaccount.ExecuteReader();
            //    while (reader2.Read())
            //    {
            //        myaccount_bulletedlist.Items.Add(reader2.GetString(0));
            //    }
            //    reader2.Close();
            //    command2_myaccount.Parameters.Clear();
            //}
            //connect_myaccount.Close();
        
        }

        protected void myaccount_bulletedlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //myentries_editbox.Text = myaccount_bulletedlist.SelectedItem.Text;
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