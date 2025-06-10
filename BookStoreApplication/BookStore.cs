using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApplication
{
    public class BookStore
    {
        private List<Book> _books = new List<Book>();

        public void Add(string title, string description, int amount)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.");

            var bookExists = _books.Any(x => x.Title == title);
            if (bookExists)
                throw new ArgumentException("Book already exists");

            var book = new Book(title, description, amount);

            _books.Add(book);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public void Remove(string title)
        {
            var book = _books.FirstOrDefault(b => b.Title == title);
            if (book != null)
                _books.Remove(book);
        }

        public void Update(string oldTitle, Book updateInfo)
        {
            if (string.IsNullOrWhiteSpace(oldTitle))
                throw new ArgumentException("Old title cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(updateInfo.Title))
                throw new ArgumentException("New title cannot be null or empty.");

            var book = _books.SingleOrDefault(b => b.Title == oldTitle);

            if (book == null)
                throw new ArgumentException("Book was not found.");

            // Check if new title conflicts with another book (only if changed)
            if (!string.Equals(oldTitle, updateInfo.Title, StringComparison.OrdinalIgnoreCase) &&
                _books.Any(b => b.Title == updateInfo.Title))
            {
                throw new ArgumentException("A book with the new title already exists.");
            }

            book.Title = updateInfo.Title;
            book.Description = updateInfo.Description;
            book.Amount = updateInfo.Amount;
        }
    }
}