class Warrior : Character
{
    public Warrior(string name) : base(name) { }

    public override void Attack()
    {
        if (Health > 90)
        {
            Console.WriteLine($"****Attack**** \nDamage +{Health * 4}");
        }
        else { base.Attack(); }
    }
}
