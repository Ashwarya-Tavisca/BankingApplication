using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public interface IDbInterface
    {
        void Add(int clientId, string clientName, int accountType);
        void Show();
        void Search(int clientId);
        void Deposit(int clientId, int dp);
        void Withdrawl(int clientId, int money);
        void Interest(int clientId);
    }
}
