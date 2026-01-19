/*
 Ask the user to enter a word.

If the word has two equal letters in a row, stop the loop.
If not, finish the loop normally.

Print:
"Repeated letters found"
or "No repeated letters"
 */

string word;
char letter = '\0';
bool flag = true;

Console.Write("Enter a word: ");
word = Console.ReadLine();

foreach(char character in word)
{
    
    if (character == letter)
    {
        Console.WriteLine("Repeated letters found");
        flag = false;
        break;
    }
    letter = character;
}

if (flag)
{
    Console.WriteLine("No repeated letters");
}

Console.ReadKey();