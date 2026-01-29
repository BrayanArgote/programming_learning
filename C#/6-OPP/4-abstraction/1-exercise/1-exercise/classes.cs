abstract class Appliance
{
    private string name;
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value)) { name = value; }
            else { name = "unknown"; }
        }
    }
        
    private double power;
    public double Power
    {
        get { return power; }
        set { 
            if (value > 0) { power = value; }
            else { power = 0; } }
    }

    public Appliance(string name, int power)
    {
        Name = name;
        Power = power;
    }
    public abstract string TurnOn();
}

class WashingMachine : Appliance
{
    public WashingMachine(string name, int power) : base(name, power) { }
    public override string TurnOn()
    {
        double amountWater, amountSoap;

        Console.Write("Enter the amount of water: ");
        amountWater = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the soap: ");
        amountSoap = Convert.ToDouble(Console.ReadLine());

        if (amountWater > 0 && amountSoap > 0)
        {
            return "== Turning on the washing machine ==";
        }
        else
        {
            return "*** Failded to turn on the washing machine ***";
        }
    }
}


class Fan : Appliance
{
    public Fan(string name, int power) : base(name, power) { }
    public override string TurnOn()
    {
        int speed;
        Console.Write("Enter the speed (1 - 2 - 3 - 4 - 5): ");
        speed = Convert.ToInt32(Console.ReadLine());

        return "=== Turning on the fan ===";
    }
}