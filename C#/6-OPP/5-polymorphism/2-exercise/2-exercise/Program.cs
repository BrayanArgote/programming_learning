/*
Create a class Character with properties: Name, Health.
Add a virtual method Attack()".

Create Warrior and Healer classes.
Warrior.Attack() uses override.
Healer.Attack() uses new or overloading.

Optional: add a conditional inside Attack based on health.
Store all characters in a list of Character.
*/

class Program
{
    static void Main(string[] args)
    {
        List<Character> listCharacters = new List<Character>();
        string option = "";

        while(option != "4")
        {
            Console.WriteLine("\n===== MENU =====" +
                              "\n1. Show characters. " +
                              "\n2. Create a character. " +
                              "\n3. Use a character. " +
                              "\n4. Exit. ");
            Console.Write("Enter an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    if (listCharacters.Count == 0)
                    {
                        Console.WriteLine("*There are no characters*");
                    }
                    else
                    {
                        int characterNumber = 1;
                        foreach(var fe in listCharacters)
                        {
                            Console.WriteLine($"\nCharacter {characterNumber}");
                            Console.WriteLine($"Type: {fe.GetType().Name.ToUpper()}" +
                                              $"\nName: {fe.Name}" +
                                              $"\nHealth: {fe.Health}");
                            characterNumber++;  
                        }
                    }
                    break;

                case "2":
                    string name, typeInput;
                    Console.Write("Enter the name: ");
                    name = Console.ReadLine().Trim();
                    Console.Write("Enter the type (Warrior or Healer): ");
                    typeInput = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)){
                        Console.WriteLine("*The name is necesary*");
                        break;
                    }

                    if (typeInput.ToLower() == "warrior")
                    {
                        listCharacters.Add(new Warrior(name));
                        Console.WriteLine($"-- A Warrior character with the name {name} was created --");
                    }
                    else if (typeInput.ToLower() == "healer")
                    {
                        listCharacters.Add(new Healer(name));
                        Console.WriteLine($"-- A Healer character with the name {name} was created --");
                    }
                    else { Console.WriteLine("*Incorrect type of character*"); }
                    break;

                case "3":
                    if (listCharacters.Count != 0)
                    {
                        string characterUse;
                        Console.Write("Enter the name of the character: ");
                        characterUse = Console.ReadLine().Trim();
                        bool flag = false;
                        double amountToHeal;

                        foreach (var fe in listCharacters)
                        {
                            if (fe.Name == characterUse)
                            {
                                if (fe is Healer healer) {
                                    Console.Write("Enter the amout to heal: ");
                                    amountToHeal = Convert.ToDouble(Console.ReadLine());
                                    healer.Attack(amountToHeal);
                                }
                                else 
                                {
                                    fe.Attack();
                                }
                                flag = true;
                                break;
                            }
                        }

                        if (!flag)
                        {
                            Console.WriteLine($"Character with the name {characterUse} was not found");
                        }
                    }
                    else { Console.WriteLine("*There are no characters*"); }
                    break;

                case "4": Console.WriteLine("Exiting... "); break;
                default: Console.WriteLine("*Invalid option*"); break;
            }
        }
        Console.ReadKey();
    }
}