
Dictionary<string, string> colors = new Dictionary<string, string>
{
    {"White", "Blanco"},
    {"Green", "Verde"},
    {"Blue", "Azul"},
    {"Purple", "Morado"}
};
string inputOption;

do
{
    string inputColor, addColorSpanish, addColorEnglish;
    bool existsColor = false;

    Console.WriteLine("\n=== MENU ===" +
                      "\n1. Search for a color." +
                      "\n2. Add color. " +
                      "\n3. Exit ");
    Console.Write("Enter an option: ");
    inputOption = Console.ReadLine().Trim();

    switch (inputOption)
    {
        case "1":
            Console.Write("Enter a color: ");
            inputColor = Console.ReadLine().Trim();
            foreach (var color in colors)
            {
                if (string.Equals(color.Key, inputColor, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nEnglish: {color.Key}  -  Spanish: {color.Value}");
                    existsColor = true;
                    break;
                }
            }

            if (!existsColor) { Console.WriteLine($"There is no translation for the color {inputColor}"); }
            break;

        case "2":
            Console.Write("Enter the color in English: ");
            addColorEnglish = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(addColorEnglish)) { Console.WriteLine("*** Please enter a valid input ***"); break; }
            foreach (var color in colors)
            {
                if (string.Equals(color.Key, addColorEnglish, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"*** The color {addColorEnglish} already exists ***");
                    existsColor = true; 
                    break;
                }
            }
            if (existsColor) break;
            Console.Write("Entere the color in Spanish: ");
            addColorSpanish = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(addColorSpanish)) { Console.WriteLine("*** Please type a valid input  ***"); break; }

            colors.Add(addColorEnglish, addColorSpanish);
            Console.WriteLine($"--- The color {addColorEnglish} was added sucessfully ---");
            break;

        case "3": Console.WriteLine("Exiting..."); break;
        default: Console.WriteLine("*** Please type valid data ***"); break;
    }

} while (inputOption != "3");
Console.ReadKey();