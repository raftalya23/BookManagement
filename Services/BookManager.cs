

namespace BookManagementApp
{
    public class BookManager
    {
        private readonly List<Book> books; // წიგნების სია
        private readonly string filePath = "Data/books.txt"; // ფაილის მისამართი მონაცემების შესანახად

        public BookManager()
        {
            books = new List<Book>();
            LoadBooksFromFile(); // მონაცემების ჩატვირთვა ფაილიდან
        }

        // ახალი წიგნის დამატება
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Book added successfully.");
            SaveBooksToFile(); // მონაცემების განახლება ფაილში
        }

        // ყველა წიგნის ჩვენება
        public void DisplayAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books in the library.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        // კონკრეტული სათაურის მიხედვით წიგნის ძიება
        public Book FindBookByTitle(string title)
        {
            return books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        // წიგნების ჩატვირთვა ფაილიდან
        private void LoadBooksFromFile()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No data file found. A new one will be created.");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 4)
                {
                    var title = parts[0];
                    var author = parts[1];
                    var genre = parts[2];
                    if (int.TryParse(parts[3], out int year))
                    {
                        books.Add(new Book(title, author, genre, year));
                    }
                }
            }
        }

        // წიგნების შენახვა ფაილში
        private void SaveBooksToFile()
        {
            using (var writer = new StreamWriter(filePath, false))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.Title};{book.Author};{book.Genre};{book.Year}");
                }
            }
        }
    }
}