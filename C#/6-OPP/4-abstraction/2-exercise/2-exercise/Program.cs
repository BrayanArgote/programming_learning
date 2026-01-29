/*
Create an abstract class called User.
It must have properties: Username, IsActive.

It must have:
an abstract method GetPermissions
a method Deactivate

Create two classes: AdminUser and ClientUser.

Rules:

Each user has different permissions.

Users are created using constructors.

Store users in an list.

Use conditions to skip inactive users.
 */

enum Actions { 
Deactive, Delete, Create, Read}


class Program
{
    public bool ConfirmationSession(User currentUser)
    {
        bool session = false;
        if (currentUser != null && currentUser.IsActive == true) { session = true; }
        return session;
    }

    public string SesionMessage()
    {
        return "You must log in to use this option";
    }

    static void Main(string[] args)
    {
        List<User> users = new List<User>();

        Program pr = new Program();
        AdminUser admin = new AdminUser("admin123");
        users.Add(admin);
        User currentUser = null;
        string option;

        do
        {
            Console.WriteLine("\n=================== MENU ====================" +
                              "\n1. Log in (any user)." +
                              "\n2. Create a user (any user)." +
                              "\n3. Desactivate status (admin and client)." +
                              "\n4. Delete a user (admin). " +
                              "\n5. Show users (admin). " +
                              "\n6. Show logged-in user. " +
                              "\n7. Exit... ");
            Console.Write("Enter an Option: ");
            option = Console.ReadLine();

            int temporalNumberOption;
            if (int.TryParse(option, out temporalNumberOption) && (currentUser == null && temporalNumberOption >= 3 && temporalNumberOption <= 6))
            {
                Console.WriteLine("*** You must log in to use this option ***");
            }

            else
            {
                // FIRST OPTION
                if (option == "1")
                {
                    Console.Write("Enter your user name: ");
                    string inputUserName = Console.ReadLine();
                    bool userExists = false;

                    foreach (var fr in users)
                    {
                        if (fr.UserName == inputUserName)
                        {
                            currentUser = fr;
                            userExists = true;
                            break;
                        }
                    }

                    if (userExists && currentUser.IsActive)
                    {
                        Console.WriteLine($"--- Welcome {currentUser.UserName} ({(currentUser is AdminUser ? "ADMIN" : "CLIENT")}) ---");

                    }

                    else { Console.WriteLine("*** user was not found ***"); }
                }

                // SECOND OPTION 
                else if (option == "2")
                {
                    Console.Write("Enter the name of the user: ");
                    ClientUser user = new ClientUser(Console.ReadLine().Trim());
                    users.Add(user);
                    Console.WriteLine($"--- A CLIENT user was created with the name {user} ---");
                }

                // THIRD OPTION 
                else if (option == "3" && pr.ConfirmationSession(currentUser))
                {

                    if (currentUser is ClientUser)
                    {
                        currentUser.Deactivate();
                        Console.WriteLine("--- Your account was deactivate ---");
                    }
                    else
                    {
                        Console.Write("Enter the user name: ");
                        string inputUserNam = Console.ReadLine().Trim();
                        bool flag = false;

                        foreach (var fr in users)
                        {
                            if (fr.UserName == inputUserNam && fr.UserName != admin.UserName)
                            {
                                currentUser.Deactivate();
                                Console.WriteLine($"--- The user *{currentUser.UserName}* was deactivate ---");
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Console.WriteLine($"*** User *{inputUserNam}*  was not found ***");
                        }
                    }
                    currentUser = null;
                }

                // FOURTH OPTION
                else if (option == "4" && pr.ConfirmationSession(currentUser))
                {

                    string userNameDelete;

                    if (currentUser.GetPermissions(Actions.Delete))
                    {
                        Console.Write("Enter the user name: ");
                        userNameDelete = Console.ReadLine().Trim();
                        if (currentUser.UserName == admin.UserName)
                        {
                            Console.WriteLine("*** You can not delete your account***");
                        }

                        else
                        {
                            foreach (var fr in users)
                            {
                                if (fr.UserName == userNameDelete)
                                {
                                    users.Remove(fr);
                                    Console.WriteLine($"--- The user * {userNameDelete} * was deleted ---");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("*** You don't have the permissions ***");
                    }
                    currentUser = null;
                }

                // FIFTH OPTION
                else if (option == "5" && pr.ConfirmationSession(currentUser))
                {
                    if (currentUser.GetPermissions(Actions.Read))
                    {
                        int numberUser = 1;
                        Console.WriteLine("\n=== Users ===");
                        foreach (var fa in users)
                        {
                            Console.WriteLine($"\nUser {numberUser}" +
                                              $"\nName: {fa.UserName}" +
                                              $"\nStatus: {(fa.IsActive ? "Activate" : "Inactivate")}");
                            numberUser++;
                        }
                    }
                    else { Console.WriteLine("*** You don't have the permissions ***"); }
                    currentUser = null;
                }

                // SIXTH OPTION 
                else if (option == "6" && pr.ConfirmationSession(currentUser))
                {
                    Console.WriteLine($"--- You are logged in as {currentUser.UserName} and you are *{(currentUser is AdminUser? "ADMIN" : "USER")}* ---");
                }

                // SEVENTH OPTION
                else if (option == "7")
                {
                    Console.WriteLine("Exiting ...");
                }

                // DEFAULT OPTION
                else { Console.WriteLine("*** Invalid option ***"); }
            }
        } while (option != "7");
        Console.ReadKey();
    }
}





