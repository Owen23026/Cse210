using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public class Breathing : Activity
{
    public Breathing()
    {
        _title = "Breathing Activity";
        _description = "This activity will help you relax by having you take deep breaths";
    }   
    public override void Execute()
    {
        int seconds = Welcome();
        DateTime fTime = DateTime.Now.AddSeconds(seconds);
        while(fTime > DateTime.Now)
        {
            Console.WriteLine("Breathe in...");
            Timer.Load(5);
            Console.WriteLine("Breathe out...");
            Timer.Load(5);
        }
        Done();
    }
    
}