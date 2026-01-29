class Cat : IAnimal
{
    public string Name {  get; set; }

    public string Speak()
    {
        return "**** MEOW ****";
    }
}