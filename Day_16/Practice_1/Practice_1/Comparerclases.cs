namespace Practice_1
{
    public class AuthorComparer : IComparer<Book>
    {
         int IComparer<Book>.Compare(Book? x, Book? y)
        {
            return string.Compare(x.AuthorFullName, y.AuthorFullName);
        }
    }
    public class YearOfPublicationComparer : IComparer<Book>
    {
          int IComparer<Book>.Compare(Book? x, Book? y)
        {
            return x.YearOfPublication - y.YearOfPublication;
        }
    }
    public class ISBNComparer : IComparer<Book>
    {
         int IComparer<Book>.Compare(Book x, Book y)
        {
            return x.ISBN.CompareTo(y.ISBN);
        }
    }
}