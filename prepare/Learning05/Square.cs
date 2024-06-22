namespace Learning05;
public class Square : Shape
{
    private double _side1;
    public Square(double s1, string color)
    {
        _side1 = s1;
        _color = color;
    }
    public override double GetArea()
    {
        return Math.Pow(_side1, 2);
    }
}