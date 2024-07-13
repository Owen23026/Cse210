public class Assignment
{
    private float _score, _total;
    private string _title, _description;

    private DateTime _dueDate;

    public Assignment(string title, string description, float total)
    {
        this._title = title;
        this._description = description;
        this._total = total;
        
    }

    public void Update(float score)
    {
        this._score = score;
    }
}