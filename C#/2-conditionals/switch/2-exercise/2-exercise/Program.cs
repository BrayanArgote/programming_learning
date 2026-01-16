/*
 Ask the user for a letter (A, E, I, O, U or others).

* Print "Vowel" for vowels.
* Print "Consonant" for other letters.
* Print "Invalid input" if it is not a letter.

Do not use if.
 */

// A=65  E=69  I=73  O=79  U=85  Z=90 Ñ=209

 char letter = 'a';

Console.Write("Enter a letter: ");
letter = Convert.ToChar(Console.ReadLine());

letter = char.ToUpper(letter);

string result = (int)letter switch
{
    65 or 69 or 73 or 79 or 85 => "Vowel",
    > 65 and <= 90 or 209      => "Consonant",
    _                          => "Invalid input"
};
    
Console.WriteLine(result);

