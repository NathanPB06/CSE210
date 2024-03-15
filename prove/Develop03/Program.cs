using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {   
        // !!!   I added functionality to only hide words not already hidden. It can be seen on line 41 of "classes.cs".   !!!

        string text = "Blessed are those who hunger and thirst for righteousness, for they shall be satisfied.";
        Reference reference = new Reference("Matthew", 5, 6);
        Scripture scripture = new Scripture(reference, text);
        Random rnd = new Random();
        Console.Write("Press enter to continue or type 'quit' to quit.");
        while (Console.ReadLine().ToLower() != "quit" && scripture.IsCompletelyHidden() != true) {

            //requires not running in debug mode to work, not sure why.
            Console.Clear();
            Console.WriteLine("Press enter to continue or type 'quit' to quit.");
            Console.WriteLine(scripture.GetDisplayText());
            scripture.HideRandomWords(rnd.Next(0, scripture.WordCount()));
        }
        Console.WriteLine(scripture.GetDisplayText());
    }
}