/*
Ask the user to enter a number n.

Print a pyramid of numbers.
The pyramid has n rows.
Each row prints numbers starting from 1 up to the row number.
Each row must be on a new line.
 */

int n;

Console.Write("Enter a number: ");
n = Convert.ToInt32(Console.ReadLine());

for (int f = 1; f <= n; f++)
{
    
    for (int f1 = 1; f1 <= f; f1++)
    {
        Console.Write(f1 + " ");
    }
    Console.WriteLine();
}

Console.ReadKey();