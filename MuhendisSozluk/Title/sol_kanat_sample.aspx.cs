using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MuhendisSozluk.Title
{
    public partial class sol_kanat_sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = GetaData();
            title_repeater.DataSource = ds;
            title_repeater.DataBind();
        }
        private DataSet GetaData()
        {
           // String name = lbl_title_name.Text;
            SqlConnection con = new SqlConnection(connectionStrings.bedir);
            SqlDataAdapter da = new SqlDataAdapter(@"select top 25 Name, Today from TITLE where Visible='True' order by LastUpdate asc", con);
            //da.SelectCommand.Parameters.AddWithValue(@"name", name);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}