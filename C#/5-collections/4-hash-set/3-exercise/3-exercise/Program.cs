using System.Diagnostics;
using System.Timers;

int[] listNumbers = {
    12, 45, 78, 3, 99, 24, 67, 1, 56, 88,
    3, 72, 15, 90, 6, 41, 27, 83, 59, 10,
    9, 22, 0, 5, 38, 61, 7, 80, 29, 47,
    66, 2, 91, 14, 53, 76, 31, 8, 60, 25,
    97, 19, 70, -1, 84, 11, 8, 4, 69, -2
};

List<int> listResult = new List<int>();

Stopwatch listTime = new Stopwatch();
listTime.Start();

foreach(var n in listNumbers)
{
    if (listNumbers.Contains(n - 1)) continue;

    List<int> temporalResult = new List<int>();
    temporalResult.Add(n);

    for(int f = 0; true; f++)
    {
        if (!listNumbers.Contains(n + f)) break;
        temporalResult.Add(n + f);
    }

    if (listResult.Count() < temporalResult.Count()) listResult = temporalResult;

}
listTime.Stop();

Console.WriteLine("========= LIST =========");
Console.WriteLine($"Result: {string.Join(',', listResult)} \nTime: {listTime.Elapsed.TotalMilliseconds} ms");


HashSet<int> hashSetNumbers = new HashSet<int>(listNumbers);
List<int> hashSetResult = new List<int>();

Stopwatch hashSetTime = new Stopwatch();
hashSetTime.Start();

foreach (var n in hashSetNumbers)
{
    if (hashSetNumbers.Contains(n - 1)) continue;

    List<int> temporalResult = new List<int>();
    temporalResult.Add(n);
    int contador = 1;

    while (hashSetNumbers.Contains(n + contador))
    {
        temporalResult.Add(n + contador);
        contador++;
    }

    if (hashSetResult.Count() < temporalResult.Count()) hashSetResult = temporalResult;
}

hashSetTime.Stop();
Console.WriteLine("\n======== HASHSET ========");
Console.WriteLine($"Result: {string.Join(',', hashSetResult)} \nTime: {hashSetTime.Elapsed.TotalMilliseconds} ms");

Console.ReadKey();