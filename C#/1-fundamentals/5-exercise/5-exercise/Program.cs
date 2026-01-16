/* Ask the user to enter their birth date.
Print the birth date, the current date, 
and the difference in years (age) without using if. */

string input;
DateTime birthDate, currentDate;

Console.Write("Enter your birth date (YYYY-MM-DD): ");
input = Console.ReadLine();

birthDate = DateTime.ParseExact(input, "yyyy-MM-dd", null);

Console.WriteLine($"\nBirth date: {birthDate}");
Console.WriteLine($"Current date: {currentDate = DateTime.Now}");

TimeSpan difference = currentDate - birthDate;
Console.WriteLine($"Difference years in each date (your age): {difference.Days/365}");


Console.ReadKey();