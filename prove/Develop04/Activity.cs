using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Activity
{
    //Add datetime based timer for listing loop
    protected Loading Timer = new();
    protected string _description, _title;

    public Activity(){
        _title = "Hello world";
    }
    public virtual void Execute()
    {
        //I wanted to have a public welcome and private execute, but I couldnt figure out how to get the non-overridden welcom method to access the subclass execute
    }

    protected int Welcome()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the " + _title + "\n" + _description + "\nHow long in seconds would you like this activity to last?");
        return int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
        Timer.Load(2);
    }

    protected void Done()
    {
        Console.Clear();
        Console.WriteLine(_title + " is now finished, Good Job!");
        Timer.Load(3);
    }

    public virtual string ToString()
    {
        return _title;
    }

}