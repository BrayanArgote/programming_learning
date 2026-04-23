// CHARACTERS CLASSES - SHORCUTS - INVERSOS

using System.Text.RegularExpressions;

string firstWord = "abc5";
bool firstFlag = Regex.IsMatch(firstWord, @"\d");
// Console.WriteLine(firstFlag);


string secondWord = "a1b22c333";
var secondResult = Regex.Matches(secondWord, @"\d");
// foreach (var item in secondResult) Console.WriteLine(item);


string thirdWord = "1 2 3 4";
var thirdResult = Regex.Replace(thirdWord, @"[\s]", "-");
Console.WriteLine(thirdResult);


Console.ReadLine();