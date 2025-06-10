using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BookStoreApplication;

var BookStoreConsole = new BookStoreConsole();

while (true)
{
    Console.WriteLine("Enter a command: Add / List / Remove / Update / exit");
    var command = Console.ReadLine()?.Trim().ToLower();

    switch (command)
    {
        case "add":
            BookStoreConsole.ExecuteAdd();
            break;

        case "list":
            BookStoreConsole.ExecuteList();
            break;

        case "remove":
            BookStoreConsole.ExecuteRemove();
            break;

        case "update":
            BookStoreConsole.ExecuteUpdate();
            break;

        case "exit":
            return; // Exit the program immediately

        default:
            Console.WriteLine("Invalid command");
            break;
    }
}