/*
Create an array with several numbers.
Ask the user for a position (index).
Handle the error if the index does not exist.
*/

int[] numbers = {1, 2, 3, 4, 5};
int index;

Console.Write("Enter the number of the index: ");
index = Convert.ToInt32(Console.ReadLine());

try
{
    Console.WriteLine(numbers[index]);
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine($"*** Index {index} was not found ***");
}

Console.ReadKey();