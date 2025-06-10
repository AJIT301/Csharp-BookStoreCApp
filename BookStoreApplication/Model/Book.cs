using System;

namespace BookStoreApplication
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }

        public Book(string title, string description, int amount)
        {
            Title = title;
            Description = description;
            Amount = amount;
        }
    }
}