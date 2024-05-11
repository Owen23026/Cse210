using System;

class Program
{
    static void Main(string[] args)
    {
        Job j1 = new Job();
        Job j2 = new Job();

        j1._company = "Microsoft";
        j1._jobTitle = "Software Engineer";
        j1._startYear = 2003;
        j1._endYear = 2004;

        j2._company = "NASA";
        j2._jobTitle = "Robotics Software Engineer";
        j2._startYear = 2030;
        j2._endYear = 2040;




        Resume rsme = new Resume([j1, j2]); 
        rsme.name = "Owen";

        //Console.WriteLine(rsme._jobs[1]._company);

        rsme.Display();
    }
}