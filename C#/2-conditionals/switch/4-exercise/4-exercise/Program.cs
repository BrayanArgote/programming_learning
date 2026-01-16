/* 
Ask the user for the number of worked hours in a day.
Return "Low", "Normal", or "Overtime".
* Less than 4 → "Low"
* From 4 to 8 → "Normal"
* More than 8 → "Overtime"
Use a switch expression to assign the result to a variable. 
 */

double hours;

Console.Write("Enter a number of hours worked per day: ");
hours = Convert.ToDouble(Console.ReadLine());

string result = hours switch
{
    >= 0 and < 4    => "Low",
    >= 4 and <= 8   => "Normal",
    > 8             => "Overtime",
    _               => "Invalid number"
};

Console.WriteLine(result);