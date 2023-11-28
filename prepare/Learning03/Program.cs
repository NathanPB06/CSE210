using System;

class Program
{
    static void Main(string[] args)
    {
    Fraction fraction1 = new Fraction();
    Fraction fraction2 = new Fraction(6); 
    Fraction fraction3 = new Fraction(6, 7);
    fraction2.SetTop(3);
    fraction2.SetBottom(4);
    Console.WriteLine(fraction2.GetBottom());
    Console.WriteLine(fraction2.GetTop());
    Console.WriteLine(fraction3.GetFractionString());
    Console.WriteLine(fraction3.GetDecimalValue());
    }
}