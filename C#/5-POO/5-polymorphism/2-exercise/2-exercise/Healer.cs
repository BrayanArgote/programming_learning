class Healer : Character
{
    public Healer(string name) : base(name) { }

    public new void Attack(double amountToHeal)
    {
        if (Health > amountToHeal)
        {
            Health = Health - amountToHeal;
            Console.WriteLine($"\n*** All character +{amountToHeal}* of health ***" +
                              $"\n**Your actual health {Health}**");
        }
        else {
            Console.WriteLine("\n*You don't have sufficiente health*" +
                            $"\nActual health *{Health}*");
        }
    }
}