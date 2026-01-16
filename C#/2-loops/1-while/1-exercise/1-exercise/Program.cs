/*
Ask the user to enter numbers until they type 0.
Print all numbers except multiples of 3.
Stop the loop immediately if a number is greater than 100.
 */

int number = 1;

while (number != 0)
{
    Console.Write("Enter a number: ");
    number = Convert.ToInt32(Console.ReadLine());

    if (number%3 == 0)
    {
        continue;
    }

    if (number > 100)
    {
        break;
    }

    Console.WriteLine(number);
}

Console.ReadKey();