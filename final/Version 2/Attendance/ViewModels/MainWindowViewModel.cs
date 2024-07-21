namespace Attendance.ViewModels;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using DynamicData.Binding;
using System.Linq;
using Attendance.Views;
using System.Data.SqlTypes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;
using DynamicData;
using Avalonia.Controls.Converters;

public partial class MainWindowViewModel : ViewModelBase
{
    


#pragma warning disable CA1822 // Mark members as static
    //public string Greeting => "The roll taking window";
#pragma warning restore CA1822 // Mark members as static


public ObservableCollection<StudentItemViewModel>? StudentItems { get; set; } = [];

/// <summary>
/// Gets or set the content for new Items to add. If this string is not empty, the AddItemCommand will be enabled automatically
/// </summary>
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(AddItemCommand))] // This attribute will invalidate the command each time this property changes
private string? _newItemContent;

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(AddPeriodCommand))] // This attribute will invalidate the command each time this property changes
private string? _newPeriodContent;

private Save svFile = new("save/save.txt");


//only add a student if there is already a class selected. there shouldnt be random students in ram
private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent) && CanRemovePeriod();
//you can add a period only if there is a name for the period
private bool CanAddPeriod() => !string.IsNullOrWhiteSpace(NewPeriodContent);
//you can only remove a period if there is one selected
private bool CanRemovePeriod() => !(Index == -1);

//Check if you can add and item. if so, allow the user to add an item
[RelayCommand (CanExecute = nameof(CanAddItem))]
private void AddItem()
{
    // Add a new item to the list
    StudentItems.Add(new StudentItemViewModel() {Content = NewItemContent, IsChecked = true});

    // reset the NewItemContent
    NewItemContent = null;
}

/// <summary>
/// Removes the given Item from the list
/// </summary>
/// <param name="item">the item to remove</param>
[RelayCommand]
private void RemoveItem(StudentItemViewModel item)
{
    // Remove the given item from the list
    StudentItems.Remove(item);
}

[RelayCommand]
private void MoreInfo(StudentItemViewModel item)
{
    // Remove the given item from the list
    Console.Write("More info");
    //create the student edit popup
    StudentEdit _sEditPop = new StudentEdit();
    _sEditPop.Show();
}





//will this work?
//Yes
public MainWindowViewModel()
{
    //_periods = svFile.GetTitles();

    foreach(string t in svFile.GetTitles())
    {
        _periods.Add(new PeriodViewModel{ Title = t});
    }
    
    if(_periods.Count > 0)
    {
        _last = null;
    }
    
    
}



//warning, things will probably start going downhill with this piece of code.
public ObservableCollection<PeriodViewModel> _periods { get; set; } = [];

[RelayCommand (CanExecute = nameof(CanAddPeriod))]
private void AddPeriod()
{

    _periods.Add(new PeriodViewModel{ Title = NewPeriodContent});
    svFile.AddPeriod(NewPeriodContent);
    if(_periods.Count <= 1)
    {
        _last = svFile.GetTitles()[0];
    }
    // reset the NewItemContent
    NewPeriodContent = null;

}

[RelayCommand (CanExecute = nameof(CanRemovePeriod))]
private void RemovePeriod()
{
    //lets just get this code working ,then Ill worry about ui later
    Console.Write("Removing " + _periods[Index].Title);
    svFile.RemovePeriod(_periods[Index].Title);
    _periods.Remove(_periods[Index]);
    //clear the list, as it should only ever contain students of the selected period
    StudentItems.Clear();
    //lower the index so that items arent randomly removed
    Index = -1;
    
}



//get ready for some tokyo drifting code.
//lets try and call switch2period, and set "last" in the constructor so that we dont get any errors with last not being assigned

private string? _last;

[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RemovePeriodCommand))]
[NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
private int _index = -1;

//this takes a string since I didnt want to delve too much into avalonia command parameters
[RelayCommand]
private void Switch2Period(PeriodViewModel period)
{
    Index = svFile.GetTitles().IndexOf(period.Title);
    ObservableCollection<string> studentFileWrite = [];
    ObservableCollection<string> studentFileRead = [];
// for a file based approach that is easier on ram, we need to first: 
// get the current list and its corresponding file location, and load student items to the file

//ok, so we have students and datetimes. We need to check if a
    if(_last != null){
        studentFileWrite = svFile.GetStudents(_last);

        foreach(StudentItemViewModel sdv in StudentItems)
        {
            bool studentNameIsInFile = false;
            ObservableCollection<string> fpebbles = svFile.GetStudents(_last);
            foreach(string info in fpebbles)
            {
                //check each line of the student info list for a student's name
                Console.WriteLine(info + "   " + sdv.Content);
                if(info.Contains(sdv.Content))
                {
                    //Console.WriteLine(sdv.Content + "is in file");
                    studentNameIsInFile = true;
                    if(!info.Contains(DateTime.UtcNow.ToShortDateString().Replace("/", ":")) && !sdv.IsChecked)
                    {
                        // ischecked + contained = remove
                        // ischecked + empty = noth
                        // notchecket + contained = n
                        // notchecked + empty = add
                        //if the current line has the student name, but doesnt have the current datetime, and the student isnt checked, than add the datetime
                        studentFileWrite[studentFileWrite.IndexOf(info)] = studentFileWrite[studentFileWrite.IndexOf(info)] + "-" + DateTime.UtcNow.ToShortDateString().Replace("/", ":");
                    }
                    if(sdv.IsChecked && info.Contains(DateTime.UtcNow.ToShortDateString().Replace("/", ":")))
                    {
                        studentFileWrite[studentFileWrite.IndexOf(info)] = info.Substring(0, info.IndexOf("-" + DateTime.UtcNow.ToShortDateString().Replace("/", ":")));
                    }
                }
                else
                {
                    //Console.WriteLine(sdv.Content + " isnt in file");
                }

            }
            if(studentNameIsInFile == false)
            {
                if(sdv.IsChecked)
                {
                    studentFileWrite.Add(sdv.Content);
                }else
                {
                    studentFileWrite.Add(sdv.Content + "-" + DateTime.UtcNow.ToShortDateString().Replace("/", ":"));
                }
            }
        }
        svFile.SetStudents(_last, studentFileWrite);
    }
    
//then we can find the new title in the file and load the strings to studentitems.
    StudentItems.Clear();
    studentFileRead = svFile.GetStudents(period.Title);
    foreach(string sd in studentFileRead)
    {
       // Console.Write("Loading file to list");
        if(sd.Contains(DateTime.UtcNow.ToShortDateString().Replace("/", ":")))
        {
            StudentItems.Add(new StudentItemViewModel{IsChecked = false, Content = sd.Substring(0, sd.IndexOf("-"))});
        } 
        else if(sd.Contains("-"))
        {
            StudentItems.Add(new StudentItemViewModel{IsChecked = true, Content = sd.Substring(0, sd.IndexOf("-"))});
        } 
        else
        {
            StudentItems.Add(new StudentItemViewModel{IsChecked = true, Content = sd});
        }
        
    }

    _last = period.Title;
    Console.WriteLine(_last); 
    //"-->" + _streak + ":" + DateTime.UtcNow.ToShortDateString().Replace("/", ":")

}

//this takes a string since I didnt want to delve too much into avalonia command parameters
[RelayCommand]
private void UpdateEverything()
{
    if(_last != null)
    {

        Index = svFile.GetTitles().IndexOf(_last);
        ObservableCollection<string> studentFileWrite = [];
        ObservableCollection<string> studentFileRead = [];
    // for a file based approach that is easier on ram, we need to first: 
    // get the current list and its corresponding file location, and load student items to the file
        if(_last != null){
            foreach(StudentItemViewModel sd in StudentItems)
            {
                //check the file for datetimes
                



                if(sd.IsChecked)
                {
                    studentFileWrite.Add(sd.Content);
                }
                else
                {
                    studentFileWrite.Add(sd.Content + "-" + DateTime.UtcNow.ToShortDateString().Replace("/", ":"));
                }
                
            }
            svFile.SetStudents(_last, studentFileWrite);
        }
        
    //then we can find the new title in the file and load the strings to studentitems.
        StudentItems.Clear();
        studentFileRead = svFile.GetStudents(_last);
        foreach(string sd in studentFileRead)
        {
            Console.Write("Loading file to list");
            if(sd.Contains(DateTime.UtcNow.ToShortDateString().Replace("/", ":")))
            {
                StudentItems.Add(new StudentItemViewModel{IsChecked = false, Content = sd.Substring(0, sd.IndexOf("-"))});
            } 
            else if(sd.Contains("-"))
            {
                StudentItems.Add(new StudentItemViewModel{IsChecked = true, Content = sd.Substring(0, sd.IndexOf("-"))});
            } 
            else
            {
                StudentItems.Add(new StudentItemViewModel{IsChecked = true, Content = sd});
            }
            
        }

        Console.WriteLine(_last); 
        //"-->" + _streak + ":" + DateTime.UtcNow.ToShortDateString().Replace("/", ":")
    }
}
}