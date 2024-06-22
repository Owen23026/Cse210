using System.Diagnostics;

namespace Learning05;
public class Circle : Shape
{
    private double _radius;
    public Circle(double rad, string color)
    {
        _radius = rad;
        _color = color;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}