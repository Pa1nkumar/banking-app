namespace BankingApplication;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("enter intital amount");
        double initialAmount=Convert.ToDouble(Console.ReadLine());
        Account myAccount = new Account(accountNumber: 12345, customerName: "John Doe", initialAmount);

            
        myAccount.UnderBalance += (balance) => Console.WriteLine($"Balance is below 100. Current balance: {balance}");
        myAccount.BalanceZero += () => Console.WriteLine("Balance reached zero!");
       
        Console.WriteLine("your initial balance amount"+initialAmount);            
            myAccount.Deposit(50); 
            myAccount.Withdraw(140);
    }    
}
