using System;
using System.Drawing;
namespace Learning05;
class Program
{
    static void Main(string[] args)
    {
            Rectangle _rct = new Rectangle(10, 15, "Blue");
            Square _sqr = new Square(10, "Green");
            Circle _circ = new Circle(16, "Grey");

            Console.WriteLine(_rct.GetArea());
            Console.WriteLine(_rct.GetColor());
            Console.WriteLine(_sqr.GetArea());
            Console.WriteLine(_sqr.GetColor());
            Console.WriteLine(_circ.GetArea());
            Console.WriteLine(_circ.GetColor());
            Console.WriteLine("Generating List...");
            Thread.Sleep(3000);

            List<Shape> _shapes = new List<Shape>();
            List<string> _colors = ["Red", "Green", "Blue"];

            Random random = new Random();
            for(int i = 0; i < 20; i ++)
            {
                switch(random.Next(2))
                {
                    case 0:
                        _shapes.Add(new Rectangle(random.Next(10), random.Next(10), _colors[random.Next(2)]));
                        break;
                    case 1:
                        _shapes.Add(new Square(random.Next(10), _colors[random.Next(2)]));
                        break;
                    case 2:
                        _shapes.Add(new Circle(random.Next(10), _colors[random.Next(2)]));
                        break;
                    default:
                        break;
                }
                
            }
            
            for(int i = 0; i < _shapes.Count() - 1; i++)
            {
                Console.WriteLine(_shapes[i].GetColor());
                Console.WriteLine(_shapes[i].GetArea());
            }
    }
}