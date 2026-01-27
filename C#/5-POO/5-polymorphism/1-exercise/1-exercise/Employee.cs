    abstract class Employee
    {
        public string Name { set; get; }
        public double Salary { set; get; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }
        public abstract string Work();

        public string GetInfo()
        {
        return $"{this.GetType().Name.ToUpper()}\nName: {Name} \nSalary: {Salary}";
        }
    }
