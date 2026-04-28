Stack<int> numbers = new Stack<int>();
string option = "";

do
{
    Console.WriteLine("\n==== MENU ====" +
                      "\n1. Add serveral numbers.   " +
                      "\n2. Show history of numbers." +
                      "\n3. Show last number." +
                      "\n4. Exit.");
    Console.Write("Enter an option: ");
    option = Console.ReadLine().Trim();

    switch (option)
    {
        case "1":
            string input;
            while (true)
            {
                Console.Write("Enter a number or type -exit- to quit: ");
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input)) Console.WriteLine("*** The input can not be empty ***");
            
                else if (input.ToLower() == "exit") break;

                else if (!int.TryParse(input, out int addNumber)) Console.WriteLine("*** Please type a valid number ***");

                else
                {
                    numbers.Push(addNumber);
                    Console.WriteLine($"-- number {addNumber} added --");
                }
            }
            break;

        case "2":
            if (numbers.Count > 0)
            {
                Console.WriteLine("=== HISTORY ===");
                foreach (var n in numbers) Console.WriteLine("+ " + n);
            }
            else Console.WriteLine("- No history -");
            break;

        case "3":
            if (numbers.Count == 0) Console.WriteLine("- No history -");
            else Console.WriteLine(numbers.Peek());
            break;

        case "4": Console.WriteLine("Exiting ..."); break;

        case "cls" or "clear": Console.Clear(); break;

        default: Console.WriteLine("*** Invalid Option ***"); break;
    }
} while (option != "4");

Console.ReadKey();