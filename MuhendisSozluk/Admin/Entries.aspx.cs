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
    public partial class Entries : System.Web.UI.Page
    {
       

        //static String name_unchanged;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                object user = Session["username"];
                if (user == null)

                {
                    Response.Redirect("/Admin/AdminLogin.aspx");

                }
                else
                {

                    loadAllEntries();

                    //all_titles_listbox_SelectedIndexChanged(sender, e);
                }
            }
        }

        private void loadAllEntries()
        {

            all_entries_listbox.Items.Clear();

            var c2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = c2.CreateCommand();
            cmd2.CommandText = "select ID from ENTRY order by Date desc";
            c2.Open();
            var rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                all_entries_listbox.Items.Add("#"+rdr2.GetInt32(0).ToString());
            }
            c2.Close();
        }

        protected void all_entries_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ID = Int32.Parse(all_entries_listbox.SelectedItem.ToString().Substring(1));
           // name_unchanged = name;
            //int departmentID;
            SqlConnection c0 = new SqlConnection(connectionStrings.bedir);
            SqlCommand cmd = c0.CreateCommand();
            cmd.CommandText = "select * from Entry where ID= @id";
            cmd.Parameters.AddWithValue(@"id", ID);
            c0.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbl_entry_number.Text = "#"+reader.GetInt32(0).ToString();
                txt_entry_contents.Text = reader.GetString(1);
                lbl_entry_date.Text = reader.GetDateTime(7).ToString();
                lbl_entry_like.Text = reader.GetInt32(3).ToString();
                lbl_entry_dislike.Text = reader.GetInt32(4).ToString();
                lbl_entry_fav.Text = reader.GetInt32(2).ToString();
                lbl_entry_rating.Text = reader.GetDouble(6).ToString();
                lbl_entry_visible.Text = evetHayir(reader.GetBoolean(5));
            }
            reader.Close();
            c0.Close();
        }
        protected String evetHayir(Boolean x)
        {
            if (x) return "Evet";
            return "Hayır";
        }

        protected void btn_entry_delete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(lbl_entry_number.Text.Substring(1));
            var c2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = c2.CreateCommand();
            cmd2.CommandText = "delete from ENTRY where ID=@id";
            cmd2.Parameters.AddWithValue(@"id", id);
            c2.Open();
            try
            {
                var rdr2 = cmd2.ExecuteNonQuery();
                lbl_entry_save_status.Text = "entry başarıyla imha edildi.";
            }
            catch(Exception ex)
            {
                lbl_entry_save_status.Text = ex.Message.ToString();
            }
            c2.Close();
        }

        protected void btn_entry_hide_Click(object sender, EventArgs e)
        {
            Boolean x = false;
            int id = Int32.Parse(lbl_entry_number.Text.Substring(1));
            String content = txt_entry_contents.Text;
            var c2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = c2.CreateCommand();
            if (lbl_entry_visible.Text == "Evet")
            {
                cmd2.CommandText = "update ENTRY set Contents= @content, Visible ='False' where ID=@id"; x = true;
            }
            else { cmd2.CommandText = "update ENTRY set Contents=@content, Visible='True' where ID=@id"; }
            cmd2.Parameters.AddWithValue(@"id", id);
            cmd2.Parameters.AddWithValue(@"content", content);
            c2.Open();
            try
            {
                var rdr2 = cmd2.ExecuteNonQuery();
                if (x) 
                lbl_entry_save_status.Text = "entry başarıyla gizlendi.";
                else lbl_entry_save_status.Text = "entry başarıyla göründürüldü";
            }
            catch (Exception ex)
            {
                lbl_entry_save_status.Text = ex.Message.ToString();
            }
            c2.Close();
        }

        protected void btn_entry_save_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(lbl_entry_number.Text.Substring(1));
            String content = txt_entry_contents.Text;
            var c2 = new SqlConnection(connectionStrings.bedir);
            var cmd2 = c2.CreateCommand();
           
                cmd2.CommandText = "update ENTRY set Contents= @content where ID=@id"; 
            cmd2.Parameters.AddWithValue(@"id", id);
            cmd2.Parameters.AddWithValue(@"content", content);
            c2.Open();
            try
            {
                var rdr2 = cmd2.ExecuteNonQuery();
                lbl_entry_save_status.Text = "entry başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                lbl_entry_save_status.Text = ex.Message.ToString();
            }
            c2.Close();
        }
    }
}