using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name? ");
        var first = Console.ReadLine();
        Console.WriteLine("What is your last name? ");
        var last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}