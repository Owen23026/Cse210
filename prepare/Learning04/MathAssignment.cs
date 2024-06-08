namespace Learning04;
public class MathAssignment : Assignment
{
    private string _textbooksection, _problems;
    public MathAssignment(string _sName, string _topic, string _textbooksection, string _problems) : base(_sName, _topic)
    {
        this._textbooksection = _textbooksection;
        this._problems = _problems;
    }
    public string GetHomeworkList()
    {
        return _textbooksection + ", problems " + _problems;
    }
}