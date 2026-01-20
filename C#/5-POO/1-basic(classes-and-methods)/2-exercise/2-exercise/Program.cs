/*
Create a class Car with attributes brand and color.
Add a method Drive() that prints: "The [color] [brand] is driving."
Create 3 cars in Main and call Drive() for each one.
 */

class Car
{
    string color;
    string brand;


    void Drive()
    {
        Console.WriteLine($"The {color} {brand} is driving.");
    }

    static void Main(string[] args)
    {
        Car carOne = new Car();
        carOne.color = "white";
        carOne.brand = "toyota";
        carOne.Drive();

        Car carTwo = new Car();
        carTwo.color = "red";
        carTwo.brand = "ferrari";
        carTwo.Drive();

        Car carThree = new Car();
        carThree.color = "blue";
        carThree.brand = "ford";
        carThree.Drive();

        Console.ReadKey();
    }
}
