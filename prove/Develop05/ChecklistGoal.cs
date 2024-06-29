using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Develop05;

public class ChecklistGoal : Goal
{
    public ChecklistGoal()
    {
        Console.WriteLine("What is the name of your Goal? ");
        _title = Console.ReadLine();
        Console.WriteLine("What is a description of your Goal? ");
        _description = Console.ReadLine();
        Console.WriteLine("How many points is your Goal worth? ");
        _points = int.Parse(Console.ReadLine());
        Console.WriteLine("How many times should your goal be completed? ");
        _total = int.Parse(Console.ReadLine());
    }
    public override string ToString()
    {
        return CheckComplete() + " " +  _title + " (" + _description + ") completed: (" + _count + "/" + _total + ")";
    }

    public override void UpdateGoal()
    {
        if(_count == _total)
        {
            Console.WriteLine("Goal has already been completed!");
        }
        else
        {
            _count ++;
            if(_count == _total)
            {
            Console.WriteLine("Congratulations you completed " + _title + " and earned " + _points + " points! Good Job!");
            }
        }
    }


}