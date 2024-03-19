using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathAssignment = new MathAssignment("8-19", "7.3", "Samuel Bennet", "Multiplication");
        WritingAssignment writingAssignment = new WritingAssignment("The causes of World War II", "Mary Waters", "European History");
        Console.WriteLine();
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
        Console.WriteLine();
    }
}