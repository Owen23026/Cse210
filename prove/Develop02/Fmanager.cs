using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Net;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
namespace Develop02;

public class Fmanager
{
    public string _fname;
    public List<string> _raw = new List<string>();
    public Fmanager(string _fname)
    {
        this._fname = _fname;
    }
    

    public void Load2Array()
    {
        using(StreamReader _fr = new StreamReader(_fname))
        {
            string _line;
            while((_line = (_fr.ReadLine())) != null)
            {
                _raw.Add(_line);
            }
        }
    }

    public void Save2File(){
        using(StreamWriter _fw = new StreamWriter(_fname))
        {
            foreach(string _line in _raw)
            {
                _fw.WriteLine(_line);
            }
        }
    }
}