class NonFiction : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string[] MainIdeas { get; set; }

    public NonFiction(string title, string author)
    {
        Title = title;
        Author = author;
        MainIdeas = new string[2];
    }

    public string Read()
    {
        return $"Showing {Title}... \n you are reading it now";
    }

    public void Summarize()
    {
        for (int f = 0; f < MainIdeas.Length; f++)
        {
            Console.Write($"Enter the main {f + 1} idea: ");
            MainIdeas[f] = Console.ReadLine().Trim();
        }
    }
}