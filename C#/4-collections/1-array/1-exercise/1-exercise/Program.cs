/*
Create an array of 10 numbers.

Fill the array with numbers entered by the user.
Reverse the array using only the same array.
Do not create a second array.

Print the final array.
 */

int[] numbers = new int[10];

for(int f = 0; f < numbers.Length; f++)
{
    Console.Write("Enter a number: ");
    numbers[f] = Convert.ToInt32(Console.ReadLine()); 
}
Console.WriteLine("\n== Normal array ==");
Console.WriteLine(string.Join(" - ", numbers));

int contador = numbers.Length - 1;
for (int f2 = 0; f2 < (numbers.Length / 2); f2++)
{
    int temporal = numbers[f2];

    numbers[f2] = numbers[contador];
    numbers[contador] = temporal;

    contador--;
}

Console.WriteLine("\n== Reverse array ==");
Console.WriteLine(string.Join(" - ", numbers));