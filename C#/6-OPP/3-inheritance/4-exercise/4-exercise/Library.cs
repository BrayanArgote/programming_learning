class Library
{
    private List<Item> objects;
    public List<Item> Objects
    { get { return objects; } }

    public Library()
    {
        objects = new List<Item>();
    }
    public void AddItem(Item inputItem)
    {
        objects.Add(inputItem);
    }

    public void ShowItems()
    {
        int index = 0;  
        foreach(var fr in objects)
        {
            if (fr is Book book)
            {
                Console.Write($"\n{index}. BOOK");
                Console.WriteLine($"\nTitle: {book.Title}" +
                                  $"\nPublication Year: {book.PublicationYear}" +
                                  $"\nAuthor: {book.Author}");
            }

            else if (fr is Magazine magazine)
            {
                Console.Write($"\n{index}. MAGAZINE");
                Console.WriteLine($"\nTitle: {magazine.Title}" +
                                  $"\nPublication Year: {magazine.PublicationYear}" +
                                  $"\nIssue number: {magazine.IssueNumber}");
            }
            index++;
        }
    }

    public void DeleteItem(int index)
    {
        objects.RemoveAt(index);
    }
}

