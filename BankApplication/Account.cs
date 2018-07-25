using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Account
    {
        int accountNo;
        string customerName;
        string accountType;
        int totalAmount;
        public int setAccountId()
        {
            return accountNo;
        }
        public void getAccountId(int accountId)
        {
            this.accountNo = accountId;
        }
        public string setCustomerName()
        {
            return customerName;
        }
        public void getCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string setAccountType()
        {
            return accountType;
        }
        public void getAccountType(string accountType)
        {
            this.accountType = accountType;
        }

        public int setTotalAmount()
        {
            return totalAmount;
        }
        public void SetTotalAmount(int totalAmount)
        {
            this.totalAmount += totalAmount;
        }
        public void SetWithdrawAmount(int amount)
        {
            totalAmount = amount;
        }
    }
}
