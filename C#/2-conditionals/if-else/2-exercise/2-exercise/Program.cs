/*   
Ask the user for a score from 0 to 100.

*  Print "Fail" if less than 50, "Pass" if 50–69, 
   "Good" if 70–84, "Very Good" if 85–94, "Excellent" if 95–100.
*  Handle numbers outside 0–100 with "Invalid score".
 */

double score;

Console.Write("Enter a score (between 0 to 100): ");
score = Convert.ToDouble(Console.ReadLine());

if (score < 0 || score > 100)
{
    Console.WriteLine("Invalid score");
}

else if (score < 50)
{
    Console.WriteLine("Fail");
}

else if (score < 70 )
{
    Console.WriteLine("Pass");
}

else if (score < 85)
{
    Console.WriteLine("Good");
}

else if (score < 95)
{
    Console.WriteLine("Very Good");
}

else
{
    Console.WriteLine("Excellent");
}

Console.ReadKey();