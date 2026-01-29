/*
Create a program that asks the user for two numbers.
Handle the error when the second number is zero.
Show a clear message instead of crashing.
*/

int numberOne, numberTwo;

Console.Write("Enter the first number:");
numberOne = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the second number:");
numberTwo = Convert.ToInt32(Console.ReadLine());

try
{
    Console.WriteLine($"--- The result is {numberOne / numberTwo} ---");
}
catch (DivideByZeroException)
{
    Console.WriteLine("*** You can not divide by zero ***");
}

Console.ReadKey();