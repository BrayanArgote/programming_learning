class Item
{
    private string title;
    public string Title
    {
        get { return title; }
        set { if (!string.IsNullOrEmpty(value)) { title = value; } else { title = "unknown"; } }
    }

    private int publicationYear;
    public int PublicationYear
    {
        get { return publicationYear; }
        set { if (value >= 1990 && value <= 2026) { publicationYear = value; } else { publicationYear = 0000; } }
    }

}