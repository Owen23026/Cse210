using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        while(true)
        {
            menu.Execute();
        }
        
    }
    //for the sake of simplicity, lets include streak in updategoal, and maybe seperate completed and not completed goals.
}