using System;

namespace BookManagementApp
{
    // წიგნის მონაცემების შენახვა
    public class Book
    {
        public string Title { get; set; } // წიგნის სათაური
        public string Author { get; set; } // ავტორი
        public string Genre { get; set; } // ჟანრი
        public int Year { get; set; } // გამოქვეყნების წელი

        public Book(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}";
        }
    }
}