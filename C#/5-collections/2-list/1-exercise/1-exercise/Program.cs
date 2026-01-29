/* 
Create a list of numbers.

Ask the user to enter 10 numbers.
Store them in a list.
Remove duplicated values without using built-in methods like Distinct.
Print the final list.
*/

List<int> numbers = new List<int>();

for (int f = 0; f < 10; f++)
{
    int number;
    Console.Write("Enter a Number: ");

    number = Convert.ToInt32(Console.ReadLine());
    numbers.Add(number);
}
Console.WriteLine("\n== Input list ==" +
                 $"\n{string.Join(" - ", numbers)}");


List<int> copyNumbers = new List<int>(numbers);
for (int f1 = 0; f1 < numbers.Count; f1++)
{
    for (int f2 = f1 + 1; f2 < numbers.Count; f2++)
    { 
        if (numbers[f1] == numbers[f2])
        {
            copyNumbers.Remove(numbers[f2]);
            break;
        }
        
    }
}

Console.WriteLine("\n== List without repeat numbers ==" +
                 $"\n{string.Join(" - ", copyNumbers)}");

Console.ReadLine();