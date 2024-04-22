using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class Account
    {
        public int AccountNumber{get;set;}
        public string CustomerName{get;set;}
        public double Balance;

        public Account(int accountNumber, string customerName, double initialBalance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = initialBalance;
        }

        // Method to deposit money into the account
        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("Amount "+amount+ " deposited successfully. Current balance: "+Balance);
        }
        public delegate void UnderBalanceDelegate(double amount);
        public event UnderBalanceDelegate UnderBalance; // Raised when balance is less than a certain amount
        public delegate void BalanceZeroDelegate();
        public event BalanceZeroDelegate BalanceZero;

        public void Withdraw(double amount)
        {
            if (Balance <amount){
                 Console.WriteLine("Insufficient funds. Transaction canceled.");
            }
            else{   
                Balance -= amount;
                Console.WriteLine($"Withdrawn amount "+amount+". New balance: "+Balance);
                if(Balance < 100 && Balance!=0){
                    UnderBalance?.Invoke(Balance); // Raise UnderBalance event
                }
                if(Balance == 0){
                     BalanceZero?.Invoke(); // Raise BalanceZero event
                }
            }
        }
    }
}