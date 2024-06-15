using System.Runtime.CompilerServices;
using Develop04;

public class Reflecting : Activity
{
    public Reflecting()
    {
        _title = "Reflecting Activity";
    }   
    public override void Execute()
    {
        int seconds = Welcome();
        Gentry _mainDisplay = new Gentry("rprompt.txt");
        Gentry _subDisplay = new Gentry("rsprompt.txt");

        Console.WriteLine("Consider the following prompt:\n\n");
        Console.WriteLine("---" + _mainDisplay.Genentry() + "---");
        Console.WriteLine("\nWhen you have something in mind press enter to continue");
        Console.ReadKey();
        DateTime fTime = DateTime.Now.AddSeconds(seconds);
        while(fTime > DateTime.Now)
        {
            Console.WriteLine("\n");
            Console.Write(_subDisplay.Genentry() + " ");
            Timer.Load(4);
        }
        Done();
    }

}