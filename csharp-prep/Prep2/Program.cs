using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage?");
        string numstr = Console.ReadLine();
        int percentGrade = int.Parse(numstr);
        if (percentGrade >= 90) {
            Console.Write($"Your grade is an A.");
        }
        else if (percentGrade >= 80) {
            Console.Write($"Your grade is a B.");
        }
        else if (percentGrade >= 70) {
            Console.Write($"Your grade is a C.");
        }
        else if (percentGrade >= 60) {
            Console.Write($"Your grade is a D.");
        }
        else if (percentGrade < 60) {
            Console.Write($"Your grade is an F.");
        }
    }
}