/*
 Create a list of words.

Ask the user to enter 8 words.
Store them in a list.

Find the word with the most characters.
Print the word and its length.
 */

using System.Globalization;

List<string> words = new List<string>();

for (int f = 0; f < 8; f++)
{
    Console.Write("Enter a word: ");
    words.Add(Console.ReadLine().Replace(" ", ""));
}

string largestWord = words[0];
for (int f2 = 1; f2 < words.Count; f2++)
{
    if (words[f2].Length > largestWord.Length)
    {
        largestWord = words[f2];
    }
    
}

Console.WriteLine($"\nThe largest word is: {largestWord} with {largestWord.Length} characters");

Console.ReadKey();