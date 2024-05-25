using System.Collections.Specialized;

public class Fraction
{
    private int _numerator, _denominator;

    public Fraction(){}
//whole number constructor
    public Fraction(int _nr)
    {
        _numerator = _nr;
        _denominator = 1;
    }
    //overloaded fraction constructor
    public Fraction(int _nr, int _dr)
    {
        _numerator = _nr;
        _denominator = _dr;
    }

    public int GetNumerator()
    {
        return _numerator;
    }
    public void SetNumerator(int _nr)
    {
        _numerator = _nr;
    }
    int GetDenominator()
    {
        return _denominator;
    }
    void SetDenominator(int _dr)
    {
        _denominator = _dr;
    }

    public string GetFRString()
    {
        if(_denominator == 1)
        {
            return _numerator.ToString();
        }else{
            return _numerator.ToString() + "/" + _denominator.ToString();
        }
        
    }
    public double GetDCML()
    {
        if(_denominator != 0)
        {
            return (double)_numerator/(double)_denominator;
        }else{
            Console.WriteLine("Fraction cannot be divided by Zero!");
            return 0;
        }
        
    }
}


/*

*/