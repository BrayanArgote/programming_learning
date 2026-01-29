/*
 create an array of eight numbers.

the user should fill it in using the console.
print how many times the number is repeated
 */

// create and fill an array
int[] numbers = new int[8];
int w = 0;

while (w < numbers.Length)
{
    Console.Write("Enter a number: ");
    numbers[w] = Convert.ToInt32(Console.ReadLine());
    w++;
}

// create an array with repeated numbers and count how many times a number is repeat
int[] timesRepeat = new int[numbers.Length];
for(int f1 = 0; f1 < numbers.Length; f1++)
{
    int count = 0;

    for (int f2 = f1 + 1; f2 < numbers.Length; f2++)
    {
            if (numbers[f1] == numbers[f2])
            {
                count++;
            }
    }
    timesRepeat[f1] = count;

}

// print how many times a number is repeated
for (int f3 = 0; f3 < numbers.Length; f3++)
{
    bool flag = false;

    // check if a number has already been printed
    for (int f4 = 0; f4 < f3; f4++)
    {

        if (numbers[f3] == numbers[f4])
        {
            flag = true;
            break;
        }

    }

    if (flag)
    {
        continue;
    }
    else
    {
        Console.WriteLine($"\nThe number {numbers[f3]} is repeated: {timesRepeat[f3]} times");
    }

}

Console.ReadLine();

