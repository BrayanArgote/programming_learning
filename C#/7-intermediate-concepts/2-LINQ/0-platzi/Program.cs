LinqQueries queries = new LinqQueries();

void PrintValues(IEnumerable<Book> booksCollection)
{
    Console.WriteLine("{0, -60} {1, 7} {2, 13}\n", "Title", "N. Pages", "Published Date");
    foreach(var fe in booksCollection)
    {
        Console.WriteLine("{0, -60} | {1, 7} | {2, 13}", fe.Title, fe.PageCount, fe.PublishedDate.ToShortDateString());
    }
}

// All books
// PrintValues(queries.AllCollection());

//=================================== WHERE ============================================== //
// Books after 2000
// PrintValues(queries.BooksAfter2000());

// Books with more than 200 pages and its title contains "in Action"
// PrintValues(queries.BooksMoreThan250PagesAndTitleContainsInAction());

//=================================== ALL ============================================== //
// All books have status
//Console.WriteLine("Do all books have status? " + (queries.AllBooksHaveStatus()? "--- Yes, they do ---" : "--- No, they don't ---"));

//=================================== ANY ============================================== //
// Any book pulic inshed2005
// Console.WriteLine("Was any book published in 2005? " + (queries.WasAnyBookPublished2005()? "--- Yes, there was ---" : "--- No, there wasn't ---"));

//=================================== CONTAINS ============================================== //
// Pyhton books
// PrintValues(queries.PythonBooks());

// Java books order by name
// PrintValues(queries.JavaBooksDesc());

// Books with more than 450 pages and ordered by pages (desc)
// PrintValues(queries.BooksOrderByPagesDesc());

//=================================== TAKE and TAKELAST ============================================== //
// The three most recent Java books
// PrintValues(queries.FirstThreeMostRecentJavaBooks());

//=================================== SPKIP ============================================== //
// Third and fourth book have more than 400 pages
// PrintValues(queries.ThirdAndFourthBooksWithMoreThan400Pages());

//=================================== SELECT ============================================== //
// First three books of the collection
// PrintValues(queries.FirstThreeBooksOfCollection());

//=================================== LONGCOUNT and COUNT ============================================== //
// Amount of books that have between 200 and 500 pages
// Console.WriteLine("Amount of books that have between 200 and 500 pages: " + queries.BooksBetween200And500Page());

//=================================== MIN and MAX ============================================== //
// Earliest date published
// Console.WriteLine("The earliest published date: " + queries.EarliestDatePublished());

// Highest number of pages
// Console.WriteLine("The highest number of pages is: " + queries.HighestNumberOfPages());

//=================================== MINBY and MAXBY ============================================== //
// Book with fewest pages (different from 0)
// var bookFP = queries.BookWithFewestPages(); 
// Console.WriteLine($"The book with the fewest pages is: {bookFP.Title} with {bookFP.PageCount} pages");

// Book with the earliest published date 
// var bookEPD = queries.BookWhithEarliestsPublishedDate();
// Console.WriteLine($"The book with the earliest published date is: {bookEPD.Title} \nDate: {bookEPD.PublishedDate}");

//=================================== SUM ============================================== //
// Console.WriteLine($"Total pages of books with 0 to 500 pages: {queries.GetTotalPagesBooksFrom0To500()}");

//=================================== AGGREGATE ============================================== //
// Console.WriteLine($"Titles of books published before 2015 \n{queries.GetBookTitlesPublishedAfter2015()}");

//=================================== AVERAGE ============================================== //
// Console.WriteLine($"Average number of Characters in book title: {queries.GetAverageTitleLength()}");

//=================================== GROUPO BY ============================================== //
void PrintGroups(IEnumerable<IGrouping<int, Book>> booksCollection)
{
    foreach(var group in booksCollection)
    {
        Console.WriteLine($"\nGroup: {group.Key}");
        Console.WriteLine("{0, -60} {1, 7} {2, 13}", "Title", "N. Pages", "Date Published");

        foreach(var book in group)
        {
            Console.WriteLine("{0, -60} {1, 7} {2, 13}", book.Title, book.PageCount, book.PublishedDate.Date.ToShortDateString());
        }
    }
}
// PrintGroups(queries.BooksPublishedAfter200GroupByYear());

//=================================== LOOKUP ============================================== //
// Books with titles that start with a character "x"

// var booksDictionary = queries.BooksDictionary();
void PrintBooksWithTitlesStartingWith (ILookup<char, Book> booksCollection, char letter){
    Console.WriteLine($"\nBooks with its title starts with *{letter}*");
    Console.WriteLine("{0, -60} {1, 7} {2, 13}", "Title", "N. Pages", "Date Published");
    
        foreach(var book in booksCollection[letter])
        {
            Console.WriteLine("{0, -60} {1, 7} {2, 13}", book.Title, book.PageCount, book.PublishedDate.Date.ToShortDateString());
        }
}
// PrintBooksWithTitlesStartingWith(booksDictionary, 'A');

//=================================== JOIN ============================================== //
PrintValues(queries.BooksWithMore500PagesAndPublishedAfter2005());




Console.ReadKey();