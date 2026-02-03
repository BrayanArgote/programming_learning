public class LinqQueries{

    private List<Book> booksCollection = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
        }
    }

    // All books
    public IEnumerable<Book> AllCollection()
    {
        return booksCollection;
    }


//=================================== WHERE ============================================== //
    // Books after year 2000
    public IEnumerable<Book> BooksAfter2000()
    {
        // extension method
        // return booksCollection.Where(p=> p.PublishedDate.Year > 2000 );

        // Query expression
        return from q in booksCollection
                where q.PublishedDate.Year > 2000
                select q;
    }

    // Books with more than 250 pages and title contains "in Action"
    public IEnumerable<Book> BooksMoreThan250PagesAndTitleContainsInAction()
    {
        // Extension method
        // return booksCollection.Where(q=> q.PageCount > 250 && q.Title.Contains("in Action"));

        // Query espression
        return from q in booksCollection
        where q.PageCount > 250 && q.Title.Contains("in Action")
        select q;
    }

//=================================== ALL ============================================== //
    public bool AllBooksHaveStatus()
    {
        return booksCollection.All(q=> q.Status != string.Empty);
    }

//=================================== ANY ============================================== //
// Any book published in 2005
    public bool WasAnyBookPublished2005()
    {
        return booksCollection.Any(q=> q.PublishedDate.Year == 2005);
    }

//=================================== CONTAINS ============================================== //

// Python books
    public IEnumerable<Book> PythonBooks()
    {
        return booksCollection.Where(q=> q.Categories.Contains("Python"));
    }

//=================================== ORDER BY ============================================== //

// Java books order by name
public IEnumerable<Book> JavaBooksDesc()
    {
        return booksCollection.Where(q=> q.Categories.Contains("Java")).OrderBy(q=> q.Title);
    }

// Books with more than 450 pages and ordered by pages (desc)
public IEnumerable<Book> BooksOrderByPagesDesc()
    {
        return booksCollection.Where(q=> q.PageCount > 450).OrderByDescending(q=> q.PageCount);
    } 


//=================================== TAKE and TAKE LAST ============================================== //

// The three most recent java books
public IEnumerable<Book> FirstThreeMostRecentJavaBooks()
{
    // TAKE
    return booksCollection.Where(q=> q.Categories.Contains("Java")).OrderByDescending(q=> q.PublishedDate).Take(3);

    // TAKE LAST (same result but different order)
    // return booksCollection.Where(q=> q.Categories.Contains("Java")).// OrderBy(q=> q.PublishedDate).TakeLast(3);
}

//===================================  SPKIP ============================================== //
// Third and fourth book that have 400 pages
public IEnumerable<Book> ThirdAndFourthBooksWithMoreThan400Pages()
    {
        return booksCollection.Where(q=> q.PageCount > 400).Take(4).Skip(2);
    }

//=================================== SELECT ============================================== //
// First three books of the collection
public IEnumerable<Book> FirstThreeBooksOfCollection()
    {
        return booksCollection.Take(3)
        .Select(q=> new Book {Title = q.Title, PageCount = q.PageCount});
    }

//=================================== LONGCOUNT and COUNT ============================================== //
// Amount of books that have between 200 and 500 pages
public int BooksBetween200And500Page()
    {
        // Poor practice
        return booksCollection.Where(q=> q.PageCount >= 200 && q.PageCount <= 500).Count();

        // Good practice
        return booksCollection.Count(q=> q.PageCount >= 200 && q.PageCount >= 500);
    }

//=================================== MIN and MAX ============================================== //
// Earliest date published
public DateTime EarliestDatePublished()
    {
        return booksCollection.Min(q=> q.PublishedDate);
    }

// Highest number of pages
public int HighestNumberOfPages()
    {
        return booksCollection.Max(q=> q.PageCount);
    }

//=================================== MINBY and MAXBY ============================================== //
// Book with fewest pages (different from 0)
public Book BookWithFewestPages()
    {
        return booksCollection.Where(q=> q.PageCount != 0).MinBy(q=> q.PageCount);
    }

// Book with the earliest published date
public Book BookWhithEarliestsPublishedDate()
    {
        return booksCollection.MaxBy(q=> q.PublishedDate);
    }

//=================================== SUM ============================================== //

public int GetTotalPagesBooksFrom0To500()
{
    return booksCollection.Where(q=> q.PageCount >= 0 && q.PageCount <= 500).Sum(q=> q.PageCount);
}

//=================================== AGGREGATE============================================== //
public string GetBookTitlesPublishedAfter2015()
    {
        return booksCollection.Where(q=> q.PublishedDate.Year > 2015)
        .Aggregate("", (titlesBooks, next) =>
        {
            if(titlesBooks != string.Empty)
            {
                titlesBooks += "  -  " + next.Title;
            }
            else
            {
                titlesBooks += next.Title;
            }
            return titlesBooks;
        });
    }

//=================================== AVERAGE ============================================== //
public double GetAverageTitleLength()
    {
        return booksCollection.Average(q=> q.Title.Length);
    }

//=================================== GROUPO BY ============================================== //
public IEnumerable<IGrouping<int, Book>> BooksPublishedAfter200GroupByYear()
    {
        return booksCollection.Where(q=> q.PublishedDate.Year >= 2000).GroupBy(q=> q.PublishedDate.Year).OrderBy(q=> q.Key);
    }

//=================================== LOOKUP ============================================== //
// Books with title that start with "x" character
public ILookup<char, Book> BooksDictionary()
    {
        return booksCollection.ToLookup(q=> q.Title[0], q=> q);
    }

//=================================== JOIN ============================================== //
// books with 

public IEnumerable<Book> BooksWithMore500PagesAndPublishedAfter2005()
    {
        var booksWithMore500Pages = booksCollection.Where(q=> q.PageCount > 500);
        var booksPublishedAfter2005 = booksCollection.Where(q=> q.PublishedDate.Year > 2005);

        return booksWithMore500Pages.Join(
            booksPublishedAfter2005, 
            fc=> fc.Title, 
            sc=> sc.Title,
            (fc, sc) => fc);
    }

}