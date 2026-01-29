/*
Create a library system with:

A base class Item with properties Title and PublicationYear.

Child classes Book and Magazine. Book has Author, Magazine has IssueNumber.

A Library class that stores a list of Item objects.

Implement methods to add, remove, and list all items, showing their specific details.
 */


class Program
{
    static void Main(string[] args)
    {
        string option;
        Library l = new Library();
       do
        {
            Console.WriteLine("\n========= MENU =========" +
                              "\n1. Add item. " +
                              "\n2. Remove item. " +
                              "\n3. List items. " +
                              "\n4. Exit. ");
            Console.Write("Enter an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    string typeItem;
                    Console.WriteLine("What item do you want to add? ");
                    typeItem = Console.ReadLine().ToLower();

                    if (typeItem == "book")
                    {
                        Book b = new Book();
                        Console.Write("Enter a title: ");
                        b.Title = Console.ReadLine();

                        Console.Write("Enter a year of publication: ");
                        b.PublicationYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter author: ");
                        b.Author = Console.ReadLine();

                        l.AddItem(b);

                        Console.WriteLine("-- A BOOK was added --");
                    }

                    else if (typeItem == "magazine")
                    {
                        Magazine m = new Magazine();
                        Console.Write("Enter a title: ");
                        m.Title = Console.ReadLine();

                        Console.Write("Enter a year of publication: ");
                        m.PublicationYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter a issue number: ");
                        m.IssueNumber = Console.ReadLine();

                        l.AddItem(m);

                        Console.WriteLine("-- A MAGAZINE was added --");
                    }
                    else
                    {
                        Console.WriteLine($"*** {typeItem} don't exits ***");
                    }
                        break;

                case "2":
                    int index;
                    Console.Write("Enter the number of the item to eliminate: ");
                    index = Convert.ToInt32(Console.ReadLine());

                    if (index >= 0 && index < l.Objects.Count)
                    {
                        l.DeleteItem(index);
                        Console.WriteLine($"-- Item with the idex {index} was deleted --");
                    }
                    else
                    {
                        Console.WriteLine("*** Index was not found ***");
                    }
                        break;

                case "3":
                    Console.WriteLine("=== Items ===");
                    if (l.Objects.Count == 0)
                    {
                        Console.WriteLine("*** There are no items ***");
                    }
                    else
                    {
                        l.ShowItems();
                    }
                    break;

                case "4": Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("*** Invalid option ***"); break;
            }

        }while (option != "4");

        Console.ReadKey();
    }
}