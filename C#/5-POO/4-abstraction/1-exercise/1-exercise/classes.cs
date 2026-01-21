abstract class Payment
{
    private double amount;
    public double Amount
    {
        get { return amount; }
        set { if (value > 0) { amount = value; } }
    }
    public abstract string Pay();
}


class CredditCarPayment : Payment
{
    public override void Pay()
    {
        int numberAcount;
        double inputAmount;
        Console.Write("Enter the number of the account: ");
        numberAcount =  Convert.ToInt32(Console.ReadLine());

        if (numberAcount == 5)
        {
            Console.Write("Enter a type of coin (USD - COP): ");
            inputAmount = Convert.ToDouble(Console.ReadLine());
            Amount = inputAmount;

            return $"-- You pay {inputAmount} --";
        }
        else { Console.WriteLine("*** Please type a valid account number (five digits) ***"); }
    }
}

class CryptoPayment : Payment
{
    public override void Pay(double amount)
    {
        string inputWalletAddress;
        bool correctWallet;
        Console.Write("Enter a wallet address: ");
        inputWalletAddress = Console.ReadLine();

        Console.Write($"Is that {inputWalletAddress} wallet address correct? (true-false): ");
        correctWallet = Convert.ToBoolean(Console.ReadLine());

        if()


    }

}