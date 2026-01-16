/*  
 Ask the user to enter a number from 1 to 7 (day of the week).
Print "Weekday" for 1–5, "Weekend" for 6–7.
If the number is not 1–7, print "Invalid day".
 */

int day;

Console.Write("Enter a day of the week: ");
day = Convert.ToInt32(Console.ReadLine());

if(day >= 1 && day <= 5)
{
    Console.WriteLine("Weekday");
}

else if (day == 6 || day == 7)
{
    Console.WriteLine("Weekend");    
}

else
{
    Console.WriteLine("Invalid day");    
}

Console.ReadKey();
