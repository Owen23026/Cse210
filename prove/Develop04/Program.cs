using System;

class Program
{

    /*
    I implemented a stretching activity for the stretch challenge that uses stretches from wii fit. It is not the greatest in terms of cleanliness,
    , and it would have been a good idea to automate the poses and use a specialized object as well.
    */
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