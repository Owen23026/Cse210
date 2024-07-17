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

public class Save
{
    //here is our student list
    public ObservableCollection<StudentItemViewModel> StudentItems { get; set; } = new ObservableCollection<StudentItemViewModel>();
    private string _fname = "save/save.txt";
    private List<string> _raw = new List<string>();


    public ObservableCollection<ObservableCollection<StudentItemViewModel>> LoadFile()
    {
        using (StreamWriter w = File.AppendText(_fname));
        using(StreamReader _fr = new StreamReader(_fname))
        {
            string _line;
            while((_line = (_fr.ReadLine())) != null)
            {
                _raw.Add(_line);
            }
        }

        //at this point we now have a list of all of the lines in the file.
        //create the periods list to be returned
        ObservableCollection<ObservableCollection<StudentItemViewModel>> periods = new ObservableCollection<ObservableCollection<StudentItemViewModel>>();

        //iterate through the raw list. Check if a line has has "period" in it (lets hope no students are named period)
        //eventually a better implementation would be better
        //when period is detected, create a new studentItemViewModel list, and load all of the names of each period so the list.


        return periods;
    }

    public void SaveFile(ObservableCollection<ObservableCollection<StudentItemViewModel>> periods)
    {
        using(StreamWriter _fw = new StreamWriter(_fname))
        {
            foreach(string _line in _raw)
            {
                _fw.WriteLine(_line);
            }
        }        
    }
}