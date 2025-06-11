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

                int number;
                while (true)
                {
                    Console.WriteLine("Enter the amount of the book:");
                    var input = Console.ReadLine();

                    if (int.TryParse(input, out number) && number >= 0)
                        break;

                    Console.WriteLine("Invalid input. Please enter a valid non-negative number for the amount.");
                }

                _bookStore.Add(title, description, number);
                Console.WriteLine("Book added successfully.");
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
            Console.WriteLine("Please enter title of the book you want to update");
            var oldTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(oldTitle))
            {
                Console.WriteLine("Invalid input. Title cannot be null or empty.");
                return;
            }

            // Find the existing book
            var existingBook = _bookStore.GetAll().SingleOrDefault(b => b.Title == oldTitle);
            if (existingBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine("Please enter new title (or type 'same' to keep current title):");
            var inputTitle = Console.ReadLine();

            var newTitle = inputTitle.Equals("same", StringComparison.OrdinalIgnoreCase) ? oldTitle : inputTitle;

            if (string.IsNullOrWhiteSpace(newTitle))
            {
                Console.WriteLine("Invalid input. New title cannot be null or empty.");
                return;
            }

            // Check for duplicate title only if title changed
            if (!newTitle.Equals(oldTitle, StringComparison.OrdinalIgnoreCase))
            {
                var duplicateExists = _bookStore.GetAll().Any(b => b.Title.Equals(newTitle, StringComparison.OrdinalIgnoreCase));
                if (duplicateExists)
                {
                    Console.WriteLine("A book with this title already exists. Update aborted.");
                    return;
                }
            }

            Console.WriteLine("Please enter new description (or type 'same' to keep current description):");
            var inputDescription = Console.ReadLine();
            var newDescription = inputDescription.Equals("same", StringComparison.OrdinalIgnoreCase) ? existingBook.Description : inputDescription;

            if (string.IsNullOrWhiteSpace(newDescription))
            {
                Console.WriteLine("Invalid input. Description cannot be empty.");
                return;
            }

            Console.WriteLine("Please enter new amount (or type 'same' to keep current amount):");
            var inputAmount = Console.ReadLine();
            int newAmount;

            if (inputAmount.Equals("same", StringComparison.OrdinalIgnoreCase))
            {
                newAmount = existingBook.Amount;
            }
            else if (!int.TryParse(inputAmount, out newAmount) || newAmount < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid non-negative number for the amount.");
                return;
            }

            var updateInfo = new Book(newTitle, newDescription, newAmount);

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