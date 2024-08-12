using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Accounts
    {
        public int AccountNo;
        public string CustomerName;
        public string AccountType;
        public char TransactionType;
        public double Amount;
        public double Balance;

        public Accounts(int accNum, string cName, string accType, char transacType, double amount, double bal)
        {
            AccountNo = accNum;
            CustomerName = cName;
            AccountType = accType;
            TransactionType = transacType;
            Amount = amount;
            Balance = bal;
        }

        public void ShowData()
        {
            Console.WriteLine($"Account Number: {AccountNo}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Account Type(Savings/Current/Salary): {AccountType}");
            Console.WriteLine($"Transaction Type(D-Deposit;W-Withdrawl): {TransactionType}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Balance: {Balance}");
        }

        public void Credit(int amount)
        {
            Balance += amount;
        }

        public void Debit(int amount)
        {
            if (Balance > amount)
                Balance -= amount;
            else
                Console.WriteLine("Insufficent Balance to withdraw");
        }



    }
    class AccountDetails
    {
        static void Main()
        {

            Console.WriteLine("Enter Account Number:");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter Account Type:");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter Transaction Type (D for deposit, W for withdrawal):");
            char transactionType = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.WriteLine("Enter Amount:");
            double amount = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Accounts ac = new Accounts(accountNumber,customerName,accountType,transactionType,amount,10000);

            //Accounts ac = new Accounts(123456, "John Doe", "Savings", 'D', 1000.00, 5000.00);

            if (ac.TransactionType == 'D')
                ac.Credit((int)ac.Amount);
            else if (ac.TransactionType == 'W')
                ac.Debit((int)ac.Amount);
            else
                Console.WriteLine("incorrect method");

            ac.ShowData();
            Console.Read();

        }
    }
}
