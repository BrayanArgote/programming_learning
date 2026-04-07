using _4_Interface_Segregation_Principle.Entities;
using _4_Interface_Segregation_Principle.Services;

namespace _4_Interface_Segregation_Principle
{
    public class ActivityManagement
    {
        private readonly UserService _userService;
        private readonly ActivityService _activityService;

        private int userNameValidLength = 20;
        private int passwordValidLength = 10;
        private int monthsMaximumDate = 3;
        private string invalidInputMessage = "*** Please type a valid data ***";
        private string invalidLengthMessage = "*** The field can't be greater than ";
        private string operationCreateFailedMessage = "*** Failed to add a ";
        private string operationCreateMessage = " was create succesful --";
        

        public ActivityManagement(UserService userService, ActivityService activityService)
        {
            _userService = userService;
            _activityService = activityService;
        }
      

        public async Task MainMenu()
        {
            string option, userName, password;
            do
            {
                Console.WriteLine("\n==== MAIN MENU ====" +
                                  "\n1. Log in. " +
                                  "\n2. Create user. " +
                                  "\n3. Exit. ");
                Console.Write("Enter an option: ");
                option = Console.ReadLine().Trim();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter your user name: ");
                        userName = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(userName)) { Console.WriteLine(invalidInputMessage); break; }

                        Console.Write("Enter your password: ");
                        password = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(password)) { Console.WriteLine(invalidInputMessage); break; }

                        if (!_userService.UserExists(userName, password)) { Console.WriteLine("-- Invalid credentials --"); break; }

                        Console.Clear();

                        await LoggedInUserMenu(_userService.GetId(userName));
                        break;

                    case "2":
                        Console.Write("Enter a username: ");
                        userName = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(userName)) { Console.WriteLine(invalidInputMessage); break; }
                        else if (userName.Length > userNameValidLength) { Console.WriteLine(invalidLengthMessage + userNameValidLength); break; }
                        else if (_userService.UserNameExists(userName)) { Console.WriteLine($"*** The username {userName} already exists ***"); break; }

                        Console.Write("Enter a password: ");
                        password = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(password)) { Console.WriteLine(invalidInputMessage); break; }
                        else if (password.Length > passwordValidLength) { Console.WriteLine(invalidLengthMessage + passwordValidLength); break; }

                        if (!_userService.Add(userName, password)) { Console.WriteLine(operationCreateFailedMessage + "user ***"); break; }
                        Console.WriteLine("-- User" + operationCreateMessage);
                        break;

                    case "3": Console.WriteLine("Exiting... "); break;
                    case "cls" or "clear": Console.Clear(); break;
                    default: Console.WriteLine(invalidInputMessage); break;
                }
            } while (option != "3");
        } 

        private async Task LoggedInUserMenu(int idUser)
        {
            string option;

            do
            {
                Console.WriteLine("\n==== USER MENU ====" +
                                 $"\nUSER: {_userService.GetUserName(idUser)} \n" + 
                                  "\n1. Add activity. " +
                                  "\n2. Show all activities. " +
                                  "\n3. Show incompleted activities. " +
                                  "\n4. Mark activity as complete. " +
                                  "\n5. Exit. ");
                Console.Write("Enter an option: ");
                option = Console.ReadLine().Trim();

                switch (option)
                {
                    case "1":
                        string title, description;
                        DateOnly dueTime;

                        Console.Write("Enter the title: ");
                        title = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(title)) { Console.WriteLine(invalidInputMessage); break; }
                        else if (title.Length > 30) { Console.WriteLine(invalidLengthMessage + "30 ***"); break; }

                        Console.Write("Enter the description (optional): ");
                        description = Console.ReadLine().Trim();
                        if (description.Length > 40) { Console.WriteLine(invalidLengthMessage + "40 ***"); break; }

                        Console.Write("Enter the due date (DD/MM/YYYY): ");
                        if (!DateOnly.TryParse(Console.ReadLine().Trim(), out dueTime)) { Console.WriteLine(invalidInputMessage); break; }
                        else if (dueTime <= DateOnly.FromDateTime(DateTime.Now) || dueTime > DateOnly.FromDateTime(DateTime.Now).AddMonths(monthsMaximumDate)) {
                            Console.WriteLine($"The due date can't be later than {DateOnly.FromDateTime(DateTime.Now).AddMonths(monthsMaximumDate)} or before {DateOnly.FromDateTime(DateTime.Now)}" ); 
                            break; }

                        if (!_activityService.Add(idUser, title, description, dueTime)) { Console.WriteLine(operationCreateFailedMessage + "activity ***"); break; }

                        Console.WriteLine("-- Activity" + operationCreateMessage);

                        break;

                    case "2":
                        Console.WriteLine("-- Searching ...");

                        var listActivities = await _activityService.GetAll(idUser);
                        if (listActivities.Count == 0) { Console.WriteLine("-- You don't have any activities --"); break; }

                        PrintActivities(listActivities);

                        break;

                    case "3":
                        Console.WriteLine("Searching...");
                        var listIncompletedActivities = await _activityService.GetNotCompleted(idUser);

                        if (listIncompletedActivities.Count == 0) { Console.WriteLine("-- You don't have any incomplete activities --"); break; }

                        PrintActivities(listIncompletedActivities);

                        break;

                    case "4":
                        int idActivity;
                        string answer;
                        Console.Write("Enter the id of the activity: ");
                        if (!int.TryParse(Console.ReadLine().Trim(), out idActivity) || idActivity <= 0) { Console.WriteLine(invalidInputMessage); break; }

                        var activity = _activityService.GetByIdAndUser(idActivity, idUser);

                        if (activity == null) { Console.WriteLine($"-- The activity with ID {idActivity} doesn't exists --"); break; }

                        PrintActivities(new List<Activity> { activity });

                        if (activity.IsCompleted) {Console.WriteLine("-- This activity is alredy completed --"); break; }

                        Console.WriteLine("Do you want to mark this activity as completed? (YES - NO)");
                        answer = Console.ReadLine().Trim().ToUpper();

                        if (answer == "YES")
                        {
                            if (_activityService.MarkAsCompleted(idActivity, idUser)) { Console.WriteLine("-- Activity completed --"); break; }
                            Console.WriteLine("*** Failed to mark as complete this activity ***");
                        }

                        else if (answer == "NO") { break; }

                        else { Console.WriteLine(invalidInputMessage); break; }
                        break;

                    case "5": Console.WriteLine("Exiting... "); Task.Delay(2000).Wait(); Console.Clear(); break;
                    case "cls" or "clear": Console.Clear(); break;
                    default: Console.WriteLine(invalidInputMessage); break;
                }

            } while (option != "5");
        }

        private void PrintActivities(List<Activity> activities)
        {
            Console.WriteLine(new string('-', 116));
            Console.WriteLine("| {0, -2} | {1, -32} | {2, -42} | {3, -12} | {4, -12} |", "ID", "TITLE", "DESCRIPTION", "DUE DATE", "IS COMPLETED");
            Console.WriteLine(new string('-', 116));

            foreach (var item in activities)
            {
                Console.WriteLine("| {0, -2} | {1, -32} | {2, -42} | {3, -12} | {4, -12} |", item.Id, item.Title, item.Description, item.DueDate, item.IsCompleted ? "YES" : "NO");
                Console.WriteLine(new string('-', 116));
            }
        }
    }
}
