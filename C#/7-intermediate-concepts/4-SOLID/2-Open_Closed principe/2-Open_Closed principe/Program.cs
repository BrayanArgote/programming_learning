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
        services.AddScoped<PaymentMethodRepositoty>();

        var provider = services.BuildServiceProvider();

        var userRepository = provider.GetRequiredService<UserRepository>();
        var paymentRepository = provider.GetRequiredService<PaymentRepository>();
        var paymentMethodRepository = provider.GetRequiredService<PaymentMethodRepositoty>();


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
                    var users = userRepository.GetAll();
                    if (users.Count == 0)
                    {
                        Console.WriteLine("--- There are no users --");
                        break;
                    }
                    Console.WriteLine(new string('-',78));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} | {4, -17} |", "ID", "FULLNAME", "BALANCE (USD)", "DEBT (USD)", "Available Methods");
                    Console.WriteLine(new string('-', 78));
                    foreach (var u in users)
                    {
                        Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} | {4, -17} |", u.UserId, u.FullName, u.Balance, u.Debt, string.IsNullOrEmpty(string.Join("", u.ListPaymentMethods))? "No Methods" : string.Join(" - ", u.ListPaymentMethods));
                        Console.WriteLine(new string('-', 78));
                    }
                    break;

                case "2":
                    var payments = paymentRepository.GetAllPayments();
                    if (payments.Count == 0)
                    {
                        Console.WriteLine("-- There is no history of payments --");
                        break;
                    }
                    Console.WriteLine(new string('-', 70));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -10} | {3, -25} |", "ID", "User Name", "Method", "Date");
                    Console.WriteLine(new string('-', 70));
                    foreach (var p in payments)
                    {
                        Console.WriteLine("| {0, -2} | {1, -20} | {2, -10} | {3, -25} |", p.PaymentMethod.Type, p.User.FullName, p.Date);
                        Console.WriteLine(new string('-', 70));
                    }
                    break;

                case "3":
                    int id, method;
                    decimal amountPay;
                    Console.Write("Enter the user's id: ");

                    if (!int.TryParse(Console.ReadLine(), out id)) { Console.WriteLine("*** Please enter a valid id ***"); }
                    if (id <= 0) { Console.WriteLine("*** Please type a valid id ***"); }

                    var user = userRepository.GetUserById(id);

                    if (user == null) { Console.WriteLine($"-- The user with the id {id} was not found --"); break; }

                    Console.WriteLine(new string('-', 58));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} |", "ID", "FULLNAME", "BALANCE (USD)", "DEBT (USD)");
                    Console.WriteLine(new string('-', 58));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} |", user.UserId, user.FullName, user.Balance, user.Debt);
                    Console.WriteLine(new string('-', 58));

                    var methods = userRepository.GetPaymentMethodsUser(id);
                    if (methods.Count == 0) { Console.WriteLine("*** The user does not has methods ***"); break; }

                    Console.WriteLine(new string('-', 16));
                    Console.WriteLine("| {0, -2} | {1, -7} |", "ID", "METHODS");
                    Console.WriteLine(new string('-', 16));

                    foreach (var m in methods)
                    {
                        Console.WriteLine("| {0, -2} | {1, -7} |", m.PaymentMethodId, m.Type);
                        Console.WriteLine(new string('-', 16));
                    }
                    
                    Console.Write("Enter the id of the method: ");

                    if (!int.TryParse(Console.ReadLine(), out method) || method >= methods.Count) { Console.WriteLine("*** Please type a valid method ***"); break; }


                    Console.Write("Enter the amount to pay: ");
                    if(!decimal.TryParse(Console.ReadLine(), out amountPay)) { Console.WriteLine("*** Please type a valid amount ***"); break; }

                    if (amountPay <= 0) { Console.WriteLine("*** Please type a valid amount ***"); break; }

                    paymentRepository.MakePayment(id, amountPay, method);

                    break;

                case "4": Console.WriteLine("Exiting..."); break;
                case "cls" or "clear": Console.Clear(); break;
                default: Console.WriteLine("*** Please type a valid option ***"); break;
            }
        } while (option != "4");
    }


}