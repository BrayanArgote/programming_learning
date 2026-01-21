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
;        do
        {
            Console.WriteLine("\n======= MENU =======" +
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
                    Console.WriteLine("What item do you want to add?");
                    typeItem = Console.ReadLine().ToLower();

                    if (typeItem == "book")
                    {
                        Book b = new Book();
                        Console.Write("Enter a title: ");
                        b.Title = Console.ReadLine();

                        Console.Write("Enter a title: ");
                        b.PublicationYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter a title: ");
                        b.Author = Console.ReadLine();


                    }

                    else if (typeItem == "magazine")
                    {
                        Magazine m = new Magazine();
                        Console.Write("Enter a title: ");
                        m.Title = Console.ReadLine();

                        Console.Write("Enter a title: ");
                        m.PublicationYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter a title: ");
                        m.IssueNumber = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("*** Item was not found ***");
                    }

                        break;
                case "2": break;
                case "3": break;
                case "4": Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("*** Invalid option ***"); break;
            }

        }while (option != "4");

        Console.ReadKey();
    }
}