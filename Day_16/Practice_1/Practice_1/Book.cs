using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    public enum BookGenre
    {
        Fiction,
        Mystery,
        ScienceFiction,
        Romance,
        NonFiction
    }
    internal class Book
    {
        public Book(string authorFullName, string bookTitle, int yearOfPublication, string iSBN, BookGenre genre)
        {
            AuthorFullName = authorFullName;
            BookTitle = bookTitle;
            YearOfPublication = yearOfPublication;
            ISBN = iSBN;
            Genre = genre;
        }

        internal string AuthorFullName { get; set; }
        internal string BookTitle { get; set; }
        internal int YearOfPublication { get; set; }
        internal string ISBN { get; set; }
        private BookGenre Genre { get; set; }
        public override string ToString()
        {
            return $"Title: {BookTitle}, Author: {AuthorFullName}, Genre: {Genre}, Release Year: {YearOfPublication}, ISBN : {ISBN} ";
        }

    }
}
