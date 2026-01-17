/*
Ask the user for two numbers: start and end.

Rules:
Sum only the numbers between start and end.
Skip numbers divisible by 3.

Stop the loop if the sum becomes greater than 100.

At the end, print the final sum.
 */

int firstNumber, lastNumber, sum = 0;

Console.Write("Enter the first number: ");
firstNumber = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the last number: ");
lastNumber = Convert.ToInt32(Console.ReadLine());

for (int f = firstNumber+1; f < lastNumber; f++)
{
    if (sum > 100)
    {
        break;
    }

    else if (f%3 == 0)
    {
        continue;
    }
    else
    {
        sum = sum + f;
    }
}

Console.WriteLine($"The result of the sum is: {sum}");