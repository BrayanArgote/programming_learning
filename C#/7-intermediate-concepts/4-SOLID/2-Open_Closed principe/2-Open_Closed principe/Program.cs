using _2_Open_Closed_principe.DataBase;
using _2_Open_Closed_principe.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Programa
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=localhost;DataBase=Bank;Trusted_Connection=True;TrustServerCertificate=True"));

        services.AddScoped<UserRepository>();
        services.AddScoped<PaymentRepository>();

        var provider = services.BuildServiceProvider();

        var userRepository = provider.GetRequiredService<UserRepository>();
        var paymentRepository = provider.GetRequiredService<PaymentRepository>();


        string option;

        do
        {
            Console.WriteLine("\n==== MENU ===" +
                              "\n1. Show users." +
                              "\n2. Show history pays." +
                              "\n3. Realize pay. " +
                              "\n4. Exit.");
            Console.Write("Enter an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var users = userRepository.GetAllUsers();
                    if (users.Count == 0)
                    {
                        Console.WriteLine("--- There are no users --");
                        break;
                    }
                    Console.WriteLine(new string('-', 45));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} |", "ID", "FULLNAME", "BALANCE (USD)");
                    Console.WriteLine(new string('-', 45));
                    foreach (var u in users)
                    {
                        Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} |", u.UserId, u.FullName, u.Balance);
                        Console.WriteLine(new string('-', 45));
                    }
                    break;

                case "2":
                    var payments = paymentRepository.GetAllPayments();
                    if (payments.Count == 0)
                    {
                        Console.WriteLine("-- There is no histoty of payments --");
                        break;
                    }
                    Console.WriteLine(new string('-', 70));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -10} | {3, -25} |", "ID", "User Name", "Method", "Date");
                    Console.WriteLine(new string('-', 70));
                    foreach (var p in payments)
                    {
                        Console.WriteLine("| {0, -2} | {1, -20} | {2, -10} | {3, -25} |", p.PaymentId, p.User.FullName, p.Method, p.Date);
                        Console.WriteLine(new string('-', 70));
                    }
                    break;

                case "3":
                    int id;
                    decimal amountPay;
                    Console.Write("Enter the user's id: ");

                    if (!int.TryParse(Console.ReadLine(), out id)) { Console.WriteLine("*** Please enter a valid id ***"); }
                    if (id <= 0) { Console.WriteLine("*** Please type a valid id ***"); }

                    var user = userRepository.GetUserById(id);

                    if (user == null) { Console.WriteLine($"-- The user with the id {id} was not found --"); break; }

                    Console.WriteLine(new string('-', 45));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} |", "ID", "FULLNAME", "BALANCE (USD)");
                    Console.WriteLine(new string('-', 45));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} |", user.UserId, user.FullName, user.Balance);
                    Console.WriteLine(new string('-', 45));

                    Console.Write("Enter the amount to pay: ");
                    if(!decimal.TryParse(Console.ReadLine(), out amountPay)) { Console.WriteLine("*** Please type a valid amount ***"); break; }

                    if (amountPay <= 0) { Console.WriteLine("*** Please type a valid amount ***"); break; }

                    break;

                case "4": Console.WriteLine("Exiting..."); break;
                case "cls" or "clear": Console.Clear(); break;
                default: Console.WriteLine("*** Please type a valid option ***"); break;
            }
        } while (option != "4");
    }


}