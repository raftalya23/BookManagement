using System;

namespace BookManagementApp
{
    // მომხმარებლის ინტერფეისი
    public class UserInterface
    {
        private readonly BookManager bookManager;

        public UserInterface()
        {
            bookManager = new BookManager();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nBook Management App");
                Console.WriteLine("1. Add New Book");
                Console.WriteLine("2. Display All Books");
                Console.WriteLine("3. Search Book by Title");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        bookManager.DisplayAllBooks();
                        break;
                    case "3":
                        SearchBook();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.Write("Enter book title: ");
            var title = Console.ReadLine();

            Console.Write("Enter book author: ");
            var author = Console.ReadLine();

            Console.Write("Enter book genre: ");
            var genre = Console.ReadLine();

            Console.Write("Enter book publication year: ");
            if (!int.TryParse(Console.ReadLine(), out var year))
            {
                Console.WriteLine("Invalid year. Please try again.");
                return;
            }

            var book = new Book(title, author, genre, year);
            bookManager.AddBook(book);
        }

        private void SearchBook()
        {
            Console.Write("Enter the title of the book to search: ");
            var title = Console.ReadLine();

            var book = bookManager.FindBookByTitle(title);
            if (book != null)
            {
                Console.WriteLine("Book found:");
                Console.WriteLine(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}