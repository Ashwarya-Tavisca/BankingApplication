using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class DatabaseConnect
    {
         public SqlConnection dbConnect()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source = TAVDESK045 ; Initial Catalog = BankingDatabase ; Integrated Security = true";
                conn.Open();
                return conn;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return conn;
            }
        }

    }
}
