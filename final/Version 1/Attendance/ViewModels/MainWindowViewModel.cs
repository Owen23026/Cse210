﻿namespace Attendance.ViewModels;

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

    
    
    
}



//warning, things will probably start going downhill with this piece of code.
public ObservableCollection<PeriodViewModel> _periods { get; set; } = [];

[RelayCommand (CanExecute = nameof(CanAddPeriod))]
private void AddPeriod()
{

    _periods.Add(new PeriodViewModel() {Title = NewPeriodContent});

    // reset the NewItemContent
    NewPeriodContent = null;

}

[RelayCommand (CanExecute = nameof(CanRemovePeriod))]
private void RemovePeriod()
{
    //lets just get this code working ,then Ill worry about ui later
    Console.Write("Removing " + _periods[Index].Title);
    _periods.Remove(_periods[Index]);
    //lower the index so that items arent randomly removed
    Index = -1;
    Last = null;
    
}



//get ready for some tokyo drifting code.
//lets try and call switch2period, and set "last" in the constructor so that we dont get any errors with last not being assigned
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
private PeriodViewModel? _last = null;
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(RemovePeriodCommand))]
[NotifyCanExecuteChangedFor(nameof(AddItemCommand))]
private int _index = -1;

//this takes a string since I didnt want to delve too much into avalonia command parameters
[RelayCommand]
private void Switch2Period(PeriodViewModel period)
{
    Index = _periods.IndexOf(period);
    Console.WriteLine("index is" + Index.ToString());
   
    
    //PeriodViewModel _current = period.NoRef();
    //what needs to be done: The last period needs to be saved to matrix.

    



    if(Last == null)
    {
       // _last = new PeriodViewModel {Title = period.Title, Students = StudentItems};
        period.Students = StudentItems;
        _periods[Index] = period;
        //Last = _periods[Index];
        Console.Write("Last was Null");
        
        
    }
    else
    {   
        //Console.WriteLine(Last.Students.ToString());
        //before changing last, get the index of the last list, then, set that index to the modified last
        int _lIndex = _periods.IndexOf(Last);
        //Console.WriteLine(_periods.Contains(Last).ToString());
        Last.Students.Clear();
        foreach(StudentItemViewModel sd in StudentItems)
        {
            Console.WriteLine(sd.Content);
            Last.Students.Add(sd);
        }
       
        _periods[_lIndex] = Last;

        //finally, write the input's students to studentItems and set last to the last index
        //Console.WriteLine(_current.Students[0].Content);
        //StudentItems = [];
        this.StudentItems.Clear();
        ObservableCollection<StudentItemViewModel> _newlist = period.GetStudents();
        
        foreach(StudentItemViewModel sd in period.GetStudents())
        {
            Console.WriteLine(sd.Content);
            this.StudentItems.Add(sd);
        }
        
        
        
        
        
    }

    //Console.WriteLine("Success! : " + period.ToDebugString());
    Last = _periods[Index];
    //set the collection to a new one if its null
    StudentItems ??= [];
    UpdateSDItems();
    Console.Write("Switched to" + Last.Title);
}


[RelayCommand]
private void DebugList()
{
    //StudentItems.Add(new StudentItemViewModel(new StudentItem{Content = "bruh", IsChecked = false}));
    
}

private void MoveCollections(ObservableCollection<StudentItemViewModel> l1, ObservableCollection<StudentItemViewModel> l2)
{
    Console.Write("mv");
    if(l1 == null){l1 = [];}
    l2 = [];

    for(int i = 0; i < l1.Count; i++)
    {
        l2.Add(l1[i]);
        Console.WriteLine(l2[i].Content);
    }
}

[RelayCommand]
private void DebugGetStudents()
{
    //set the collection to a new one if its null
    StudentItems ??= [];
    
    foreach(StudentItemViewModel sd in StudentItems)
    {
        Console.WriteLine(sd.Content);
    }
    
}

private void UpdateSDItems()
{
    //set the collection to a new one if its null
    StudentItems ??= [];
    ObservableCollection<StudentItemViewModel> temp = new ObservableCollection<StudentItemViewModel>();
    StudentItems.Clear();

    //get ready for memory usage 900000
    foreach(StudentItemViewModel sd in StudentItems)
    {
        //oh dear
        temp.Add(new StudentItemViewModel(sd.GetStudentItem()));
    }
    foreach(StudentItemViewModel sd in temp)
    {
        StudentItems.Add(sd);
    }
}
    
}