/* 
 Ask the user to enter two numbers.
Use all arithmetic operators 
(+, -, *, /, %) and print the results.
 */

int numberOne, numberTwo;

Console.Write("Enter the fist integer number: ");
numberOne = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the second integer number: ");
numberTwo = Convert.ToInt32(Console.ReadLine());

// show result
Console.WriteLine($"\nAddition: {numberOne + numberTwo}");
Console.WriteLine($"Substraction: {numberOne - numberTwo}");
Console.WriteLine($"Multiplication: {numberOne * numberTwo}");
Console.WriteLine($"Division: {numberOne / (double)numberTwo}");
Console.WriteLine($"Remainder: {numberOne % numberTwo}");

Console.ReadKey();