// ANCHORS 

using System.Text.RegularExpressions;

string firstWord = "car cars carwash car";
int timesRepeatedCar = Regex.Count(firstWord, @"\bcar\b");
// Console.WriteLine($"The word -car- was repeated {timesRepeatedCar} times.");


string secondWord;
Console.Write("Enter a word that starts with a number or the letter a:");
secondWord = Console.ReadLine();
string result = Regex.IsMatch(secondWord, @"^[0-9]|a") ? "The word meets the requirement." : "The word doesn't meet the requirent";
Console.WriteLine(result);



Console.ReadKey();