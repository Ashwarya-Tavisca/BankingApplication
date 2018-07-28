using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnectivity;
using System.Data.SqlClient;

namespace BankApplication
{
    class Account: IdbInterface
    {
        static DatabaseConnect obj = new DatabaseConnect();
        public void add(int clientId , string clientName , int accountType)
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "Insert into clients values("+clientId+ ","+clientName+","+accountType+", "+ 0 +")";
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            cmmnd.ExecuteNonQuery();
            conn.Close();
        }
        public void Show()
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from clients");
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();  
            while(datareader.NextResult())
            {
                Console.WriteLine("Clientid:" + datareader.GetValue(0));
                Console.WriteLine("Clientname:" + datareader.GetValue(1));
                Console.WriteLine("accountType:" + datareader.GetValue(2));
                Console.WriteLine("Balance:" + datareader.GetValue(3));
            }
            conn.Close();
        }
        public void search(int clientId)
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from clients where id=" + clientId);
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            if(datareader.NextResult())
            {
                Console.WriteLine("Clientid:" + datareader.GetValue(0));
                Console.WriteLine("Clientname:" + datareader.GetValue(1));
                Console.WriteLine("accountType:" + datareader.GetValue(2));
                Console.WriteLine("Balance:" + datareader.GetValue(3));
            }
            conn.Close();
        }
        public void deposit(int clientId,int dp)
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "update users set balance=balance+"+ dp +" where id="+ clientId ;
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            cmmnd.ExecuteNonQuery();
            conn.Close();
        }
        public void withdrawl(int clientId, int money)
        {
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from clients where id=" + clientId + "";
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            int flag = 0;
            if (datareader.NextResult())
            {
                if ((int)datareader.GetValue(2) == 1 && (int)datareader.GetValue(3) < 1000)
                    flag = 0;
                else if ((int)datareader.GetValue(2) == 2 && (int)datareader.GetValue(3) < 0)
                    flag = 0;
                else if ((int)datareader.GetValue(2) == 3 && (int)datareader.GetValue(3) < -10000)
                    flag = 0;
                else
                    flag = 1;
            }
            conn.Close();

            if (flag == 0)
                Console.WriteLine("Money cannot be withdrawn");
            else
            {
                conn = obj.dbConnect();
                string query1 = "update users set balance=balance-" + money + " where id=" + clientId;
                SqlCommand commd = new SqlCommand(query1, conn);
                cmmnd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void Interest(int clientId)
        {
            int result = 0;
            SqlConnection conn = obj.dbConnect();
            string dbQuery = "select * from clients where id="+ clientId +"";
            SqlCommand cmmnd = new SqlCommand(dbQuery, conn);
            SqlDataReader datareader = cmmnd.ExecuteReader();
            if (datareader.NextResult())
            {
                int balance = (int)datareader.GetValue(3);
                int account = (int)datareader.GetValue(2);
                if (account == 1)
                   result=  balance * 4 / 100;
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
