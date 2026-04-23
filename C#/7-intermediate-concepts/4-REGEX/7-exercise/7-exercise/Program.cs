// FLAGS 

using System.Text.RegularExpressions;

string animals = "Dog doG fish mockey Fish cat bird fIsH";
int firstResult = Regex.Count(animals, @"fish", RegexOptions.IgnoreCase);
// Console.WriteLine($"The word - fish - appears {firstResult} times. ");

string movies = "Baby \nSpider Man \nDuna \nZootopia \nSpider man 2 \nspider man 3 \nFight club";
int secondResult = Regex.Count(movies, @"^Spider", RegexOptions.Multiline | RegexOptions.IgnoreCase);
Console.WriteLine($"There are {secondResult} movies of spider man.");

Console.ReadKey();