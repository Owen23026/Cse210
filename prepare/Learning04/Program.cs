namespace Learning04;
using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment test1 = new Assignment("Owen", "C#");
        Console.WriteLine(test1.GetSummary() + "\n");

        MathAssignment test2 = new("Heinz Doofenschmirtz", "Linear Algebra", "Section 4.1", "1, 2, 3, 5, 8, 13, 21");
        Console.WriteLine(test2.GetSummary());
        Console.WriteLine(test2.GetHomeworkList());

        WritingAssignment test3 = new("Dave", "English 150", "The Right to Repair Movement and it's Affects");
        Console.WriteLine(test3.GetSummary());
        Console.WriteLine(test3.GetWritingInformation());
    }
}