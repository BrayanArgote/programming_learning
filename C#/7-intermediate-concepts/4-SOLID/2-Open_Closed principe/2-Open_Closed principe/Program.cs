using _2_Open_Closed_principe.DataBase;
using _2_Open_Closed_principe.DTO;
using _2_Open_Closed_principe.Repository;
using _2_Open_Closed_principe.Services;
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
        services.AddScoped<CashPayment>();
        services.AddScoped<NequiPayment>();

        var provider = services.BuildServiceProvider();

        var userRepository = provider.GetRequiredService<UserRepository>();
        var paymentRepository = provider.GetRequiredService<PaymentRepository>();
        var cashPayment = provider.GetRequiredService<CashPayment>();
        var nequiPayment = provider.GetRequiredService<NequiPayment>();


        string option;
        bool InvalidBill(int bill)
        {
            if (bill == 1 || bill == 2 || bill == 5 || bill == 10 || bill == 20 || bill == 50 || bill == 100)
            {
                return false;
            }
            return true;
        }

        int ValidateInteger()
        {
            int numberReturn;
            Console.Write("Insert the bill: ");
            if (int.TryParse(Console.ReadLine(), out numberReturn)) { return numberReturn; }
            return 0;
        }

        bool InputIsValid(string input)
        {
            int number;
            if (int.TryParse(input, out number)) { return true; }
            return false;
        }

        string MessageIncorrectInput = "*** Please type a valid data ***";

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
                    Console.WriteLine(new string('-', 78));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} | {4, -17} |", "ID", "FULLNAME", "BALANCE (USD)", "DEBT (USD)", "Available Methods");
                    Console.WriteLine(new string('-', 78));
                    foreach (var u in users)
                    {
                        Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} | {4, -17} |", u.UserId, u.FullName, u.Balance, u.Debt, string.IsNullOrEmpty(string.Join("", u.ListPaymentMethods)) ? "No Methods" : string.Join(" - ", u.ListPaymentMethods));
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
                    Console.WriteLine(new string('-', 85));
                    Console.WriteLine("| {0, -2} | {1, -18} | {2, -10} | {3, -14} | {4, -25} |", "ID", "USER NAME", "METHOD", "AMOUNT (USD)", "DATE");
                    Console.WriteLine(new string('-', 84));
                    foreach (var p in payments)
                    {
                        Console.WriteLine("| {0, -2} | {1, -18} | {2, -10} | {3, -14} | {4, -25} |", p.PaymentId, p.User.FullName, p.PaymentMethod.Type, p.Amount, p.Date);
                        Console.WriteLine(new string('-', 85));
                    }
                    break;

                case "3":
                    int id;
                    string method;
                    decimal amountPay;
                    Console.Write("Enter the user's id: ");

                    if (!int.TryParse(Console.ReadLine(), out id)) { Console.WriteLine(MessageIncorrectInput); break; }
                    if (id <= 0) { Console.WriteLine(MessageIncorrectInput); break; }

                    var user = userRepository.GetById(id);

                    if (user == null) { Console.WriteLine($"-- The user with the id {id} was not found --"); break; }

                    Console.WriteLine(new string('-', 58));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} |", "ID", "FULLNAME", "BALANCE (USD)", "DEBT (USD)");
                    Console.WriteLine(new string('-', 58));
                    Console.WriteLine("| {0, -2} | {1, -20} | {2, -13} | {3, -10} |", user.UserId, user.FullName, user.Balance, user.Debt);
                    Console.WriteLine(new string('-', 58));

                    var methods = userRepository.GetPaymentMethodsUser(id);
                    if (methods.Count == 0) { Console.WriteLine("*** The user does not has methods ***"); break; }
                    if (userRepository.GetDebt(id) == 0) { Console.WriteLine("-- The user has no debt --"); break; }

                    Console.WriteLine(new string('-', 16));
                    Console.WriteLine("| {0, -2} | {1, -7} |", "ID", "METHODS");
                    Console.WriteLine(new string('-', 16));

                    foreach (var m in methods)
                    {
                        Console.WriteLine("| {0, -2} | {1, -7} |", m.PaymentMethodId, m.Type);
                        Console.WriteLine(new string('-', 16));
                    }

                    Console.Write("Enter the id of the method: ");
                    method = Console.ReadLine();

                    switch (method)
                    {
                        case "1":
                            string phoneNumber, code;
                            decimal amount;

                            Console.Write("Enter the phone number: ");
                            phoneNumber = Console.ReadLine().Trim();
                            if (!InputIsValid(phoneNumber) || phoneNumber.Length != 10) { Console.WriteLine(MessageIncorrectInput); break; }

                            Console.Write("Enter the amount to pay: ");
                            if (!decimal.TryParse(Console.ReadLine(), out amount)) { Console.WriteLine(MessageIncorrectInput); break; }

                            Console.WriteLine("-- Sending Code --");

                            Console.Write("Enter the code: ");
                            code = Console.ReadLine();
                            if (!InputIsValid(code) || code.Length != 4) { Console.WriteLine(MessageIncorrectInput); break; }

                            Console.WriteLine(nequiPayment.MakePayment(new PaymentRequestNequi(id, amount, Convert.ToInt32(method), phoneNumber, code)));

                            break;
                        case "2":
                            int firstBill, secondBill, thirdBill;

                            firstBill = ValidateInteger();
                            if (firstBill == 0 || InvalidBill(firstBill)) { Console.WriteLine(MessageIncorrectInput); break; }

                            secondBill = ValidateInteger();
                            if (secondBill == 0 || InvalidBill(secondBill)) { Console.WriteLine(MessageIncorrectInput); break; }

                            thirdBill = ValidateInteger();
                            if (thirdBill == 0 || InvalidBill(thirdBill)) { Console.WriteLine(MessageIncorrectInput); break; }

                            Console.WriteLine(cashPayment.MakePayment(new PaymentRequestCash(id, Convert.ToInt16(method), firstBill, secondBill, thirdBill)));
                            break;
                        default: Console.WriteLine("*** Please type a valid method ***"); break;
                    }
                    break;

                case "4": Console.WriteLine("Exiting..."); break;
                case "cls" or "clear": Console.Clear(); break;
                default: Console.WriteLine("*** Please type a valid option ***"); break;
            }
        } while (option != "4");
    }


}
