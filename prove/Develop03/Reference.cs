public class Reference
{
    private string _book;
    private int[] _verses;
    private int _chapter;


    public Reference(string _book, int _chapter, int[] _verses)
    {
        this._book =_book;
        this._chapter = _chapter;
        this._verses = _verses;
    }
    public Reference(string _book, int _chapter, int _verse)
    {
        this._book =_book;
        this._chapter = _chapter;
        this._verses = [_verse];
    }

    private static string PalatableVerses(int[] _verses)
    {
        string rstr = "";
        //Console.WriteLine(_verses.Count());
        for(int i = 0; i < _verses.Count(); i ++)
        {
            //Console.WriteLine(i-1);
            if(i == 0)
            {
                rstr = string.Concat(rstr, _verses[i]);
            }
            else if(i > 0 && _verses[i] - _verses[i - 1] > 1)
            {
                rstr = string.Concat(rstr, ", " + _verses[i]);
            }
            else if((i+1 < _verses.Count() && _verses[i + 1] - _verses[i] > 1) && (i > 0 && _verses[i] - _verses[i - 1] > 1))
            {
                rstr = string.Concat(rstr, _verses[i]);
            }
            else if(i+1 < _verses.Count() && _verses[i + 1] - _verses[i] > 1)
            {
                rstr = string.Concat(rstr, "-" + _verses[i]);
            }
            
        }
        return rstr;
    }

    public string ToString()
    {
        if(_verses.Count() == 1){
            return _book + " chapter " + _chapter + ", verse " + PalatableVerses(_verses) + "\n";
        }else{
            return _book + " chapter " + _chapter + ", verses " + PalatableVerses(_verses) + "\n";
        }
        
    }


}