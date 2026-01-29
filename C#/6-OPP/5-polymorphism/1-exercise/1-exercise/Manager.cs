class Manager : Employee
{

   public Manager( string name, double salary) :base(name, salary) { }

 
    public override string Work()
    {
        return "Managing projects";
    }
}

