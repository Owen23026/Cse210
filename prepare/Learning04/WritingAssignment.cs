namespace Learning04;
public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string _sName, string _topic, string _title) : base(_sName, _topic)
    {
        this._title = _title;
    }


    public string GetWritingInformation()
    {
        return _title + " by " + _studentName;
    }
}
