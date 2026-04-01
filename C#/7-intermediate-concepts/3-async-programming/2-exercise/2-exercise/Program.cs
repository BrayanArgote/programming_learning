using System.Diagnostics;

async Task DownloadBook(string title, int milliseconds)
{
    Console.WriteLine("\n-- Starting download --\n");
    await Task.Delay(milliseconds);

    ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = "cmd.exe",
        Arguments = $"/c echo ¡-- {title} downloaded successful in {milliseconds / 1000} seconds --! & pause",
        UseShellExecute = true,
        CreateNoWindow = false
    };

    Process.Start(psi);
}

Console.WriteLine("===== EBOOK DOWNLOADER =====");

int numberBooksDownloaded = 0;
Random numberRandom = new Random();
while (true)
{
    Console.Write("Enter the name of the book: ");
    string input = Console.ReadLine().Trim();

    if (string.IsNullOrEmpty(input)) { continue; }
    if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase)) { break; }

    int milliseconds = numberRandom.Next(2000, 9000);

    DownloadBook(input, milliseconds);

    numberBooksDownloaded++;
}

Console.WriteLine($"{numberBooksDownloaded} books was downloaded --");
Console.WriteLine("Exiting... ");

Console.ReadKey();