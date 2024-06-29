namespace Develop05;

public class SimpleGoal : Goal
{

    public SimpleGoal()
    {
        Console.WriteLine("What is the name of your Goal? ");
        _title = Console.ReadLine();
        Console.WriteLine("What is a description of your Goal? ");
        _description = Console.ReadLine();
        Console.WriteLine("How many points is your Goal worth? ");
        _points = int.Parse(Console.ReadLine());

        //Set total to one since this only needs activation once
        _total = 1;
    }



    public override void UpdateGoal()
    {
        if(_count == _total)
        {
            Console.WriteLine("Goal has already been completed!");
        }
        else
        {
            Console.WriteLine("Congratulations you completed " + _title + " and earned " + _points + " points!");
            _count ++;
        }
    }
}