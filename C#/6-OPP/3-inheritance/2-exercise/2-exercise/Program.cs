/*
Create a base class that represents an Employee.
It must contain data shared by all employees and a method related to work.

Create a child class Manager that:

Inherits from Employee.
Adds new responsibilities.

Changes the behavior of one inherited method (if allowed).

Focus on deciding:

What belongs to the base class.

What belongs only to the child class.
 */

class Employee
{
    private string name;
    public string Name {
        get { return name; }
        set { if (value != null) { name = value; } }
    }

    private string phoneNumber;
    public string PhoneNumber{
        get { return phoneNumber;  }
        set { if (value != null && value.Length == 10) { phoneNumber = value; } }
    }
    public double hourlyRate { get; set; }

    public Employee()
    {
        hourlyRate = 100;
    }

    public virtual double CalculateSalary(int numberHours)
    {
        double salary = hourlyRate * (double)numberHours;
        return salary;
    }
}


class Manager : Employee
{
    public override double CalculateSalary(int numberHours)
    {
        double salary = (hourlyRate + 150) * (double)numberHours;
        return salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager m = new Manager();
        Employee e = new Employee();

        Console.Write("Enter the hours worked: ");
        int hours = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Basic salary: $" + e.CalculateSalary(hours));
        Console.WriteLine("Basic salary to manager: $" + m.CalculateSalary(hours));


        Console.ReadKey();
    }
}
