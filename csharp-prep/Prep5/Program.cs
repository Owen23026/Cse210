using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        welcomeClass mainobj = new welcomeClass();
        //I should get better at formatting, and organizing my classes
        mainobj.assignuName();
        mainobj.assignuNum();
        mainobj.squareFNumber();
        mainobj.DisplayResult();
        //I thought about doing more object shenanigans such as making a list of objects where it would ask to add more people and things
        //That way static variables would be more fitting to get the total amount of people, and information like that.
        
    }
}

public class welcomeClass
{
    private string uName;
    private double uNum, sqNum;

    //does the constructor count for DisplayWelcome?
    public welcomeClass()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    public void squareFNumber()
    {
        this.sqNum = Math.Pow(this.uNum, 2);
    }

    public void assignuName()
    {
        Console.Write("What is your name? ");
        this.uName = Console.ReadLine();
        Console.Write("What is your quest? ");
        Console.ReadLine();
    }

    public void assignuNum()
    {
        Console.Write("What is your favorite number? ");
        this.uNum = double.Parse(Console.ReadLine());
    }

    public void DisplayResult()
    {
        Console.WriteLine($"{uName}, the square of your favorite number is {sqNum}");
    }
    
    public String ToString(){
        return $"Name: {this.uName}, Num: {this.uNum}, Square: {this.sqNum}";
    }
}
/*
Assignment Instructions

For this assignment, write a C# program that has several simple functions:

    DisplayWelcome - Displays the message, "Welcome to the Program!"
    PromptUserName - Asks for and returns the user's name (as a string)
    PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
    SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
    DisplayResult - Accepts the user's name and the squared number and displays them.

Your Main function should then call each of these functions saving the return values and passing data to them as necessary.

Sample output of the program could look as follows:


Welcome to the program!
Please enter your name: Brother Burton
Please enter your favorite number: 42
Brother Burton, the square of your number is 1764
*/