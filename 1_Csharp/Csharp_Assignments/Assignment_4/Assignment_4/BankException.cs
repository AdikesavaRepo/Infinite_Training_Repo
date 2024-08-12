using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    using System;
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base()
        {
        }

        public InsufficientBalanceException(string message) : base(message)
        {
        }

        public InsufficientBalanceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class Accounts
    {
        public int AccountNo;
        public string CustomerName;
        public string AccountType;
        public double Balance;

        public Accounts(int accNum, string cName, string accType, double bal)
        {
            AccountNo = accNum;
            CustomerName = cName;
            AccountType = accType;
            Balance = bal;
        }

        public void ShowData()
        {
            //Console.WriteLine($"Account Number: {AccountNo}");
            //Console.WriteLine($"Customer Name: {CustomerName}");
            //Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: ${Balance}");
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Successfully deposited ${amount}. New balance: ${Balance}");
            }
            else
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
        }
        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    Console.WriteLine($"Successfully withdrew ${amount}. New balance: ${Balance}");
                }
                else
                {
                    throw new InsufficientBalanceException("Insufficient balance to withdraw.");
                }
            }
            else
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
        }
    }

    class BankException
    {
        static void Main()
        {
            Console.WriteLine("Welcome");
            Accounts ac = new Accounts(123456, "AADI", "Savings", 5000.00);

            try
            {
                Console.Write("Enter amount to deposit: $");
                double depositAmount = double.Parse(Console.ReadLine());
                ac.Deposit(depositAmount);
                Console.Write("Enter amount to withdraw: $");
                double withdrawAmount = double.Parse(Console.ReadLine());
                ac.Withdraw(withdrawAmount);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Exception: {ex.Message}");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Insufficient Balance Exception: {ex.Message}");
            }
            ac.ShowData();

            Console.WriteLine("\nThank you for using the Banking System!");
            Console.ReadLine();
        }
    }
}
