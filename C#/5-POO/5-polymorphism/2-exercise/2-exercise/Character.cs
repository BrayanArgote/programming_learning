class Character
{
    private string name;
    public string Name
    {
        get { return name; }
        set { if(!string.IsNullOrEmpty(value)) name = value; }
    }
    private double health;
    public double Health
    {
        get { return health; }
        set { if (value > 0) { health = value; } }
    }

    public Character(string name)
    {
        health = 100;
        this.name = name;
    }

    public virtual void Attack()
    {
        if (Health > 60)
        {
            Console.WriteLine($"\n****Attack***** \nDamage+{Health * 2}");
        }
        else { Console.WriteLine($"\n****Attack**** \nDamage +{Health * 1}"); }
    }
}