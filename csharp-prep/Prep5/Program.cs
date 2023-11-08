using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args) {
        DisplayWelcome();
        string name = PromptUserName();
        int square = SquareNumber(PromptUserNumber());
        DisplayResult(square, name);

    }
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquareNumber(int number) {
        int squared = number*number;
        return squared;
    }
    static void DisplayResult(int square, string name) {
        Console.WriteLine($"{name}, the square of your number is {square}");
        }
}