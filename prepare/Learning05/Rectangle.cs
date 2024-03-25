using System.Data;

public class Rectangle : Shape {
    public Rectangle(string color, double width, double length) : base(color) {
        _length = length;
        _width = width;
    }
    private double _length;
    private double _width;
    public override double GetArea()
    {
        return _length*_width;
    }
}