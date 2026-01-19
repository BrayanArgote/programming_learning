/* 
Create an array of 7 numbers.

Ask the user to enter the numbers.
Move all elements one position to the right.
The last element goes to the first position.
Print the final array.
 */

int[] numbers = new int[7];

for (int f = 0; f < numbers.Length; f++)
{
    Console.Write("Enter a number: ");
    numbers[f] = Convert.ToInt32(Console.ReadLine());
 }
Console.WriteLine("\n== Normal array ==\n" +
                  $"{string.Join(" - ", numbers)}");

int[] numbersMove = new int[numbers.Length];
for (int f1 = 0; f1 < numbers.Length; f1++)
{
    if (f1 == numbers.Length - 1)
    {
        numbersMove[0] = numbers[f1];
    }
    else
    {
        numbersMove[f1 + 1] = numbers[f1];
    }
}

Console.WriteLine("\n== Move right array ==\n" +
                  $"{string.Join(" - ", numbersMove)}");

Console.ReadKey();

