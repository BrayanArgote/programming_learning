/* Do the classic exercise where the user enters their name and age 
and the system prints "Hello {name}, you are {years} old" but using POO
*/

class Person
{
    string name;
    int age;

    string AskName()
    {
        Console.Write("Enter your name: ");
        return Console.ReadLine();
    }

    void AskAge()
    {
        Console.Write("Enter your age: ");
        age = Convert.ToInt32(Console.ReadLine());
    }

    void Greet()
    {
        Console.WriteLine($"Hello {name}, you are {age} years old.");
    }

    static void Main(string[] args)
    {
        Person personOne = new Person();
        personOne.name = personOne.AskName();
        personOne.AskAge();
        personOne.Greet();

        Console.ReadKey();
    }

}
