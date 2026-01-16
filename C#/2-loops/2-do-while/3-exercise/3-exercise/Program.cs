/*
 Ask the user to enter a number.

Rules:
The number must be positive.
The number must be not zero.
If the number is invalid:
Print "Invalid number".
The program must ask again until the number is valid.
When valid, print "Valid input" and stop.
 */

int number;

do
{
    Console.Write("Enter a number: ");
    number = Convert.ToInt32(Console.ReadLine());

    if (number > 0)
    {
        Console.WriteLine("Valid input");
        break;
    }

    else
    {
        Console.WriteLine("Invalid number");
    }

} while (true);

Console.ReadKey();