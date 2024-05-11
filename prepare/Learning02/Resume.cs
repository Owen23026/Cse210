public class Resume
{
    public List<Job> _jobs = new List<Job>();
    public string name;

    public Resume(List<Job> jlist)
    {
        this._jobs = jlist;
    }

    public void Display(){
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Jobs:");
        foreach(var job in _jobs)
        {
            job.Display();
        }
    }
}