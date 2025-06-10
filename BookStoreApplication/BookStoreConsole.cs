using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreApplication;

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
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }
            int i = 1;
            foreach (var book in books)
            {
                Console.WriteLine($"{i++}. Title: {book.Title}");
                Console.WriteLine($"   Description: {book.Description}");
                Console.WriteLine($"   Amount: {book.Amount}");
                Console.WriteLine();
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

            var bookExists = _bookStore.GetAll().Any(b => b.Title == title);
            if (!bookExists)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            _bookStore.Remove(title);
            Console.WriteLine("Book removed successfully.");
        }

        public void ExecuteUpdate()
        {
            Console.WriteLine("Please enter the title of the book you want to update:");
            var oldTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(oldTitle))
            {
                Console.WriteLine("Invalid input. Title cannot be null or empty.");
                return;
            }

            Console.WriteLine("Please enter new title:");
            var newTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newTitle))
            {
                Console.WriteLine("Invalid input. New title cannot be null or empty.");
                return;
            }

            Console.WriteLine("Please enter new description:");
            var description = Console.ReadLine();

            if (description == null)
            {
                Console.WriteLine("Invalid input. Description cannot be null.");
                return;
            }

            Console.WriteLine("Please enter new amount:");
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the amount.");
                return;
            }

            var updateInfo = new Book(newTitle, description, amount);

            try
            {
                _bookStore.Update(oldTitle, updateInfo);
                Console.WriteLine("Book updated successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
