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
    public partial class MyEntries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object user = Session["username"];

            if (user == null)
            {
                Response.Redirect("/User/Login.aspx");
            }
           if(!this.IsPostBack)
            loadEntries(user.ToString(),true);
        }

        public void loadEntries(String writer, Boolean visible)
        {
            DataSet ds = GetaData(writer,visible);
            myentries_entry_repeater.DataSource = ds;
            myentries_entry_repeater.DataBind();
        }
        private DataSet GetaData(String writer, Boolean visible)
        {
            SqlConnection con1 = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select * from ENTRY where WriterName=@name and Visible=@visible", con1);
            da.SelectCommand.Parameters.AddWithValue(@"name", writer);
            da.SelectCommand.Parameters.AddWithValue(@"visible", visible);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        protected void rpt_myentries_save_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            String edited_entry = (item.FindControl("txt_rpt_entry_content") as TextBox).Text;
            int ID = Int32.Parse((item.FindControl("lbl_rpt_entry_number") as Label).Text);
            saveNewEntry(edited_entry, ID,item);
        }

        private void saveNewEntry(String edited_entry, int id, RepeaterItem item)
        {
            int x = 0;
            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "update ENTRY set Contents =@entry where ID=@id";
            cmd.Parameters.AddWithValue(@"entry", edited_entry);
            cmd.Parameters.AddWithValue(@"id", id);
            con.Open();
            try
            {
                var updater = cmd.ExecuteNonQuery();
                x = 1;
            }catch(Exception ex)
            {
                (item.FindControl("txt_rpt_entry_content") as TextBox).Text += ex.Message.ToString();
            }
            con.Close();
            if (x == 1)
            {
                btn_myentries_visible.BackColor = System.Drawing.Color.Aqua;
                btn_myentries_visible.ForeColor = System.Drawing.Color.Gray;
                btn_myentries_hidden.BackColor = System.Drawing.Color.Gray;
                btn_myentries_hidden.ForeColor = System.Drawing.Color.White;
                loadEntries(Session["username"].ToString(), true);
            }
        }

        protected void rpt_myentries_delete_Click(object sender, EventArgs e)
        {
            int x = 0;
            
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            int id = Int32.Parse((item.FindControl("lbl_rpt_entry_number") as Label).Text);

            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd = con.CreateCommand();
            
            cmd.CommandText = "delete from ENTRY where ID=@id";
            cmd.Parameters.AddWithValue(@"id", id);
            con.Open();
            try
            {
                var deleter = cmd.ExecuteNonQuery();
                x = 1;
            }
            catch (Exception ex)
            {
                (item.FindControl("txt_rpt_entry_content") as TextBox).Text += ex.Message.ToString();
            }
            con.Close();
            if (x == 1)
            {
                btn_myentries_visible.BackColor = System.Drawing.Color.Aqua;
                btn_myentries_visible.ForeColor = System.Drawing.Color.Gray;
                btn_myentries_hidden.BackColor = System.Drawing.Color.Gray;
                btn_myentries_hidden.ForeColor = System.Drawing.Color.White;
                loadEntries(Session["username"].ToString(), true);
            }
        }

        protected void rpt_myentries_hide_Click(object sender, EventArgs e)
        {
            int x = 0;
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            String edited_entry = (item.FindControl("txt_rpt_entry_content") as TextBox).Text;
            int id = Int32.Parse((item.FindControl("lbl_rpt_entry_number") as Label).Text);

            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update ENTRY set Contents =@entry, Visible = ~Visible where ID=@id";
            cmd.Parameters.AddWithValue(@"entry", edited_entry);
            cmd.Parameters.AddWithValue(@"id", id);
            con.Open();
            try
            {
                var deleter = cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                (item.FindControl("txt_rpt_entry_content") as TextBox).Text += ex.Message.ToString();
            }
            con.Close();
            if(btn_myentries_visible.BackColor == System.Drawing.Color.Aqua)
            {
                btn_myentries_visible_Click(sender, e);
            }
            else
            {
                btn_myentries_hidden_Click(sender, e);
            }
        }

        protected void btn_myentries_visible_Click(object sender, EventArgs e)
        {
            btn_myentries_visible.BackColor = System.Drawing.Color.Aqua;
            btn_myentries_visible.ForeColor = System.Drawing.Color.Gray;
            btn_myentries_hidden.BackColor = System.Drawing.Color.Gray;
            btn_myentries_hidden.ForeColor = System.Drawing.Color.White;
            loadEntries(Session["username"].ToString(),true);
        }

        protected void btn_myentries_hidden_Click(object sender, EventArgs e)
        {
            btn_myentries_hidden.BackColor = System.Drawing.Color.Tomato;
            btn_myentries_hidden.ForeColor = System.Drawing.Color.Gray;
            btn_myentries_visible.BackColor = System.Drawing.Color.Gray;
            btn_myentries_visible.ForeColor = System.Drawing.Color.White;
            loadEntries(Session["username"].ToString(), false);
        }
    }
        
    }