using System.Data;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Scripture
{
    private Reference _ref;
    private string _passage;
    // public Scripture()
    // {
        
    // }
    public Scripture(Reference _ref, string _passage)
    {
        this._ref = _ref;
        //for the purposes of this assignment I feel that this is sufficient. If I was doing something like api access, It would be a good idea to use regex. 
        //Maybe if I feel particularly motivated I will include file management.
        //It could be fun to store the entire book of mormon or something along those lines.
        //This is definitely a project that I will continue later.
        this._passage = _passage;
    }

    public string ToString()
    {
        return _ref.ToString() + _passage;
    }

    public string[] GetScriptureList()
    {
        return _passage.Split();
    }

    public string[] EverythingList()
    {
        string[] _everything = [_ref.ToString()];
        
        return _everything.Concat(GetScriptureList()).ToArray();
    }

    public bool[] FilledIndex()
    {
        bool[] returnarray = new bool[GetScriptureList().Length + 1];
        returnarray[0] = true;
        return returnarray;
    }


}