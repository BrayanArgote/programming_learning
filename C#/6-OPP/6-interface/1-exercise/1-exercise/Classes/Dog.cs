class Dog : IAnimal
{
    public string Name { get; set; }

    public Dog(string Name) {
        this.Name = Name;
    }

    public string Speak(){
        return $"{Name} is barking \n*** WOOF ***";
    }

}