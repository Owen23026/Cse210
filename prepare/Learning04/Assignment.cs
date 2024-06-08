namespace Learning04;
using System;

public class Assignment
{   
    protected string _studentName;
    private string _topic;

    public Assignment(string _sName, string _topic)
    {
        this._studentName = _sName;
        this._topic = _topic;
    }

    public string GetSummary(){
        return _studentName + " - " +_topic;
    }
}