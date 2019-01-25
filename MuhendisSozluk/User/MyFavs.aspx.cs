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
    public partial class MyFavs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object user = Session["username"];

            if (user == null)
            {
                Response.Redirect("/User/Login.aspx");
            }
            if (!this.IsPostBack)
                loadEntries(user.ToString());
        }
        int getWriter(String writer)
        {
            int result = 0;
            SqlConnection con2 = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd = con2.CreateCommand();
            cmd.CommandText = "select ID from WRITER where Name=@name";
            cmd.Parameters.AddWithValue(@"name", writer);
            con2.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read()) result = reader.GetInt32(0);
            con2.Close();
            return result;

        }
        public void loadEntries(String writer)
        {
           
            DataSet ds = GetaData(writer);
            favs_entry_repeater.DataSource = ds;
           favs_entry_repeater.DataBind();
        }
        private DataSet GetaData(String writer)
        {
            int id = getWriter(writer);
            SqlConnection con3 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select * from ENTRY inner join FAVENTRY on FAVENTRY.EntryID=ENTRY.ID and FAVENTRY.WriterID=@id", con3);
            da.SelectCommand.Parameters.AddWithValue(@"id", id);
            
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        protected void rpt_myentries_save_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            int ID = Int32.Parse((item.FindControl("lbl_rpt_entry_number") as Label).Text);
            String writer = Session["username"].ToString();

            SqlConnection con3=new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd3 = con3.CreateCommand();
            cmd3.CommandText = "delete from FAVENTRY where EntryID=@eid and WriterID=@wid";
            cmd3.Parameters.AddWithValue(@"eid", ID);
            cmd3.Parameters.AddWithValue(@"wid", getWriter(writer));
            con3.Open();
            try { var deleter = cmd3.ExecuteNonQuery(); }
            catch(Exception ex) { (item.FindControl("txt_rpt_entry_content") as TextBox).Text += ex.Message.ToString(); }
            con3.Close();
            loadEntries(writer);
        }
    }
}