using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
        public static void accountDetails(Account[] obj)
        {
            int index = getId(obj);
            Console.WriteLine("Your Account Id:" + obj[index].setAccountId());
            Console.WriteLine("Account Holder Name:" + obj[index].setCustomerName());
            Console.WriteLine("Account Type:" + obj[index].setAccountType());
            Console.WriteLine("Balance:" + obj[index].setTotalAmount());
        }
        public static int getId(Account[] accobject)
        {
            Console.WriteLine("Enter the Account Number- ");
            int accountNumber = int.Parse(Console.ReadLine());
            int aNo=-1;
            for (int index = 0; index < accobject.Length; index++)
            {
                if (accountNumber == accobject[index].setAccountId())
                {
                    aNo = index; 
                }
                else
                {
                    aNo = -1;
                    Console.WriteLine("Please enter a valid account!");
                }
            }
            return aNo;
        }
        public static void depositAmount(Account[]obj)
        {
            int index = getId(accObject);
            if (index!= -1)
                {
                    Console.WriteLine("Enter the amount to be deposited- ");
                    int depositamount = int.Parse(Console.ReadLine());
                    accObject[index].SetTotalAmount(depositamount);
                    Console.WriteLine("Your balance after depositing- ");
                    Console.WriteLine(accObject[index].setTotalAmount());
                }
        }
        public static void withdraw(Account[] obj)
        {
            int index = getId(obj);

            if (obj[index].setAccountType().Equals("Savings") && obj[index].setTotalAmount() < 1000)
            {
                Console.WriteLine("Balance is NULL! ");
                Console.WriteLine("Balance should be greater than 1000. Deposit money!");

            }
            else if (obj[index].setAccountType().Equals("Current") && obj[index].setTotalAmount() < 0)
            {
                Console.WriteLine("Balance is NULL! ");
                Console.WriteLine("Balance should be greater than 0. Deposit money!");
            }
            else if (obj[index].setAccountType().Equals("DMAT") && obj[index].setTotalAmount() < -10000)
            {
                Console.WriteLine("Balance cannot be less than -10000. Withdrawl cannot be completed!");
            }
            else
            {
                Console.WriteLine("Enter Amount To Be Withdrawn from the account- ");
                int withdrawlAmount = int.Parse(Console.ReadLine());
                obj[index].SetWithdrawAmount(obj[index].setTotalAmount() - withdrawlAmount);
                Console.WriteLine("Your balance after withdrawl- ");
                Console.WriteLine(accObject[index].setTotalAmount());

            }
        }


        public static void calculateInterest(Account[] obj)
        {
            int index = getId(obj);
            float interest = 0.0f;
            if (obj[index].setAccountType().Equals("Savings"))
            {
                interest = (float)((obj[index].setTotalAmount() * 4f) / 100f);
                Console.WriteLine("Interest- " + interest);
                Console.WriteLine("After adding interest the amount becomes- " + (obj[index].setTotalAmount() + interest));
            }

            else if (obj[index].setAccountType().Equals("Current"))
            {
                interest = (float)((obj[index].setTotalAmount() * 1f) / 100f);
                Console.WriteLine("Interest- " + interest);
                Console.WriteLine("After Interest the amount becomes- " + (obj[index].setTotalAmount() + interest));
            }

            else if (obj[index].setAccountType().Equals("DMAT"))
            {
                Console.WriteLine("Interest is not available on DMAT Account");
            }
        }
       
        static Account[] accObject;
        static void Main(string[] args)
        {

            int accountId;
            string customerName, accountType;


            Console.WriteLine("Enter the number of Accounts- ");
            int accountCount = int.Parse(Console.ReadLine());
            accObject = new Account[accountCount];
            for (int index = 0; index < accountCount; index++)
            {
                Console.WriteLine("Enter Account Id- ");
                accountId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Account Holder's Name- ");
                customerName = Console.ReadLine();
                Console.WriteLine("Enter Account Type- ");
                accountType = Console.ReadLine();


                accObject[index] = new Account();
                accObject[index].getAccountId(accountId);
                accObject[index].getCustomerName(customerName);
                accObject[index].getAccountType(accountType);


            }
            int flag = 1;
            do
            {
                Console.WriteLine("\nPlease press the following number according to your need");
                Console.WriteLine( "1>To check Account Details\n2>Search by Account ID \n3>To deposit money\n4>To withdraw money\n5>To Calulate Interest on an account(Not applicable on DMAT accounts) \n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        accountDetails(accObject);
                        break;
                    case 2:
                        int accountNumber = getId(accObject);
                        Console.WriteLine("Your Account Id:" + accObject[accountNumber].setAccountId());
                        Console.WriteLine("Account Holder's Name:" + accObject[accountNumber].setCustomerName());
                        Console.WriteLine("Account Type:" + accObject[accountNumber].setAccountType());
                        Console.WriteLine("Account amount:" + accObject[accountNumber].setTotalAmount());
                        break;

                    case 3:
                        depositAmount(accObject);
                        break;
                    case 4:
                        withdraw(accObject);
                        break;
                    case 5:
                        calculateInterest(accObject);
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;

                }
                Console.WriteLine("Enter 1 to Continue and 0 To Stop :- ");
                flag = int.Parse(Console.ReadLine());
            }while (flag == 1);
            Console.ReadKey();
        }
    }
}
