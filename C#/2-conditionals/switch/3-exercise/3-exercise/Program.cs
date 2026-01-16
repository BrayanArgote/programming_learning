/*
 Ask the user for a temperature number.
* Print "Freezing" if less than 0.
* Print "Cold" if 0–9.
* Print "Warm" if 10–24.
* Print "Hot" if 25 or more.
Print "Invalid temperature" for very low values (less than -100).
 */

double temperature;

Console.Write("Type a temperature: ");
temperature = Convert.ToDouble(Console.ReadLine());

switch (temperature)
{
    case < -100         : Console.WriteLine("Invalid temperature");   break;
    case < 0            : Console.WriteLine("Freezing");              break;
    case <= 9           : Console.WriteLine("Cold");                  break;
    case <= 24          : Console.WriteLine("Warm");                  break;
    default             : Console.WriteLine("Hot");                   break;
}