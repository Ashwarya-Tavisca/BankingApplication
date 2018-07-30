using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public class Entity : IDbInterface
    {
        static Entity obj = new Entity();
        static BankingDatabaseEntities bankingDatabaseEntities = new BankingDatabaseEntities();
        static client user = new client();
            
        public void Add(int clientId, string clientName, int accountType)
        {
            user.clientid = clientId;
            user.clientname = clientName;
            user.acctype = accountType;
            user.money = 0;
            bankingDatabaseEntities.clients.Add(user);
            bankingDatabaseEntities.SaveChanges();
        }
        public void Show()
        {
            List<client> accounts = new List<client>();
            accounts = bankingDatabaseEntities.clients.ToList();
            foreach (client account in accounts)
            {
                Console.WriteLine("\nAccount Id={0}       {1}            {2}         Balance={3}\n", account.clientid, account.clientname, account.acctype, account.money);
                
            }
        }

        public void Search(int clientId)
        {
            try
            {
                Console.WriteLine("Account Id   - ",bankingDatabaseEntities.clients.Find(clientId).clientid);
                Console.WriteLine("Name         - ",bankingDatabaseEntities.clients.Find(clientId).clientname);
                Console.WriteLine("Account Type - ", bankingDatabaseEntities.clients.Find(clientId).acctype);
                Console.WriteLine("Balance      - ", bankingDatabaseEntities.clients.Find(clientId).money);
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
            }
        }
        public void Deposit(int clientId, int dp)
        {
            bankingDatabaseEntities.clients.Find(clientId).money = bankingDatabaseEntities.clients.Find(clientId).money + dp;
            bankingDatabaseEntities.SaveChanges();

        }
        public void Withdrawl(int clientId, int money)
        {
            bankingDatabaseEntities.clients.Find(clientId).money = bankingDatabaseEntities.clients.Find(clientId).money - money;
            bankingDatabaseEntities.SaveChanges();
        }
        public void Interest(int clientId)
        {
            int result = 0;
            int prevBal = bankingDatabaseEntities.clients.Find(clientId).money;
            int type = bankingDatabaseEntities.clients.Find(clientId).acctype;
            if (type == 1)
                result = prevBal * 4 / 100;
            else if (type == 2)
                result = prevBal * 1 / 100;
            else
                Console.WriteLine("Invalid");
            Console.WriteLine(result);
        }

    }
}
