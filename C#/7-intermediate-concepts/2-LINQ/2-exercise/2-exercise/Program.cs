/*
Create a list of names (e.g., "Ana", "Carlos", "Beatriz", "David").

Use LINQ to select names that start with the letter "C".

Print the results.
*/

List<string> names = new List<string> { "Ana", "Carlos", "Beatriz", "David", "critian" };


var result = from n in names
              where n.ToUpper().StartsWith("C")
              select n;

Console.WriteLine(string.Join(" - ", result));

Console.ReadKey();