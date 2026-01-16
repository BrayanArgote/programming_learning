/*
 Create variables to store your age, height (decimal), 
full name, and if you are a student. 
Print all variables to the console.
 */

int age;
decimal height;
string fullName, input;
bool student;

// Ask data
Console.Write("Enter your age: ");
age = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter your height: ");
height = Convert.ToDecimal(Console.ReadLine());

Console.Write("Enter your full name: ");
fullName = Console.ReadLine();

Console.Write("Are you a Student? (s/n): ");
input = Console.ReadLine().ToLower();
student = input == "n" || input == "s";

// Show data
Console.WriteLine($"\nAge: {age}");
Console.WriteLine($"Height: {height}");
Console.WriteLine($"Full name: {fullName}");
Console.WriteLine($"Is it a student?: {student}");

Console.ReadKey();
