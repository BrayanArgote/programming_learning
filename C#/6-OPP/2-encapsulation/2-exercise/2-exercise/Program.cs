/*
Create a class BankAccount.
The attribute balance must be private.

Create methods Deposit(double amount) and Withdraw(double amount).
Do not allow withdraw if the amount is greater than the balance.
Create a method ShowBalance().
 */


class BankAccount
{
    private double balance;

    public BankAccount()
    {
        balance = 100;
    }

    public void Deposit(double amount)
    {
       if (amount > 0)
        {
            balance = balance + amount;
        }

        else
        {
            Console.WriteLine("Invalid amount");
        }
       ShowBalance();
    }

    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance = balance - amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
        ShowBalance();
    }

    public void ShowBalance()
    {
        Console.WriteLine("Balance: " + balance);
    }

    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        account.ShowBalance(); //100
        account.Deposit(100);  //200

        account.Withdraw(50);  //150

        account.Deposit(-9);   //150

        account.Withdraw(500); //150

        Console.ReadKey();
    }
}