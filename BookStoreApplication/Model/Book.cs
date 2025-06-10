using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication
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