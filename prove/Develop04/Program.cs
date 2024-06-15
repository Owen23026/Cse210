using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Mindfulness program!\nInitializing...");
        Loading ld = new Loading();
        ld.Load(3);

        Menu menu = new();
        while(true){
            menu.Execute();
        }
        
    }
}