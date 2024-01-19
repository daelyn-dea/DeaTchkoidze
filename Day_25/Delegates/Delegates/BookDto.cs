using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }

        public BookDto(string title, string author, Genre genre, bool isAvailable, decimal price)
        {
            Title = title;
            Author = author;
            Genre = genre;
            IsAvailable = isAvailable;
            Price = price;
        }
    }
    public static class Transform
    {
        public static BookDto ToBookDto(this Book book) => new BookDto(book.Title, book.Author, book.Genre, book.IsAvailable, book.Price);
    }
}
