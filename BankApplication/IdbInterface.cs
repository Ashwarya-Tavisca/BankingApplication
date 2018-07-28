using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    interface IdbInterface
    {
         void add(int clientId, string clientName, int accountType);
         void Show();
         void search(int clientId);
         void deposit(int clientId, int dp);
         void withdrawl(int clientId, int money)
    }
}
