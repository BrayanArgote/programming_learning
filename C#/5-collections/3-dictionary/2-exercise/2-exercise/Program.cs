string sentence;
Console.Write("Enter a sentence: ");
sentence = Console.ReadLine().Trim();

if (string.IsNullOrEmpty(sentence)) Console.WriteLine("*** The sentence can not be empty ***");
else
{
    Dictionary<string, int> wordTimes = new Dictionary<string, int>();
    string[] words = sentence.Split(' ');

    for (int f = 0; f < words.Length; f++)
    {
        if(!wordTimes.TryAdd(words[f], 1)) {  wordTimes[words[f]]++; }
    }

    Console.WriteLine(new string('-', 27));
    Console.WriteLine("| {0, -10} | {1, -10} |", "WORD", "TIMES");
    Console.WriteLine(new string('-', 27));

    foreach(var word in wordTimes)
    {
        Console.WriteLine("| {0, -10} | {1, -10} |", word.Key, word.Value);
        Console.WriteLine(new string('-', 27));
    }
}

Console.ReadKey();