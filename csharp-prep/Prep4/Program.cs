using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int num = 0;
        int total = 0;
        int i = -1;
        int largest = 0;
        List<int> numList = new List<int>();
        do {
            num = int.Parse(Console.ReadLine());
            numList.Add(num);
            total += num;
            i += 1;
            if (num > largest) {
                largest = num;
            }
        } while (num != 0);
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {((float)total)/i}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}