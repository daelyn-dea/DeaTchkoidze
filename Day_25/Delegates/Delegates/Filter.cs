using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class Filter
    {
        public static bool PublishedAfter(Book book) => book.PublicationDate < new DateTime(2030, 1, 1);

        public static bool AuthorFilter(Book book) => book.Author == "Dea Tchkoidze";

        public static bool CheaperThan(Book book) => book.Price < 50M;
    }
}
