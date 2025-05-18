// See https://aka.ms/new-console-template for more information
using System;
using Task_2_ClassLibrary;
class Program
{
    static void Main(string[] args)
    {
        string username = GetUsername(args);
        Console.WriteLine($"Hello, {username}!");

        string libraryMessage = GetClassLibraryMessage(username);
        Console.WriteLine($"Output from class library: {libraryMessage}");
    }

    static string GetUsername(string[] args)
    {
        return (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0])) ? args[0] : "Mr. Hello World";
    }

    static string GetClassLibraryMessage(string username)
    {
        return ConcatenationLogic.WelcomeUser(username);
    }
}