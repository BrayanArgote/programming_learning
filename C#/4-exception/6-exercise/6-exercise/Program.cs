/*
Ask the user to enter two numbers.
Use TryParse to convert both to integers.
If both are valid, print their sum.
If any is invalid, show an error message and do not crash the program.
*/

int numberOne, numberTwo;

Console.WriteLine("-- Type the two numbers --");

if (int.TryParse(Console.ReadLine(), out numberOne) && int.TryParse(Console.ReadLine(), out numberTwo))

{
    Console.WriteLine($"\nAdd: {numberOne + numberTwo}");
}

else
{
    Console.WriteLine("*** Invalid numbers ***");
}

Console.ReadKey();


