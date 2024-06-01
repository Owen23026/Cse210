using System;
using System.Data.SqlTypes;

class Program
{
    static void Main(string[] args)
    {
        //change this value to 1 for proverbs, 2 for helamen, and 3 for moses
        Menu menu = new Menu(3);

        while(true)
        {
            menu.Execute(Console.ReadKey(true).Key);
        }

    }
}