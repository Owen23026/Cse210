using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFRString());
        Console.WriteLine(f1.GetDCML());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFRString());
        Console.WriteLine(f2.GetDCML());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFRString());
        Console.WriteLine(f3.GetDCML());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFRString());
        Console.WriteLine(f4.GetDCML());
    }
}