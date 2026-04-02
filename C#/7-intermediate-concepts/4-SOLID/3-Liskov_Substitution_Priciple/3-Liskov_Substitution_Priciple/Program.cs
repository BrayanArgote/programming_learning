using _3_Liskov_Substitution_Priciple.DataBase;
using _3_Liskov_Substitution_Priciple.DTO;
using _3_Liskov_Substitution_Priciple.Entities;
using _3_Liskov_Substitution_Priciple.Repository;
using _3_Liskov_Substitution_Priciple.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=localhost;DataBase=Notification;Trusted_Connection=True;TrustServerCertificate=True"));

        services.AddScoped<NotificationLogRepository>();
        services.AddScoped<NotificationChannelRepository>();
        services.AddScoped<NotifierEmail>();
        services.AddScoped<NotifierSMS>();

        var provider = services.BuildServiceProvider();

        var notificationLogRepository = provider.GetRequiredService<NotificationLogRepository>();
        var notificationChannelRepository = provider.GetRequiredService<NotificationChannelRepository>();
        var notifierEmail = provider.GetRequiredService<NotifierEmail>();
        var notifierSms = provider.GetRequiredService<NotifierSMS> ();

        string messageIncorrectInput = "*** Please type a valid data ***";
        string MessageEmptyLength(int length)
        {
            return $"*** The field can not be less than 0 or greater than {length} ***";
        }
        string messageNotificationSend = "-- Notification sent successfully --";
        string messageNotificationNotSend = "-- Failed to send the notification --";

        int senderAndRecipientLength = 20, contentLength = 50;
        string InputHasValidLength (string input, int length)
        {
            if (input.Length <= length && input.Length > 0) { return input; }
            return "0";
        }

        string option;

        do
        {
            Console.WriteLine("\n=== MENU ===" +
                              "\n1. Send Message." +
                              "\n2. Show History." +
                              "\n3. Exit. ");
            Console.Write("Enter an option: ");
            option = Console.ReadLine().Trim();

            switch (option)
            {
                case "1":
                    var listNotificationChannel = notificationChannelRepository.GetAll();

                    if (listNotificationChannel.Count == 0) { Console.WriteLine("-- There are no available chanels --"); break; }
                    Console.WriteLine(new string('-', 19));
                    Console.WriteLine("| {0, -2} | {1, -10} |", "ID", "TYPE");
                    Console.WriteLine(new string('-', 19));

                    foreach (var l in listNotificationChannel)
                    {
                        Console.WriteLine("| {0, -2} | {1, -10} |", l.Id, l.Type);
                        Console.WriteLine(new string('-', 19));
                    }


                    int methodId;
                    string sender, recipient, subject, content, resultExecuteMethod;
                    Console.Write("Enter the method's id: ");
                    if (!int.TryParse(Console.ReadLine(), out methodId)) { Console.WriteLine(messageIncorrectInput); break; }

                    switch (methodId)
                    {
                        case 1:

                            Console.Write("Enter the sender: ");
                            sender = Console.ReadLine().Trim();
                            if (InputHasValidLength(sender, senderAndRecipientLength) == "0") { Console.WriteLine(MessageEmptyLength(senderAndRecipientLength)); break; }

                            Console.Write("Enter the Recipient: ");
                            recipient = Console.ReadLine().Trim();
                            if (InputHasValidLength(recipient, senderAndRecipientLength) == "0") { Console.WriteLine(MessageEmptyLength(senderAndRecipientLength)); break; }

                            Console.Write("Enter the subject: ");
                            subject = Console.ReadLine().Trim();
                            Console.Write("Enter the content: ");
                            content = Console.ReadLine().Trim();
                            if (InputHasValidLength(subject + content, contentLength) == "0") { Console.WriteLine(MessageEmptyLength(senderAndRecipientLength)); break; }

                            Console.WriteLine("\n-- Sending notification... \n");
                            Thread.Sleep(3000);

                            notifierEmail.Send(new NotificationRequestEmail(methodId, sender, recipient, content, subject));
                            resultExecuteMethod = notifierSms.Send(new NotificationRequestSms(methodId, sender, recipient, content)) == true ? messageNotificationSend : messageNotificationNotSend;
                            Console.WriteLine(resultExecuteMethod);

                            break;

                        case 2:

                            Console.Write("Enter the sender: ");
                            sender = Console.ReadLine().Trim();
                            if (InputHasValidLength(sender, senderAndRecipientLength) == "0") { Console.WriteLine(MessageEmptyLength(senderAndRecipientLength)); break; }

                            Console.Write("Enter the Recipient: ");
                            recipient = Console.ReadLine().Trim();
                            if (InputHasValidLength(recipient, senderAndRecipientLength) == "0") { Console.WriteLine(MessageEmptyLength(senderAndRecipientLength)); break; }

                            Console.Write("Enter the content: ");
                            content = Console.ReadLine();
                            if (InputHasValidLength(recipient, senderAndRecipientLength) == "0") { Console.WriteLine(MessageEmptyLength(senderAndRecipientLength)); break; }

                            Console.WriteLine("\n-- Sending notification... \n");
                            Thread.Sleep(3000);

                            resultExecuteMethod = notifierSms.Send(new NotificationRequestSms(methodId, sender, recipient, content)) == true ? messageNotificationSend : messageNotificationNotSend;
                            Console.WriteLine(resultExecuteMethod);
                            break;

                        default: Console.WriteLine(messageIncorrectInput); break;
                    }

                    break;

                case "2":
                    var listNotificationLog = notificationLogRepository.GetAll();

                    if (listNotificationLog.Count == 0) { Console.WriteLine("-- There is no historial --"); break; }

                    Console.WriteLine(new string('-', 110));
                    Console.WriteLine("{0, -2} | {1, -9} | {2, -20} | {3, -20} | {4, -45} |", "ID", "CHANNEL", "SENDER", "RECIPIENT", "CONTENT");
                    Console.WriteLine(new string('-', 110));

                    foreach (var l in listNotificationLog)
                    {
                        Console.WriteLine("{0, -2} | {1, -9} | {2, -20} | {3, -20} | {4, -45} |", l.Id, l.NotificationChannel.Type, l.Sender, l.Recipient, l.Content);
                        Console.WriteLine(new string('-', 110));
                    }

                    break;

                case "3": Console.WriteLine("-- Exiting... "); break;
                    

                case "cls" or "clear": Console.Clear(); break;

                default: Console.WriteLine("*** Please type a valid option. ***"); break;
            }

        } while (option != "3");
    }

}

// Messing validation for the format of sender and recipient in both channels (only ten-digits numbers in SMS and a valid email in email )