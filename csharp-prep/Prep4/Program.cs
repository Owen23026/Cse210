using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        //We are going to use 1 until I understand nullables in c#
        double addnum = 1; //I dislike this "buffer" number. I am going to try and minimize its memory usage

        List<double> dList = new List<double>();
        do
        {
            Console.WriteLine("Enter a Number: ");
            addnum = double.Parse(Console.ReadLine());
            dList.Add(addnum);

        }while(addnum != 0);

        //I am not sure how I feel about languages that just let you sum things automatically...
        //Oh, and if you're reading this, or any of my future code, have fun! I write the most random and unhinged comments that help me remember what things do
        Console.WriteLine("The sum is " + dList.Sum());
        //I swear If I can automatically get the average
        Console.WriteLine("The average is: " + dList.Average());
        //I have no words
        Console.WriteLine("The largest number is " + dList.Max());
        //Fortunately, all future operations need the sorted list so we can just sort it right here.
        dList.Sort();

        foreach(double i in dList){
            if(i > 0){
                Console.WriteLine("The Smallest positive number is " + i);
                break;
            }
        }
        
        //.sort feels reduntant. Perhaps it wouldve been better to declare a variable of the sorted list (Done now)
        Console.Write("The sorted list is ");
        //unfortnately, arraylist.tostring does not work like it does in java
        foreach(double i in dList){
            //so too does .length not work as well
            if(i < dList.Count - 1)
            {
                Console.Write(i + ", ");
            }
            else
            {
                Console.Write("and " + i + ".\n");
            }
            
        }

    }
}