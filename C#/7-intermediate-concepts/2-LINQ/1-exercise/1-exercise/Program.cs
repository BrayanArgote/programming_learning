/*
Create a list of numbers from 1 to 10.
Use LINQ to get only the even numbers.
Print the result.
*/

List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var result = from n in numbers
             where n%2 == 0
             select n;

Console.Write(string.Join(" - ", result));

Console.ReadKey();