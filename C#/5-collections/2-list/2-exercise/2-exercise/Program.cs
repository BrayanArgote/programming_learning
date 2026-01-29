/*
 Create one list of numbers.

Ask the user to enter numbers until they type 0.
Store all numbers in one list.

Create two new lists:
One for even numbers
One for odd numbers

Print both lists.
 */

List<int> numbers = new List<int>();

int w;
while (true)
{
    Console.Write("Enter a number: ");
    w = Convert.ToInt32(Console.ReadLine());

    if (w == 0)
    {
        break;
    }
    numbers.Add(w);
}

List<int> evenNumbers = new List<int>();
List<int> oddNumbers = new List<int>();

foreach (int fr in numbers)
{
    if (fr%2 == 0)
    {
        evenNumbers.Add(fr);
    }

    else
    {
        oddNumbers.Add(fr);
    }
}

Console.Write($"\nInput list: {string.Join(" - ", numbers)}");

Console.Write($"\nEven numbers list: {string.Join(" - ", evenNumbers)}");

Console.Write($"\nOdd numbers list: {string.Join(" - ", oddNumbers)}"); 

Console.ReadLine();