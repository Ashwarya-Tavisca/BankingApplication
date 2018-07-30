using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseConnectivity;
using System.Data.SqlClient;

namespace BankApplication
{
    class Account
    {

        IDbInterface obj;
        public Account()
        {
            BuildDbObject();
        }
        public void BuildDbObject()
        {
            obj = DatabaseObjectFactory.GetConnectivityObject();
        }
        
        public void Add(int clientId, string clientName, int accountType)
        {
            obj.Add(clientId, clientName, accountType);
        }
        public void Show()
        {
            obj.Show();
        }
        public void Search(int clientId)
        {
            obj.Search(clientId);
        }
        public void Deposit(int clientId, int dp)
        {
            obj.Deposit(clientId,dp);
        }
        public void Withdrawl(int clientId, int money)
        {
            obj.Withdrawl(clientId,money);
        }
        public void Interest(int clientId)
        {
            obj.Interest(clientId);
        }

    }
}
