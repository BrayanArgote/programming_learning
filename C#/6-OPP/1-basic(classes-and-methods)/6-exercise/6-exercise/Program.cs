/* Create a class Car with attributes brand, color, and year.

Create three constructors:
- Default constructor that sets brand="Unknown", color = "White", year = 2000.
- Constructor with brand and color.
- Constructor with brand, color, and year.

In Main, create 3 cars using each constructor and print their attributes.
*/

class Car
{
    string brand;
    string color;
    int year;

    Car()
    {
        brand = "Unknown";
        color = "White";
        year = 2000;
    }

    Car(string brand, string color)
    {
        this.brand = brand;
        this.color = color;
        year = 2000;
    }

    Car(string brand, string color, int year)
    {
        this.brand = brand;
        this.color = color;
        this.year = year;
    }

    void ShowInfo()
    {
        Console.WriteLine($"\nBrand: {brand} \n" +
                          $"Color: {color} \n" +
                          $"Year: {year}");
    }

    static void Main(string[] args)
    {
        Car carOne = new Car();
        Car carTwo = new Car("Ford", "Yellow");
        Car carThree = new Car("Toyota", "Black", 2021);

        carOne.ShowInfo();
        carTwo.ShowInfo();
        carThree.ShowInfo();

        Console.ReadKey();
    }
}
