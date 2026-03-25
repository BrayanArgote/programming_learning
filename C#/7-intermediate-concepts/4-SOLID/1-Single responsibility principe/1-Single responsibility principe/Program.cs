using _1_Single_responsibility_principe;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("DbMemory"));

        var servicesProvider = services.BuildServiceProvider();
        var context = servicesProvider.GetRequiredService<AppDbContext>();

        string option, name, favoriteSubject;
        int age, id;
        var studentRepository = new StudentRepository(context);
        var CSVReporter = new CSVReporter();
        bool InputIsValid(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("*** The field is required ***");
                return false;
            }
            return true;
        }

        do
        {
            Console.WriteLine("\n==== MENU ====" +
                              "\n1. Add student." +
                              "\n2. Delete student." +
                              "\n3. Show all student." +
                              "\n4. Generate CSV file. " +
                              "\n5. Clear." +
                              "\n6. Exit.");
            Console.Write("Enter an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter the student's name: ");
                    name = Console.ReadLine();
                    if (!InputIsValid(name)) { break; }

                    Console.Write("Enter the student's age: ");
                    if (!int.TryParse(Console.ReadLine(), out age))
                    {
                        Console.WriteLine("*** Enter a valid format ***");
                        break;
                    }

                    if (age > 100 || age < 5)
                    {
                        Console.WriteLine("*** Please type a valid age ***");
                        break;
                    }

                    Console.Write("Enter the student's favorite subject: ");
                    favoriteSubject = Console.ReadLine();
                    if (!InputIsValid(favoriteSubject)) { break; }

                    studentRepository.AddStudent(name, age, favoriteSubject);
                    Console.WriteLine("--- Student added sucessfully---");
                    break;

                case "2":
                    Console.Write("Enter the id: ");
                    if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                    {
                        Console.WriteLine("*** Please type a valid id ***"); break;
                    }
                    if (studentRepository.DeleteStudent(id))
                    {
                        Console.WriteLine("--- Student deleted sucessfully ---"); break;
                    }
                    Console.WriteLine($"-- Student with the id *{id}* was not found --");
                    break;

                case "3":
                    var students = studentRepository.GetAllStudents();

                    if (students.Count == 0) { Console.WriteLine("--- There are no students ---"); break; }

                    Console.WriteLine("\n" + new string('-', 52));
                    Console.WriteLine("| {0,-3}| {1,-19}| {2,-4}| {3,-17}|", "ID", "NAME", "AGE", "FAVORITE SUBJECT");
                    Console.WriteLine(new string('-', 52));

                    foreach (var student in students)
                    {
                        Console.WriteLine("| {0,-3}| {1,-19}| {2,-4}| {3,-17}|", student.Id, student.Name, student.Age, student.FavoriteSubject);
                        Console.WriteLine(new string('-', 52));
                    }
                    break;

                case "4":
                    var listStudent = studentRepository.GetAllStudents();
                    if (listStudent.Count == 0)
                    {
                        Console.WriteLine("-- There are no students --");
                        break;
                    }
                    CSVReporter.GenerateCSV(listStudent);
                    Console.WriteLine("--- CSV file generate sucessfully ---");
                    break;

                case "5": Console.Clear(); break;

                case "6": Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("*** Invalid option ***"); break;

            }
        } while (option != "6");

        Console.ReadKey();
    }
}
    
