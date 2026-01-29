/*
"Create a Product class and use a static attribute to count 
how many Product objects have been created so far. 
Every time you create a new product, the counter must increase."
 */


class Product
{
    public static int counter =0;
    public string Name { get; set; } 

    public Product(string name)
    {
        Name = name;
        counter++;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product p1 = new Product("Cherry");
        Product p2 = new Product("Orange");
        Product p3 = new Product("Grape");

        Console.WriteLine("Products number: " + Product.counter);
        Console.ReadKey();

    }
}