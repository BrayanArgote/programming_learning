    /*
    Create an interface IAnimal with a property Name and method Speak().
    Create classes Dog and Cat that implement the interface.
    Make a list of IAnimal and call Speak() on all animals.
    */


    class Program
    {
    static void Main(string[] args)
    {
        Cat c = new Cat();
        Dog d = new Dog("Rocko");

        List<IAnimal> animals = new List<IAnimal>{c, d};

        foreach (var fe in animals)
        {
            Console.WriteLine(fe.Speak());
        }

            Console.ReadKey();
        }
    }   