using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreApplication;

namespace BookStoreApplication
{
    
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
    public class BookStore
    {
        private List<Book> _books = new List<Book>();
        public void Add(string title, string description, int amount)
        
        {
            var bookExists = _books.Any(x => x.Title == title);
            if (bookExists)
            {
                throw new ArgumentException("Book already exists");
            }
            var book = new Book
            {
                Title = title,
                Description = description,
                Amount = amount
            };
            _books.Add(book);
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public void Remove(string title)
        {
            _books = _books.Where(b => b.Title != title).ToList();
        }
    }
}
