/* 
Ask the user to enter numbers repeatedly.

Keep a running total.

If the total reaches exactly 200, print "Perfect sum" and stop.

If a number is negative, ignore it and continue.
 */

int sum = 0, number;

while (sum != 200)
{
    Console.Write("Enter a number: ");
    number = Convert.ToInt32(Console.ReadLine());

    if (number < 0)
    {
        continue;
    }

    sum = number + sum;
}

Console.WriteLine("Perfect sum");

Console.ReadKey();


