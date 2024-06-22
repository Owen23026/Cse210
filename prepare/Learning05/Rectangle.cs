namespace Learning05;
public class Rectangle : Shape
{
    private double _side1, _side2;
    public Rectangle(double s1, double s2, string color)
    {
        _side1 = s1;
        _side2 = s2;
        _color = color;
    }
    public override double GetArea()
    {
        return _side1 * _side2;
    }
}