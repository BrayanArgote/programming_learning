// GREEDY (*, +, { })  AND  LAZY (*?, +?, { }?)

using System.Text.RegularExpressions;
 
// GREDDY
string firstWord = "<body>one</body><b>two</b>";
var greddyResult = Regex.Replace(firstWord, @"<[A-Za-z]+>|</[A-Za-z]+>", " ");
// Console.WriteLine(greddyResult);


// LAZY
string secondWord = "test@mail.com - other@mail.com";
var lazyResult = Regex.Match(secondWord, @"\w+@\w+\.com");
// Console.WriteLine(lazyResult);


string thirdWord = " empty farmer king go abc outside 456 ";
var thirdResult = Regex.Matches(thirdWord, @" \w{3} ");
foreach(var item in thirdResult) Console.WriteLine(item);

Console.ReadKey();