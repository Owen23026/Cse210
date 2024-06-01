using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

/// <summary>
/// Class <c>WordDisplay</c>  Displays a word to be substituted with blanks
/// </summary>
public class WordDisplay
{
    //store undo here
    //original stores the first version of the list. Words stores the current list
    //I am going to make the educated assumption that in C# arraylists use much more memory than arrays. as such I will use arrays where applicable
    string[] _words;
    private readonly string[] _original;
    //ignore stores 1s and 0s of which indexes to be ignored
    //blank stores 1s for blank indexes and 0s for existing indexes
    //history stores a list of indexes that have been used
    //indexlast stores the last index that was removed
    int _indexLast = 0;
    private int[] _history;
    private List<int> _seed = [];
    private bool[] _ignore;

    //TODO add another constructor that accepts an int ignore so as to execute the booltoint method.
    

    public WordDisplay(bool[] _ignore, string[] _words)
    {
        //Boolean lists are just so nice to iterate though

        if(_words.Count() == _ignore.Count())
        {
            //reference moment
            this._original = _words.ToArray();
            this._words = _words;
            this._ignore = _ignore;
            SetSeed();

            
            //Console.WriteLine(_seed.ToString());
            //Congratulations, we now have the seed of indexes to display or hide
            // foreach(int i in _seed){
            //     Console.WriteLine(i);
            // }
        
        }
        else
        {
            Console.WriteLine("Incorrect Lengths!");
        }
        
        
    }

//there used to be an undo method, but remove should actually work well even with negative numbers.
    public void Remove(int _amount)
    {
        //store the current index of the seed we are at, and remove all values up to that point
        //TODO Check if amount is correct before execution
        _indexLast = _indexLast + _amount;
        
        //not the greatest way of doing things, but ok i guess
        if(_indexLast > _seed.Count())
        {
            _indexLast = _seed.Count();
        }
        if(_indexLast < 0)
        {
            _indexLast = 0;
            _words = _original.ToArray();

        
        }
        else
        {
            //iterate throught the list changing items up to the seeds current index
            for(int i = 0; i < _indexLast; i++)
            { 
                    _words[this._seed[i]] = Blank(_original[this._seed[i]].Length);
                    
            }
                    
            //similar but to the seeds last index
            for(int i = _indexLast; i < _seed.Count; i++)
            {
                    _words[this._seed[i]] = _original[this._seed[i]];
                    //Console.WriteLine(_original[this._seed[i]]);
            }
        }
        //Console.WriteLine("index is " +_indexLast + " List length is " + _seed.Count());

    }

//ask how to convert this to a lambda
    private static string Blank(int _len)
    {
        string _rtb = new('_', _len);
        return _rtb;//rtb.Join("", Enumerable.Repeat("_", _blank.Length));
    }
    public void Display()
    {
        foreach(string str in _words)
        {
            if(str.Contains("\n")){
                Console.Write(str + "");
            }else{
                Console.Write(str + " ");
            }
            
        }
        Console.WriteLine();
    }

    private void SetSeed()
    {
        Random _random = new Random();
        List<int> _available = BoolListToAvailable(this._ignore);
        _seed.Clear();
        int _index;

        while(_available.Count > 0){
            _index = _random.Next(0, _available.Count());
            //Console.WriteLine(_index);
            _seed.Add(_available[_index]);
            _available.RemoveAt(_index);
        }
    }

    public void update()
    {
        SetSeed();
        if(_indexLast > _seed.Count()){
            _indexLast = _seed.Count();
        }
        if(_indexLast < 0){
            _indexLast = 0;
            _words = _original.ToArray();

        }else{
            //iterate throught the list changing items up to the seeds current index
            for(int i = 0; i < _indexLast; i++){ 
                    _words[this._seed[i]] = Blank(_original[this._seed[i]].Length);
                    
            }
                    
            //similar but to the seeds last index
            for(int i = _indexLast; i < _seed.Count; i++){
                    _words[this._seed[i]] = _original[this._seed[i]];
                    //Console.WriteLine(_original[this._seed[i]]);
            }
        }
    }

    private static int GetNonBlankLength(int[] _blank)
    {
        for (int i = 0; i < _blank.Count(); i ++)
        {

        }
        return 0;
    }

//returns the indexes of 1s
    private static int[] BoolListToInt(bool[] _ean) //haha boolean
    {
        int[] _tb = [];
        for(int i = 0; i < _ean.Count(); i ++
        ){
            if(_ean[i] == true)
            {
                _ = _tb.Append(i);
            }
        }
        return _tb;
    }
    private static List<int> BoolListToAvailable(bool[] _ean) //haha boolean
    {
        List<int> _tb = [];
        for(int i = 0; i < _ean.Count(); i ++)
        {
            if(_ean[i] == false)
            {
                _tb.Add(i);
            }
        }
        return _tb;
    }
 
}