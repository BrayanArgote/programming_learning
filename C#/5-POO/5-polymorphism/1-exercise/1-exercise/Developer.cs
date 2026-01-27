class Developer: Employee
{
    private string[] languajes;
    public string[] Languajes
    {
        get { return languajes; } 
    }

    public Developer(string name, double salary, string[] languajes) : base(name, salary)
    {
        this.languajes = languajes;
    }

    public override string Work()
    {
        return "Writing code";
    }

    public new string GetInfo()
    {
        return $"{base.GetInfo()}\nLanguajes: {String.Join(" - ", Languajes)}";
    }
}

