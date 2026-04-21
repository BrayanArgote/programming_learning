/* METACHARACTERS - BASIC */

using System.Text.RegularExpressions;

string firstWord = "A9p";
bool firtsFlag = Regex.IsMatch(firstWord, @"[A-Z].[a-z]");
//Console.WriteLine(firtsFlag);

string secondWord = "Hello world";
bool secondFlag = Regex.IsMatch(secondWord, @"^Hello");
//Console.WriteLine(secondFlag);

string thirdWord = "good bye";
bool thirdFlag = Regex.IsMatch(thirdWord, @"bye$");
//Console.WriteLine(thirdFlag);

string fourthWord = "lorem aa insup color a and more recently with colorful desktop publishing software";
var fourthResult = Regex.Matches(fourthWord, @"color|colorful");
foreach(var item in fourthResult)
{
    Console.WriteLine(item);
}


Console.ReadKey();