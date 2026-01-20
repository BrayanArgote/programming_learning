/*
Create a class StringHelper.
Add a method Reverse(string text) that returns the text reversed.
Add another method CountVowels(string text) that returns the number of vowels in the text.
Test both methods in Main.
 */

class StringHelper
{
    
    string Reverse(string text)
    {
        string reverseText = "";
        for (int f = text.Length - 1; f >= 0; f--)
        {
            reverseText = reverseText + text[f]; 
        }
        return reverseText;
    }

    int CountVowels(string text)
    {
        int numberVowels = 0;
        text = text.ToLower();
        foreach(char character in text)
        {
            if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
            {
                numberVowels++;
            }
        }
        return numberVowels;
    }

    static void Main(string[] args)
    {
        StringHelper word = new StringHelper();
        Console.WriteLine("Inverted text: " + word.Reverse("juan"));
        Console.WriteLine("Number of vowels: " + word.CountVowels("juan"));

        Console.ReadKey();
    }

}