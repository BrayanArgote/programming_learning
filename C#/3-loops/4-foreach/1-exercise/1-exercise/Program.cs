/*
 Ask the user to enter a word.

Count how many vowels the word has.
Count how many consonants the word has.

Print:
Total vowels
Total consonants
total characters different from vowels and consonants
 */

string word;
int totalVowels = 0, totalConsonants = 0, totalDifferents = 0;

Console.Write("Enter a word: ");
word = Console.ReadLine();

word = word.Replace(" ", "").ToLower();

foreach (char character in word)
{
    if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
    {
        totalVowels++;
    }

    else if (char.IsLetter(character))
    {
        totalConsonants++;
    }

    else
    {
        totalDifferents++;
    }
}

Console.WriteLine("\n== TOTAL ==" +
                  $"\nVowels: {totalVowels}" +
                  $"\nConsonats: {totalConsonants}" +
                  $"\nOthers: {totalDifferents}");

Console.ReadKey();
