using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("blue", 5));
        shapes.Add(new Circle("yellow", 3));   
        shapes.Add(new Rectangle("pink", 4, 7));
        foreach (Shape shape in shapes) {
            Console.WriteLine($"The area of the {shape.GetColor()} shape is {shape.GetArea()}.");
        }
    }
}