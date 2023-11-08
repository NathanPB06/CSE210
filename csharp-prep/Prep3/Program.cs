using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number?");
        int magic = int.Parse(Console.ReadLine());
        int guess = -1; 
        do
        {
            Console.Write("What is your guess?");
            string guessStr = Console.ReadLine();
            guess = int.Parse(guessStr);
            if (guess > magic) {
                Console.WriteLine("Lower");
            }
            else if (guess < magic) {
                Console.WriteLine("Higher");
            }
            else {
                Console.WriteLine("You got it!");
            }
        } while (guess != magic);

    }
}