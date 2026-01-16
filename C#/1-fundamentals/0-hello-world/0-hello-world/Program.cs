string name;
int age;

Console.Write("Enter your Name: ");
name = Console.ReadLine();

Console.Write("Enter your Age: ");
age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"=== Hello {name} you are {age} old ===");

Console.ReadKey();