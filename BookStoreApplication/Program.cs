using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BookStoreApplication;

var BookStoreConsole = new BookStoreConsole();

while (true)
{
    Console.WriteLine("Enter a command: Add / List / Remove");
    var command = Console.ReadLine();
    switch (command)
    {


        case "Add":
            BookStoreConsole.ExecuteAdd();
            break;

        case "List":
            BookStoreConsole.ExecuteList();
            break;

        case "Remove":
            BookStoreConsole.ExecuteRemove();
            break;

        case "exit":
            break;


        default:
            Console.WriteLine("Invalid command");
            Console.WriteLine("Enter a command: Add or List");
            break;


    }
}


