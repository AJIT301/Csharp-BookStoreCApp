using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication
{
    internal class BookStoreConsole
    {
        private BookStore _bookStore { get; set; } = new BookStore();

        public void ExecuteAdd()
        {
            try
            {
                Console.WriteLine("Enter the title of the book:");
                var title = Console.ReadLine();

                Console.WriteLine("Enter the description of the book:");
                var description = Console.ReadLine();

                Console.WriteLine("Enter the amount of the book:");
                var number = Convert.ToInt32(Console.ReadLine());

                _bookStore.Add(title, description, number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the amount.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExecuteList()
        {
            var books = _bookStore.GetAll();
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Description: {book.Description}");
                Console.WriteLine($"Amount: {book.Amount}");
            }
        }

        public void ExecuteRemove()
        {
            Console.WriteLine("Please enter the title of the book you want to remove:");
            var title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Invalid input. Title cannot be null or empty.");
                return;
            }

            _bookStore.Remove(title);
        }
    }
}

