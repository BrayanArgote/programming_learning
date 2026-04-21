// GROUPS AND ALTERANTION - BACKREFERENCES

using System.Text.RegularExpressions;

string anyWord = "ababababa dsjf ih ice cream";
var firstResult = Regex.Match(anyWord, @"(ab)+");
// Console.WriteLine(firstResult);

string emails = "user@gmail.com - user@hotmail.com";
var secondResult = Regex.Matches(emails, @"\w+@(\w+)\.com");
// foreach (Match item in secondResult) Console.WriteLine(item.Groups[1]);

string fileDuplicateWords = " hello hello ";
var fileWithoutDuplicateWords = Regex.Replace(fileDuplicateWords, @"(\w+) \1", "$1");
Console.WriteLine(fileWithoutDuplicateWords);

Console.ReadKey();
