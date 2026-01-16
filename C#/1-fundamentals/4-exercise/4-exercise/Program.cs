/*
Ask the user to enter a number as text.
Convert it to int (assume the input is correct)
and print the number multiplied by 2.
 */

string numberText;
int number;

Console.Write("Type a number (as text): ");
numberText = Console.ReadLine();

number = Convert.ToInt32(numberText) * 2;

Console.WriteLine("Your number multiplied by two is: " + number);

Console.ReadKey();