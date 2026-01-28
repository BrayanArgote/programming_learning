    /*
    Create an interface IBook with properties Title and Author, and a method Read().

    Create classes Fiction and NonFiction implementing the interface.
    Add a method Summarize() only in NonFiction.

    Create a list of IBook, loop through all books and call Read().
    Also, call Summarize() for NonFiction books only.
    */

    class Program
    {
        static void Main(string[] args)
        {
            List<IBook> books = new List<IBook>{new Fiction ("Nigromante", "Hector"),
    new NonFiction ("Mona Lisa Feliz", "Willian")};

            string option = "0";
            do
            {
                Console.WriteLine("\n===== MENU =====" +
                                  "\n1. Show books. " +
                                  "\n2. Add a book. " +
                                  "\n3. Read a book. " +
                                  "\n4. Leavea a main ideas (only non fiction books). " +
                                  "\n5. Exit. ");
                Console.Write("Enter the Option: ");
                option = Console.ReadLine().Trim();

                switch (option)
                {
                    case "1":
                        int numberFictionBook = 1, numberNonFictionBook = 1;

                        foreach (var fe in books)
                        {
                            if (fe is NonFiction nf)
                            {
                                Console.WriteLine($"\nNO FICTION BOOK {numberNonFictionBook}");
                                Console.WriteLine($"Title: {fe.Title}" +
                                                  $"\nAuthor: {fe.Author}");
                                Console.WriteLine($"Main Ideas: {string.Join(" - ", nf.MainIdeas)}");
                                numberNonFictionBook++;
                            }
                        }

                        foreach (var fe in books) {
                            if (fe is Fiction f)
                            {
                                Console.WriteLine($"\nFICTION BOOK {numberFictionBook}");
                                Console.WriteLine($"Title: {fe.Title}" +
                                                  $"\nAuthor: {fe.Author}");
                                numberFictionBook++;
                            }
                        }
                        break;

                    case "2":

                        string inputTypeBook;
                        Console.Write("Enter the type of the book that you want to add (Fiction - NonFiction): ");
                        inputTypeBook = Console.ReadLine().Trim();
                        Type t = Type.GetType(inputTypeBook);

                        if (t != null)
                        {
                            Console.Write("Enter the Title: ");
                            string title = Console.ReadLine().Trim();

                            Console.Write("Enter the Author: ");
                            string author = Console.ReadLine().Trim();

                            IBook book = (IBook)Activator.CreateInstance(t, title, author);
                            books.Add(book);
                            Console.WriteLine($"--- The {t} book with title *{title}* was add ---");
                        }
                        else { Console.WriteLine($"*** {inputTypeBook} don't exits ***"); }
                        break;

                    case "3":

                        string inputTitle;
                        bool flag = false;

                        Console.Write("Enter the book's name: ");
                        inputTitle = Console.ReadLine().Trim().ToLower();

                        foreach (var fe in books)
                        {
                            if (fe.Title.ToLower() == inputTitle)
                            {
                                Console.WriteLine(fe.Read());
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            Console.WriteLine($"*** There's no a book with the title *{inputTitle}* ***");
                        }
                        break;

                    case "4":
                        string inputTitleMainIdea;
                        Console.Write("Enter the name of the book: ");
                        inputTitleMainIdea = Console.ReadLine().Trim();
                        var exists = books.Find(t => t.Title == inputTitleMainIdea);

                        if (exists != null && exists is NonFiction n)
                        {
                            n.Summarize();
                            Console.WriteLine($"-- Main ideas was added to *{n.Title}* --");
                        }
                        
                        else { Console.WriteLine($"*** Non Fiction Book with the title *{inputTitleMainIdea}* was not found ***"); }

                        break;
                    

                    case "5": Console.WriteLine("Exiting... "); break;
                    default: Console.WriteLine("*** Please type a vaid option ***"); break;
                }
            }
            while (option != "5");
            Console.ReadKey();
        }
    }

