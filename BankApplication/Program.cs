using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
       
       
        static Account accObject;
        static void Main(string[] args)
        {

            int accountId,accountType ;
            string customerName;
            int money;

            Console.WriteLine("Enter the number of Accounts- ");
            int accountCount = int.Parse(Console.ReadLine());
            accObject = new Account();
            for (int index = 0; index < accountCount; index++)
            {
                Console.WriteLine("Enter Account Id- ");
                accountId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Account Holder's Name- ");
                customerName = Console.ReadLine();
                Console.WriteLine("Enter Account Type- ");
                accountType = int.Parse(Console.ReadLine());
                accObject.add(accountId, customerName,accountType);


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
                        accObject.Show();
                        break;
                    case 2:
                        int accountNumber = int.Parse(Console.ReadLine());
                        accObject.search(accountNumber);
                        break;

                    case 3:
                        Console.WriteLine("Enter your account number:-");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount:-");
                        money = Convert.ToInt32(Console.ReadLine());
                        accObject.deposit(accountNumber,money);
                        break;
                    case 4:
                        Console.WriteLine("Enter your account number:-");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter amount:-");
                        money = Convert.ToInt32(Console.ReadLine());
                        accObject.withdrawl(accountNumber, money);
                        break;
                    case 5:
                        Console.WriteLine("Enter your account number:-");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        accObject.Interest(accountNumber);
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
