using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Validations
    {
        public static bool ValidateTitle(Book book) => !string.IsNullOrEmpty(book.Title) && book.Title.Length >  1 && book.Title.Length < 255 && ValidateLetters(book.Title);

        public static bool ValidateAuthor(Book book) => !string.IsNullOrEmpty(book.Author) && book.Author.Length > 3 && book.Author.Length  < 128 && ValidateLetters(book.Author);

        public static bool ValidateISBN(Book book) => !string.IsNullOrEmpty(book.ISBN) && book.ISBN.Length == 13 && book.ISBN.All(char.IsDigit);

        public static bool ValidatePublisher(Book book) => !string.IsNullOrEmpty(book.Publisher) && book.Publisher.Length > 2 && book.Publisher.Length < 64;

        public static bool ValidateDate(Book book) => book.PublicationDate == null || book.PublicationDate < DateTime.Now;

        public static bool ValidateGenre(Book book) => book.Genre != null;

        public static bool ValidatePages(Book book) => book.NumberOfPages != null && book.NumberOfPages > 0;

        public static  bool ValidateAvailability(Book book) => book.IsAvailable != null;

        public static bool ValidatePrice(Book book) => book.Price == null || book.Price > 0;

        private static bool ValidateLetters(string text) => text.All(c => Char.IsLetterOrDigit(c) || c == 32);
    }
}
