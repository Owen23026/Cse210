using System.Runtime.CompilerServices;
using Develop04;

public class Listing : Activity
{
    public Listing()
    {
        _title = "Listing Activity";
    }   
    public override void Execute()
    {
        int seconds = Welcome();
        int _count = 0;

        Gentry _listDisplay = new Gentry("lprompt.txt");

        Console.WriteLine("Consider the following prompt:\n\n");
        Console.WriteLine("---" + _listDisplay.Genentry() + "---");
        Console.WriteLine("\nStarting in ");
        Timer.LoadNum(5);
        


        DateTime fTime = DateTime.Now.AddSeconds(seconds);
        Console.WriteLine();
        while(fTime > DateTime.Now)
        {
            Console.Write("-> ");
            Console.ReadLine();
            _count++;
        }
        Console.WriteLine("You listed " + _count + " items!");
        Thread.Sleep(1000);
        Done();
    }
}