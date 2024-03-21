using System;
using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {

        // Added functionality to ask user about breathing times in Breathing.cs line 10.
        
        Breathing breathing = new Breathing();
        Reflection reflection = new Reflection();
        Listing listing = new Listing();
        string choice = "0";
        while (choice != "4") {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();
            if (choice == "1") {
                Console.Clear();
                breathing.Run();
            }
            else if (choice == "2") {
                Console.Clear();
                reflection.Run();
            }
            else if (choice == "3") {
                Console.Clear();
                listing.Run();
            }
            else if (choice == "4") {
                Console.WriteLine("Goodbye!");
            }
            else {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}