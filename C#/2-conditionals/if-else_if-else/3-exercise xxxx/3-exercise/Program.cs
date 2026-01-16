/*
 *Ask the user to enter a year.

Print "Leap year" if it is divisible by 4 and not divisible by 100, or divisible by 400.

Otherwise, print "Not a leap year".
 * */

int year;

    Console.Write("Enter a year: ");
    year = Convert.ToInt32(Console.ReadLine());

    if (year % 4 == 0 && year % 100 == 0)
    {
        if (year % 400 == 0)
        {
            Console.WriteLine("Leap year");
        }

        else
        {
            Console.WriteLine("Not a leap year");
        }

    }

    else if (year % 4 == 0)
    {
        Console.WriteLine("Leap year");
    }


    else
    {
        Console.WriteLine("Not a leap year");
    }

Console.ReadKey();
