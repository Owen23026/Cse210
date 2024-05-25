public class Scripture
{
    private string _book;
    private string[] _passage;
    private int _chapter, _verse;
    public Scripture()
    {

    }
    public Scripture(string _book, int _chapter, int _verse, string _passage)
    {
        this._book = _book;
        this._chapter = _chapter;
        this._verse = _verse;
        this._passage = _passage.Split(" ");
    }


}