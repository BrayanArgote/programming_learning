/*
Ask the user to enter 10 numbers.

At the end, print:
Total positives
Total negatives
Total zeros 
 */

int number, zeroNumbers = 0, positiveNumbers = 0, negativeNumbers = 0; 


for (int f = 1; f <= 10; f++)
{

    do
    {
        Console.Write($"Enter number {f}: ");
    } while (!int.TryParse(Console.ReadLine(), out number));


    if (number < 0)
    {
        negativeNumbers++;
    }

    else if (number > 0)
    {
        positiveNumbers++;
    }

    else {
        zeroNumbers++;
    }
            
}
Console.WriteLine($"\n== TOTAL ==");
Console.WriteLine($"Positive numbers: {positiveNumbers}");
Console.WriteLine($"Negative numbers: {negativeNumbers}");
Console.WriteLine($"Zero numbers: {zeroNumbers}");

Console.ReadKey();