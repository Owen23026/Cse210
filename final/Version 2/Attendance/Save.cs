using System.Diagnostics.CodeAnalysis;

namespace Attendance;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using DynamicData.Binding;
using System.Linq;
using Attendance.ViewModels;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using DynamicData;

public class Save
{
    //here is our student list
    public ObservableCollection<StudentItemViewModel> StudentItems { get; set; } = new ObservableCollection<StudentItemViewModel>();
    private string _fname = "save/save.txt";
    private List<string> _raw = new List<string>();

    public Save(string fname)
    {
        this._fname = fname;
    }

    public ObservableCollection<string> GetStudents(string period)
    {
        //just in case
        SaveFile();
        LoadRaw();
        ObservableCollection<string> sd = [];
        string l = "";
        bool canread = true;
        int i = 0;
        while(l != null)
        {
            //Console.WriteLine(_raw.Count.ToString());
            l = _raw[i];
            if(l.Contains("{"))
            {
                canread = false;
            }
            if(canread && l.Contains(period))
            {
                //jump past bracket
                i+=2;
                break;
                
            }
            if(l.Contains("}"))
            {
                canread = true;
            }
            
            i++;
        }
        while(true)
        {
            l = _raw[i];
            if(l.Contains("}")){break;}
            sd.Add(l);
            i++;
        }

        return sd;
    }       


    public void SetStudents(string period, ObservableCollection<string> students)
    {   
        if(period == null || students == null)
        {
            Console.WriteLine("Warning! null!");
        }
        LoadRaw();
        //C
        ObservableCollection<string> sd = [];
        string l = "";
        bool canread = true;
        int i = 0;
        int indexStart, indexEnd;
        while(i < _raw.Count-1)
        {
            l = _raw[i];
            if(l.Contains("{"))
            {
                canread = false;
            }
            if(canread && l.Contains(period))
            {
                //jump past bracket
                i+=2;
                break;
            }
            if(l.Contains("}"))
            {
                canread = true;
            }
            
            i++;
        }
        indexStart = i;
        while(i < _raw.Count-1)
        {
            l = _raw[i];
            if(l.Contains("}")){break;}
            i++;
        }
        indexEnd = i;
        
        if(students != null)
        {
            //WARNING NEEDS TESTING
            List<string> start, insert, end;
            start = _raw.GetRange(0, indexStart);
           // Console.WriteLine("cc " + _raw.Count.ToString());
            insert = students.ToList<string>();
            //who the heck designs a substring method to use how many elements you want. What?????
            end = _raw.GetRange(indexEnd, ((_raw.Count) - indexEnd));
            
            _raw = start.Concat(insert).Concat(end).ToList<string>();
        }
        SaveFile();
        
    }
    public ObservableCollection<string> GetTitles()
    {
        LoadRaw();
        ObservableCollection<string> _titles = new();
        bool canread = true;
        foreach(string l in _raw)
        {
            if(l.Contains("{"))
            {
                canread = false;
            }
            if(canread)
            {
                _titles.Add(l);
            }
            if(l.Contains("}"))
            {
                canread = true;
            }
        }

        return _titles;
    }


    public void LoadRaw()
    {
        //using (StreamWriter w = File.AppendText(_fname));
        _raw.Clear();
        using(StreamReader _fr = new StreamReader(_fname))
        {
            string _line;
            while((_line = (_fr.ReadLine())) != null)
            {
                _raw.Add(_line);
            }
        }

    }

    public void SaveFile()
    {
        using(StreamWriter _fw = new StreamWriter(_fname))
        {
            foreach(string _line in _raw)
            {
                _fw.WriteLine(_line);
            }
        }        
    }

    public void AddPeriod(string title)
    {
        LoadRaw();
        // foreach(string l in _raw)
        // {
        //     Console.WriteLine(l);
        // }
        _raw.Add(title);
        _raw.Add("{");
        _raw.Add("}");
        // foreach(string l in _raw)
        // {
        //     Console.WriteLine(l);
        // }
        SaveFile();
    }
    public void RemovePeriod(string title)
    {
        LoadRaw();
        //C
        ObservableCollection<string> sd = [];
        string l = "";
        bool canread = true;
        int i = 0;
        int indexStart, indexEnd;
        while(l != null)
        {
            l = _raw[i];
            if(l.Contains("{"))
            {
                canread = false;
            }
            if(canread && l.Contains(title))
            {
                //jump past bracket
                i+=2;
                break;
            }
            if(l.Contains("}"))
            {
                canread = true;
            }
            
            i++;
        }
        indexStart = i;
        while(true)
        {
            l = _raw[i];
            if(l.Contains("}")){break;}
            i++;
        }
        indexEnd = i;
        
            //WARNING NEEDS TESTING
            List<string> start, insert, end;
            start = _raw.GetRange(0, indexStart -2);
           // Console.WriteLine("cc " + _raw.Count.ToString());
           
            //who the heck designs a substring method to use how many elements you want. What?????
            end = _raw.GetRange(indexEnd + 1, ((_raw.Count) - indexEnd) - 1);
            
            _raw = start.Concat(end).ToList<string>();
        SaveFile();
    }

}