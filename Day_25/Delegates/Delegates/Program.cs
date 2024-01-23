namespace Delegates
{
    internal class Program
    {
        public delegate void LogMessage(string messgae);
        public delegate decimal MathOperation(decimal num1, decimal num2);
        public delegate bool ValidateBook(Book book);

        static void Main(string[] args)
        {
            #region 1 Consolidated Logging
            LogMessage logger = Logger.LogInConsole;

            logger += Logger.LogInFile;

            logger.Invoke("Hello World!");

            SkipLines();

            #endregion
            #region 2 Sequential Calculations
            MathOperation mathOperation = MathOperations.Multiply;
            mathOperation += MathOperations.Divide;
            mathOperation += MathOperations.Add;
            mathOperation += MathOperations.Subtract;
            
            foreach(var item in mathOperation.GetInvocationList())
            {
                Console.WriteLine($" 2 {item.Method.Name} 2  is  {item.DynamicInvoke(2m, 2m)}");
            }
            SkipLines();
            #endregion
            #region 3 Chained Validation
            Book book = new Book
            {
                Title = "Dea's story",
              //  Author = "Dea Chkoidze",
                ISBN = "1234567890123",
                Publisher = "Dea AI Publishing",
               // PublicationDate = new DateTime(2024, 1, 13),
               // Genre = Genre.Action,
                IsAvailable = false,
            };

            ValidateBook validator = Validations.ValidateTitle;
            validator += Validations.ValidateAuthor;
            validator += Validations.ValidateISBN;
            validator += Validations.ValidatePublisher;
            validator += Validations.ValidateDate;
            validator += Validations.ValidateGenre;
            validator += Validations.ValidatePages;
            validator += Validations.ValidateAvailability;
            validator += Validations.ValidatePrice;

            foreach (var item in validator.GetInvocationList())
            {
                bool isValidProperty = (bool)item.DynamicInvoke(book);

                if (!isValidProperty)
                    Console.WriteLine($"Error validation: {item.Method.Name.Substring(8)}");
            }

            SkipLines();
            #endregion
            #region 4 Custom Data Pipelines
            List<Book> books = GenerateBooks();
            var filteredBooks = DataPipeline<Book>.Process<IEnumerable<BookDto>>(books).ToList();
            #endregion
        }
        public static List<Book> GenerateBooks()
        {
            List<Book> list = new();

            for (int i = 0; i < 10; i++)            {
                Book book = new Book
                {
                    Title = $"Dea Tchkoidze Part: {i}",
                    Author = $"Dea {i} Rchkoidze",
                    ISBN = $"1234567890{i}{i}{i}",
                    Publisher = "Biblusi",
                    PublicationDate = DateTime.Now,
                    Genre = Genre.Roman,
                    NumberOfPages = 11 * i,
                    IsAvailable = true,
                    Price = i * 10
                };
                list.Add(book);
            }
            return list;
        }
        public static void SkipLines()
        {
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine();
        }
    }
}
