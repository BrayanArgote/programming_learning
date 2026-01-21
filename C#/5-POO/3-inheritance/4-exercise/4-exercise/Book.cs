class Book : Item
{
    private string author;
    public string Author {
        get { return author; }
        set { if (!string.IsNullOrEmpty(value)) { author = value; } }
    }

}