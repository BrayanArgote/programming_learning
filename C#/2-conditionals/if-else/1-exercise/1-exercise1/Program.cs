/*
Write a program that asks the user for a number.
Print "Negative", "Zero", "Small positive" (1–10), 
"Medium positive" (11–100), or "Large positive" 
(over 100) depending on the value. 
*/

int number;


    Console.Write("Enter an integer number: ");
    number = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("");

    if (number < 0)
    {
        Console.WriteLine("== Negative ==");
    }

    else if (number == 0)
    {
        Console.WriteLine("== Zero ==");
    }

    else if (number <= 10)
    {
        Console.WriteLine("== Small positive ==");
    }

    else if (number <= 100)
    {
        Console.WriteLine("== Medium positive ==");
    }

    else
    {
        Console.WriteLine("== Large positive ==");
    }


Console.ReadKey();