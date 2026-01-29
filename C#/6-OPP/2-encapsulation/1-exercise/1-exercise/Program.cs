/*
Create a class Animal.
The attributes name and age must be private.
Create methods to set the name and age.
Do not allow negative age.
Create a method ShowInfo() that prints the information. 
 */

class Animal
{
    private string name;
    private int age;

    public void SetName(string value)
    {
        name = value;
    }

    public void SetAge(int value)
    {

        if (value > 0)
        {
            age = value;
        }
        else
        {
            Console.WriteLine("Invalid age");
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"\nName: {name} \nAge: {age}");
    }


    static void Main(string[] args)
    {
        Animal animalOne = new Animal();

        animalOne.SetName("Roco");
        Console.Write("Enter an age: ");
        animalOne.SetAge(Convert.ToInt32(Console.ReadLine()));

        animalOne.ShowInfo();

        Console.ReadKey();
    }
}


