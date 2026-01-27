/*
 Create an abstract class Employee with properties: Name, Salary.

Add an abstract method Work().

Create two classes: Manager and Developer.
Manager.Work() prints "Managing projects".
Developer.Work() prints "Writing code".

Store several employees in an array of Employee.

Use a loop to call Work() on each employee.

Add a method in Employee called GetInfo() but not virtual or abstract, and use it in the children.

*/


class Program
{
    static void Main(string[] args)
    {

        Employee[] employees = new Employee[] {
            
            // DEVS
            new Developer("Juan", 100, new string[] { "C#", "CSS" }),
            new Developer("Juana", 120, new string[] { "JAVA", "PYTHON" }),

            // MANAGER
            new Manager ("Lucas", 200),
            new Manager ("Lucia", 240)

        };

        for (int option = 0; option != 3; )
        {
            Console.WriteLine("\n====== MENU ======" +
                              "\n1. Show employes. " +
                              "\n2. Search employes. " +
                              "\n3. Exit. ");
            Console.Write("Enter Option: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("\n=== EMPLOYEES ===");
                    int numberEmployee = 1;

                    foreach(var fa in employees)
                    {
                        Console.WriteLine($"\n--- Employee {numberEmployee} ---");
                        Console.WriteLine(fa.GetInfo());
                        numberEmployee++;
                    }
                    break;

                case 2:
                    string nameEmployee;
                    Console.Write("Enter the name of the employee: ");
                    nameEmployee = Console.ReadLine().Trim();
                    bool flag = false;
                    
                    foreach(var fr in employees)
                    {
                        if (fr.Name == nameEmployee)
                        {
                            Console.WriteLine("==================");
                            Console.WriteLine(fr.GetInfo());
                            Console.WriteLine($"{fr.Name} is *{fr.Work()}*");
                            Console.WriteLine("==================");
                            flag = true;
                            break;
                        }
                    }
                    if (!flag) { Console.WriteLine($"*** Employee with the name {nameEmployee} don't exits ***"); }
                    break;

                case 3:Console.WriteLine("Exiting... "); break;
                default: Console.WriteLine("*** Please type a valid option ***"); break;
            }
        }

        Console.ReadKey();
    }
}