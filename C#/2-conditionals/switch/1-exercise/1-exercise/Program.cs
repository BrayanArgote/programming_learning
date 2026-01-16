/* 
 
Ask the user for a number from 1 to 12 (month number).
Print the season: "Winter", "Spring", "Summer", "Autumn".

* Months 12, 1, 2 → Winter
* Months 3, 4, 5 → Spring
* Months 6, 7, 8 → Summer
* Months 9, 10, 11 → Autumn
* Use default for invalid numbers.

 * */

int month;

Console.WriteLine("== If you want to know the season ==");
Console.Write("Enter a month number: ");
month = Convert.ToInt32(Console.ReadLine());

switch (month)
{
    case 12:
    case 1:
    case 2:
        Console.WriteLine("Winter");
        break;

    case 3:
    case 4:
    case 5:
        Console.WriteLine("Spring");
        break;

    case 6:
    case 7:
    case 8:
        Console.WriteLine("Summer");
        break;

    case 9:
    case 10:
    case 11:
        Console.WriteLine("Autumn");
        break;

    default:
        Console.WriteLine("Invalid number");
        break;

}

Console.ReadKey();