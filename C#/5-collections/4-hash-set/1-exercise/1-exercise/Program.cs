
HashSet<string> songs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
{
"Song two", "Ride", "Mr. Brightside", "Something about us", "What I've done"
};
string option;

do
{

    Console.WriteLine("\n=== MENU ===" +
                      "\n1. Show songs." +
                      "\n2. Search song." +
                      "\n3. Add song." +
                      "\n4. Exit. ");
    Console.Write("Enter an option: ");
    option = Console.ReadLine().Trim();

    switch (option)
    {
        case "1":
            if (songs.Count == 0) { Console.WriteLine("-- You don't have any songs --"); break; }

            Console.WriteLine(new string('-', 24));
            Console.WriteLine("| {0, -20} |", "SONGS");
            Console.WriteLine(new string('-', 24));

            foreach (var song in songs)
            {
                Console.WriteLine("| {0, -20} |", song);
                Console.WriteLine(new string('-', 24));
            }

            break;

        case "2":
            string songSearch;
            Console.Write("Enter the song: ");
            songSearch = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(songSearch)) { Console.WriteLine("*** The song can not be empty ***"); break; }

            if (songs.Contains(songSearch)) Console.WriteLine($"--- The song {songSearch} exists ---");
            else Console.WriteLine($"** The song {songSearch} does not exists **");
            break;

        case "3":
            string songAdd;
            Console.Write("Enter the song: ");
            songAdd = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(songAdd)) { Console.WriteLine("*** The name of the song can't be empty ***"); break; }

            if (songs.Add(songAdd)) Console.WriteLine("--- Song added successfully ---");
            else Console.WriteLine($"*** The song {songAdd} already exists ***");
            break;

        case "4": Console.WriteLine("Exiting ..."); break;

        case "cls" or "clear": Console.Clear(); break;

        default: Console.WriteLine("*** Invalid option ***"); break;
    }

} while (option != "4");

Console.ReadKey();
