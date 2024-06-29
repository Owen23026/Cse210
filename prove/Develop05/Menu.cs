using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using Develop05;

public class Menu
{

    private List<Goal> _goals = new List<Goal>();
    private int _points, _streak;
    private string fname;
    public Menu()
    {
        Console.WriteLine("Enter the file name to load: ");
        fname = Console.ReadLine();
        Fmanager _saveload = new Fmanager(fname);
        ConvertPull();
    }


    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("You have " + _points + " points, and a " + _streak + " day streak");
        Console.WriteLine("Menu options:\n1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Change File" + 
        "\n0. Quit");
        switch(int.Parse(Console.ReadLine()))
        {
            case 0:
                System.Environment.Exit(0);
                break;
            case 1:
                //create new Goal

                CreateGoal();
                
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Goals: ");
                ListGoals();
                Console.ReadLine();
                break;
            case 3:
                ConvertPush();
                Console.Clear();
                Console.WriteLine("File Saved!");
                Console.ReadKey();
                break;
            case 4:

                ConvertPull();
                Console.Clear();
                Console.WriteLine("File Loaded!");
                Console.ReadKey();
                break;
            case 5:
                RecordEvent();
                break;
            case 6:
                Console.WriteLine("File name: ");
                fname = Console.ReadLine();
                break;
            default:
                break;
        }
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Select one of the following goals:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                _goals.Add(new SimpleGoal());
                break;
            case 2: 
                _goals.Add(new EternalGoal());
                break;
            case 3:
                _goals.Add(new ChecklistGoal());
                break;
            default:
                break;
        }
    }

    private void ListGoals()
    {
        for(int i = 0; i < _goals.Count(); i ++)
        {
            Console.Write((i+1) +". ");
            Console.WriteLine(_goals[i].ToString());
        }
    }

    private void RecordEvent()
    {
        Console.Clear();
        ListGoals();
        Console.WriteLine("Update a goal! Goal Number: ");
        int _tmpIndex = int.Parse(Console.ReadLine()) - 1;
        
        if(_goals[_tmpIndex].IsComplete())
        {
            Console.WriteLine("Your Goal is already complete!");
            Console.ReadKey();
        }
        else
        {
            //update the goal at the selected index only if the goal isnt already complete. check if the goal is now complete
            _goals[_tmpIndex].UpdateGoal();
            if(_goals[_tmpIndex].IsComplete())
            {
            _points += _goals[_tmpIndex].GetPoints();
            Console.ReadKey();
            }
            else if(_goals[_tmpIndex].GetType() == 2)
            {
                _points += _goals[_tmpIndex].GetPoints();
                Console.ReadKey();
            }
            
        }
    }

    public void ConvertPush()
    {
        
        //I mean, you could have journal take in a file name, but that would be a bit redundant for something that in all actuallity should likely be defined by the user
        Fmanager _fileManager = new Fmanager(fname);
        //This list will be loaded to the file.
        List<string> _rawList = new List<string>();

        //this wasnt as bad as I thought
        foreach(Goal _g in _goals)
        {
            if(_g == _goals[0])
            {
                _rawList.Add("-->" + _streak + ":" + DateTime.UtcNow.ToShortDateString().Replace("/", ":"));
                _rawList.Add("[");
            }
            string[] tmpdat = _g.PushInfo();
            _rawList.Add(tmpdat[0]);
            _rawList.Add(tmpdat[1]);
            _rawList.Add(tmpdat[2]);
            _rawList.Add(tmpdat[3]);
            _rawList.Add(tmpdat[4]);
            _rawList.Add(tmpdat[5]);

            if(_g == _goals[_goals.Count - 1])
            {
                _rawList.Add("]");
            }
            else
            {
                _rawList.Add("][");
            }
        }

        _fileManager._raw = _rawList;
        _fileManager.Save2File();
    }


  
    public void ConvertPull()
    {
        //this is getting a bit redundant, maybe I should make file_manager a dedicated class variable.
        Fmanager file_manager = new Fmanager(fname);
        file_manager.Load2Array();
        //we will see what this does.
        _goals.Clear();

        string type, title, description, count, total, points;
        type = "";
        title = "";
        description = "";
        count = "";
        total = "";
        points = "";

        int i = -1;
        foreach(string l in file_manager._raw)
        {
            //this should execute at the very beginning
            if(i == -1)
            {
                i = 0;
                string tempstreak;
                tempstreak = l[3..];
                
                string[] datetime = tempstreak.Split(":");
                _streak = int.Parse(datetime[0]);

//why cant time be easier
                DateTime last = new DateTime(int.Parse(datetime[3]),int.Parse(datetime[1]), int.Parse(datetime[2]));

                if(((DateTime.UtcNow - last).TotalHours > 24) && (DateTime.UtcNow - last).TotalHours < 48)
                {
                    _streak+=1;
                }  
                else if((DateTime.UtcNow - last).TotalHours < 48)
                {
                   
                }
                else
                {
                     _streak = 0;
                }
                
            }
            //check if this is a special line.
            if(l.Contains("["))
            {
                i = 0;
            }
            else
            {
                i += 1;
                switch(i - 1)
                {
                    case 0:
                        type = l;
                        break;
                    case 1:
                        title = l;
                        break;
                    case 2:
                        description = l;
                        break;
                    case 3:
                        count = l;
                        break;
                    case 4:
                        total = l;
                        break;
                    case 5:
                        points = l;
                        break;
                    default:
                        //this should not happen :(
                        break;
                }
            }
            //check if it has a closing bracket and write to 
            if(l.Contains("]"))
            {
                //I need to ask for help with this problem
                //this goal should never exist
                Goal tempgoal = new SimpleGoal("DEBUG", "DEBUG","1", "1", "1");
                //I really shouldve done overloading
                switch(int.Parse(type))
                {
                    case 1:
                        tempgoal = new SimpleGoal(title, description, count, total, points);
                        break;
                    case 2:
                        tempgoal = new EternalGoal(title, description, count, total, points);
                        break;
                    case 3:
                        tempgoal = new ChecklistGoal(title, description, count, total, points);
                        break;
                    default:
                        break;
                }
                
                _goals.Add(tempgoal);
            }
        }

        foreach(Goal _g in _goals)
        {
            this._points += _g.GetPoints();
        }
    }

}