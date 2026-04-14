using _5_Dependency_Inversion_principle.Entities;
using _5_Dependency_Inversion_principle.Services;

namespace _5_Dependency_Inversion_principle
{
    public class Management
    {
        private readonly UserService _userService;
        private readonly IAppLogReader _iAppLogReader;

        private string invalidInputMessage = "*** Please type a valid data ***";
        private string exitMessage = "Exiting...";

        public Management(UserService userService, IAppLogReader iAppLogReader)
        {
            _userService = userService;
            _iAppLogReader = iAppLogReader;
        }

        public async Task MainMenu()
        {

            string option;
            List<Log> listLogs = new List<Log>();

            do
            {
                Console.WriteLine("\n=== MENU ===" +
                                  "\n1. Execute user operations." +
                                  "\n2. Show logs (these come from the select option (file or database)). " +
                                  "\n3. Exit.");
                Console.Write("Enter an option: ");
                option = Console.ReadLine().Trim();

                switch (option)
                {

                    case "1": Console.Clear();  await CrudMenu();
                        break;

                    case "2":
                        listLogs = _iAppLogReader.GetAll();

                        if (listLogs.Count == 0) { Console.WriteLine("-- There are no logs --"); break; }

                        Console.WriteLine(new string('-', 66));
                        Console.WriteLine("| {0, -2} | {1, -7} | {2, -7} | {3, -7} | {4, -27} |", "ID", "USER ID", "ACTION", "LEVEL", "DATE");
                        Console.WriteLine(new string('-', 66));

                        foreach (var log in listLogs)
                        {
                            Console.WriteLine("| {0, -2} | {1, -7} | {2, -7} | {3, -7} | {4, -27} |", log.Id, log.UserId, log.Action, log.Level, log.Timestamp);
                            Console.WriteLine(new string('-', 66));
                        }

                        break;

                    case "3": Console.WriteLine(exitMessage);  await Task.Delay(2000); Console.Clear(); break;

                    case "cls": Console.Clear(); break;

                    default: Console.WriteLine(invalidInputMessage); break;

                }

            } while (option != "4");
        }

        public async Task CrudMenu()
        {
            string option;

            do
            {
                Console.WriteLine("\n=== MENU ===" +
                                  "\n1. Add user." +
                                  "\n2. Disable the user." +
                                  "\n3. Show all users." +
                                  "\n4. Exit.");
                Console.Write("Enter an option: ");
                option = Console.ReadLine().Trim();

                switch (option)
                {
                    case "1":
                        string fullName;
                        int age;

                        Console.Write("Enter a full name: ");
                        fullName = Console.ReadLine().Trim();
                       // if (string.IsNullOrEmpty(fullName)) { Console.WriteLine(invalidInputMessage); break; }
                        //else if (fullName.Length > 50) { Console.WriteLine("*** The full name can not be greter than 50 characters ***"); break; }

                        Console.Write("Enter the age: ");
                        if (!int.TryParse(Console.ReadLine().Trim(), out age)) { Console.WriteLine(invalidInputMessage); break; }
                        else if (age > 100 || age < 18) { Console.WriteLine("*** The age can not be less than 18 or greater than 100 ***"); break; }

                        if (_userService.Add(fullName, age)) { Console.WriteLine("-- User added successfully --"); break; }

                        Console.WriteLine("*** Failed to add user ***");
                        break;

                    case "2":
                        int id;

                        Console.Write("Type the user's id to disable: ");
                        if (!int.TryParse(Console.ReadLine().Trim(), out id) || id <= 0) { Console.WriteLine(invalidInputMessage); break; }

                        if (!_userService.UserIsActiveAndExists(id)) { Console.WriteLine($"*** Failed to disable the user with ID {id}. Check if the user with ID {id} exists or is already disabled ***"); break; } 

                        if (_userService.Disable(id)) { Console.WriteLine("-- User disable successfully --"); break; }

                        Console.WriteLine("*** Failed to disable the user. Please try again ***");
                        break;

                    case "3":
                        var listUsers = _userService.GetAll();

                        if (listUsers.Count == 0) { Console.WriteLine("-- There are no users. ---"); break; }

                        Console.WriteLine(new string('-', 77));
                        Console.WriteLine("| {0, -2} | {1, -50} | {2, -3} | {3, -9} |", "ID", "FULL NAME", "AGE", "IS ACTIVE");
                        Console.WriteLine(new string('-', 77));

                        foreach (var user in listUsers)
                        {
                            Console.WriteLine("| {0, -2} | {1, -50} | {2, -3} | {3, -9} |", user.Id, user.FullName, user.Age, user.IsActive ? "YES" : "NO");
                            Console.WriteLine(new string('-', 77));
                        }
                        break;

                    case "4": Console.WriteLine(exitMessage); await Task.Delay(2000); Console.Clear(); break;

                    case "cls": Console.Clear(); break;

                    default: Console.WriteLine(invalidInputMessage); break;


                }

            } while (option != "4");
        }

    }
}
