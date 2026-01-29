/*
Ask the user to enter an age.
Handle the case when the user writes text instead of a number.
The program must continue running.
 */

int age;

do
{
    Console.Write("Enter your age: ");

    try
    {
        age = Convert.ToInt32(Console.ReadLine());
        break;
    }
    catch
    {
        Console.WriteLine("*** You only can type a integer number ***");
    }
} while (true);

Console.ReadKey();