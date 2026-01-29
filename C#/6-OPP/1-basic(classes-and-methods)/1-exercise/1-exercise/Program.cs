/*
Create a class called Person with two attributes: name and age.
Add a method called Greet() that prints: "Hello, my name is [name] and I am [age] years old."
In Main, create 2 persons and call their Greet() method.
 */

class Person
{
    string name;
    int age;

    void Greet()
    {
        Console.WriteLine($"Hello, my name is {name} and I am {age} years old.");
    }

    static void Main(string[] args)
    {
        Person personOne = new Person();
        personOne.name = "Juan";
        personOne.age = 21;
        personOne.Greet();

        Person personTwo = new Person();
        personTwo.name = "Juana";
        personTwo.age = 31;
        personTwo.Greet();

        Console.ReadKey();
    }
}

