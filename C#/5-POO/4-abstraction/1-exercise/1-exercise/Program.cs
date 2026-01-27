/*
Create an abstract class called Appliance.
It must have: Name and Power.
It must have an abstract method called TurnOn.

Create two classes: Fan and WashingMachine.
Each class must implement TurnOn with its own simple behavior.
 */


class Program
{
    static void Main(string[] args)
    {
        WashingMachine wm = new WashingMachine("w1", 20);
        Console.WriteLine(wm.TurnOn());

        Fan f = new Fan("f1", 5);
        Console.WriteLine(f.TurnOn());

        Console.ReadKey();
    }
}




