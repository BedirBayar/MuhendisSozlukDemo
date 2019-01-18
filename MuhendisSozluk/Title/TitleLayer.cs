using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MuhendisSozluk.Title
{
    public class TitleLayer
    {
        //private DateTime lastUpdate;
        private static SqlConnection Conn = new SqlConnection(@"data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True; ");
        public static void setTitleUpdate(int Title)
        {
            SqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "update TITLE set LastUpdate = @date where ID=@title";
            cmd.Parameters.AddWithValue(@"date", DateTime.Now);
            cmd.Parameters.AddWithValue(@"title", Title);
            Conn.Open();
            try { 
            var exec = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                
            }
            Conn.Close();

        }
        
    }
}