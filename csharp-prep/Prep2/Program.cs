using System;

class Program
{
    static void Main(string[] args)
    {
        String grstr, psfl;
        Console.Write("What was your Grade? ");
        int grade = int.Parse(Console.ReadLine());
        if(grade > 100 || grade < 0){
            Console.WriteLine("Grade is invalid");
            //Id like to learn about error handling and OS interfacing with C#
            System.Environment.Exit(404);
        }
        if(grade >= 70){
            psfl = "You Passed!";
        }else{
            psfl = "You Failed :(";
        }
        switch(grade / 10)
        {
            case 10:
                grstr = "an A";
            break;
            case 9:
                grstr = "an A";
            break;
            case 8:
                grstr = "a B";
            break;
            case 7:
                grstr = "a C";
            break;
            case 6:
                grstr = "a D";
            break;
            default:
                grstr = "an F";
            break;
        }
        if(grade >= 60 && grade <= 96){
            //This might help performance for cpu, but hurt memory performance slightly
            int x = grade%10;
            if(x >= 7){
                grstr = grstr + "+";
            }else if(x <= 3){
                grstr = grstr + "-";
            }
        }
        Console.WriteLine("Your grade is " + grstr + ". " + psfl);
    }
}