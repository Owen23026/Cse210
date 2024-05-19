using System.Globalization;

namespace Develop02;

public class Gentry
{
    public string _fname;

    public Gentry(string _fname)
    {
        this._fname = _fname;
    }
    public string Genentry()
    {
        //Load the file into a list, and select a random line to display.
        Random _random = new Random();
        string[] _fLines = System.IO.File.ReadAllLines(_fname);
        return _fLines[_random.Next(_fLines.Length)];
    }


}