// LOOKAHEAD AND LOOKBEHIND

using System.Text.RegularExpressions;

string firstWord = "catdog catfish dogcat";
bool firstResult = Regex.IsMatch(firstWord, @"dog(?=cat)");
// Console.Write(firstResult);

string secondWord = "catdog cat cat";
bool secondResult = Regex.IsMatch(secondWord, @"cat(?!=dog)");
// Console.WriteLine(secondResult);


string numberAndPrices = "$100 200 $300 400";
bool thirdResult = Regex.IsMatch(numberAndPrices, @"\d+(?<=$)");
// Console.WriteLine($"Are there prices?  {(thirdResult ? "Yes" : "No")} ");

bool fourthResult = Regex.IsMatch(numberAndPrices, @"\d+(?<!\$)");
Console.WriteLine($"Are there normal numbers? {(fourthResult ? "Yes" : "No")}");

Console.ReadKey();