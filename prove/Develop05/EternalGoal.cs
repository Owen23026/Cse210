namespace Develop05;

public class EternalGoal : Goal
{

    public EternalGoal()
    {
        Console.WriteLine("What is the name of your Goal? ");
        _title = Console.ReadLine();
        Console.WriteLine("What is a description of your Goal? ");
        _description = Console.ReadLine();
        Console.WriteLine("How many points is your Goal worth? ");
        _points = int.Parse(Console.ReadLine());
        _type = 2;
    }

    public EternalGoal(string title, string desc, string count, string points, string total)
    {
        this._title = title;
        this._description = desc;
        this._points = int.Parse(points);
        this._total = int.Parse(total);
        this._count = int.Parse(count);
        _type = 2;
    }

    public override void UpdateGoal()
    {
        Console.WriteLine("Congratulations you completed " + _title + " and earned " + _points + " points! Keep it up!");
    }
}