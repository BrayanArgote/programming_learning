/*
Create a base class that represents a Vehicle.
It must store common data like speed and brand.

Then create a child class Car that adds its own data and behavior.

Use the data from the base class correctly.

Add at least one new behavior.
 */

class Vehicle
{
    private double speed;
    public double Speed
    {
        get { return speed; }
        set {
            if (value > 0) {
                speed = value;
            }
        }
    }
    private string brand;

    public string Brand
    {
        get { return brand; }
        set
        {
            if (value != null)
            {
                brand = value;
            }
        }
    }
}

class Car : Vehicle
{
    
    public void Acelerate()
    {
        Speed = Speed + 10;
        Console.WriteLine($"The car has accelerated {Speed}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car c = new Car();
        c.Speed = 100;
        c.Brand = "Toyota";

        Console.WriteLine("\n== DATA ==" +
                         $"\nSpend: {c.Speed}" +
                         $"\nBrand: {c.Brand}");
        c.Acelerate();
      
        Console.ReadKey();
    }
}


