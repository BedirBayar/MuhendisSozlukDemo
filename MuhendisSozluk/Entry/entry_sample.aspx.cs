using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace MuhendisSozluk.Entry
{
    public partial class entry_sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = GetaData();
            entry_repeater.DataSource = ds;
            entry_repeater.DataBind();
        }
        private DataSet GetaData()
        {
            String name = lbl_title_name.Text;
            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select * from ENTRY where TitleName=@name and Visible='True'",con);
            da.SelectCommand.Parameters.AddWithValue(@"name", name);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}