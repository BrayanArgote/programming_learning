/*
Ask the user to enter a sentence.

If the sentence has a number, stop the loop using break.
Count how many letters were read before the number.

Print:
"Number found"
"Letters before number: X"
 */

string sentence;
int numberLetters = 0;

Console.Write("Enter a sentence: ");
sentence = Console.ReadLine();

foreach (char character in sentence)
{
    if (char.IsDigit(character))
    {
        Console.WriteLine("Number found");
        break;
    }

    else if (char.IsLetter(character)) { numberLetters++; }
        
}

Console.WriteLine("Letters before number: " + numberLetters);

Console.ReadKey();