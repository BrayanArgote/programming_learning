/*
Ask the user two yes/no questions (true/false).
Print the results of &&, ||, and ! directly to the console.
*/

bool isFemale, isAnAdult;

Console.Write("Are you a female? (true/false): ");
isFemale = Convert.ToBoolean(Console.ReadLine());

Console.Write("Are you an Adult? (true/false): ");
isAnAdult = Convert.ToBoolean(Console.ReadLine());

bool and = isFemale && isAnAdult,
     or  = isFemale || isAnAdult,
     not = !isFemale && !isAnAdult;

Console.WriteLine($"\nResult for &&: {and}");
Console.WriteLine($"Result for ||: {or}");
Console.WriteLine($"Result for !: {not}");

Console.ReadKey();



