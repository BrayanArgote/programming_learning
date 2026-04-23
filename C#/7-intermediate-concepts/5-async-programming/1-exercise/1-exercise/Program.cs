
List<List<string>> database = new List<List<string>> {      
    new List<string> { "yellow", "green", "red", "white" }, // colors
    new List<string> { "dog", "cat", "fish" }               // animals
};

async Task<string> PrintItemsAsync(int listIndex)
{
    Console.WriteLine("\n-- Searching... ");

    var data = await SearchItemsAsync(listIndex);
    return string.Join(" - ", data);
}

async Task<List<string>> SearchItemsAsync(int listIndex)
{
    await Task.Delay(2500);
    return database[listIndex];
}

string option;

do
{
    Console.WriteLine("\n==== MENU ===" +
                      "\n1. Show colors. " +
                      "\n2. Show animals. " +
                      "\n3. Exit. ");
    Console.Write("Enter an option: ");
    option = Console.ReadLine().Trim();
    

    switch (option)
    {
        case "1":
            Console.WriteLine(await PrintItemsAsync(Convert.ToInt32(option) - 1));
            break;

        case "2": 
            Console.WriteLine(await PrintItemsAsync(Convert.ToInt32(option) - 1));
            break;

        case "3": Console.WriteLine("Exiting... "); break;

        case "cls" or "clear": Console.Clear(); break;

        default: Console.WriteLine("*** Please type a valid option ***"); break;
    }

} while (option != "3");

Console.ReadKey();

