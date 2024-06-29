
using System.Security.Cryptography;

namespace Develop05;

public abstract class Goal
{
protected int _count, _total, _points;
protected string _title, _description;

protected int _type;

public Goal()
{
    _count = 0;
}


protected string CheckComplete()
{
    if(_count == _total)
    {
        return "[x]";
    }
    else
    {
        return "[ ]";
    }
}

public bool IsComplete()
{
    return _count == _total;
}

public abstract void UpdateGoal();


public virtual string ToString()
{
    return CheckComplete() + " " +  _title + " (" + _description + ")";
}
// {
//     return _title + " " + _description + " " + _count + " out of " + _total;
// }

public int GetPoints()
{
    return _points;
}

public string GetTitle()
{
    return _title;
}

public string[] PushInfo()
{
    return [_type.ToString(), _title, _description, _count.ToString(), _total.ToString(), _points.ToString()];
}

public void PullInfo(string[] info)
{
    this._title = info[1];
    this._description = info[2];
    this._count = int.Parse(info[3]);
    this._total = int.Parse(info[4]);
    this._points = int.Parse(info[5]);
    this._type = int.Parse(info[0]);
}

}