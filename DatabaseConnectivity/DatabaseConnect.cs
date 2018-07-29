using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class DatabaseConnect:IDbInterface
    {
        static DatabaseConnect obj = new DatabaseConnect();
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
        public void Add(int clientId, string clientName, int accountType)
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "Insert into client(clientid,clientname,acctype,money) values(" + clientId + ",'" + clientName + "'," + accountType + ", " + 0 + ")";
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            cmmnd.ExecuteNonQuery();
            conn.Close();
        }
        public void Show()
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from client";
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            while (datareader.Read())
            {
                Console.WriteLine("Clientid:" + datareader.GetValue(0));
                Console.WriteLine("Clientname:" + datareader.GetValue(1));
                Console.WriteLine("accountType:" + datareader.GetValue(2));
                Console.WriteLine("Balance:" + datareader.GetValue(3));
            }
            conn.Close();
        }
        public void Search(int clientId)
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from client where clientid=" + clientId;
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            if (datareader.Read())
            {
                Console.WriteLine("Clientid:" + datareader.GetValue(0));
                Console.WriteLine("Clientname:" + datareader.GetValue(1));
                Console.WriteLine("accountType:" + datareader.GetValue(2));
                Console.WriteLine("Balance:" + datareader.GetValue(3));
            }
            conn.Close();
        }
        public void Deposit(int clientId, int dp)
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "update client set money=money+" + dp + " where clientid=" + clientId;
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            cmmnd.ExecuteNonQuery();
            conn.Close();
        }
        public void Withdrawl(int clientId, int money)
        {
            int bal = Balance(clientId);
            int accType = AccType(clientId);
            if (accType == 1 && bal < 1000)
                Console.WriteLine("Insufficient Balance");
            else if (accType == 2 && bal < 0)
                Console.WriteLine("Insufficient Balance");
            else if (accType == 3 && bal < -10000)
                Console.WriteLine("Insufficient Balance");
            else
            {
                SqlConnection conn = obj.dbConnect();
                string query = "update client set money=money-" + money + " where clientid=" + clientId;
                SqlCommand cmmnd = new SqlCommand(query, conn);
                cmmnd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public static int Balance(int clientid)
        {
            int sum = 0;
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from client where clientid=" + clientid;
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            if (datareader.Read())
            {
                sum = ((int)datareader.GetValue(3));
            }
            conn.Close();
            return sum;
        }
        public static int AccType(int clientid)
        {
            int type = -1;
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from client where clientid=" + clientid;
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            if (datareader.Read())
            {
                type = ((int)datareader.GetValue(2));
            }
            conn.Close();
            return type;
        }
        public void Interest(int clientId)
        {
            int result = 0;
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from client where clientid=" + clientId;
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            if (datareader.Read())
            {
                int balance = (int)datareader.GetValue(3);
                int account = (int)datareader.GetValue(2);
                if (account == 1)
                    result = balance * 4 / 100;
                else if (account == 2)
                    result = balance * 1 / 100;
                else
                    Console.WriteLine("Invalid");
            }
            Console.WriteLine(result);
            conn.Close();
        }

    }
}
