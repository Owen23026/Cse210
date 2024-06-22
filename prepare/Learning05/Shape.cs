using System.Diagnostics.Contracts;
namespace Learning05;
public abstract class Shape
{
    protected string _color;
    public abstract double GetArea();

    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string _color)
    {

    }
}