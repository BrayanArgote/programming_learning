    class Fiction : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Fiction(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string Read()
        {
            return $"You just start reading {Title}";
        }
    }