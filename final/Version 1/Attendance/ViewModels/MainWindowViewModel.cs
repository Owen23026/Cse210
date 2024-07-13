namespace Attendance.ViewModels;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

public partial class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    //public string Greeting => "The roll taking window";
#pragma warning restore CA1822 // Mark members as static

public ObservableCollection<StudentItemViewModel> StudentItems { get; } = new ObservableCollection<StudentItemViewModel>();

/// <summary>
/// Gets or set the content for new Items to add. If this string is not empty, the AddItemCommand will be enabled automatically
/// </summary>
[ObservableProperty]
[NotifyCanExecuteChangedFor(nameof(AddItemCommand))] // This attribute will invalidate the command each time this property changes
private string? _newItemContent;

/// <summary>
/// Returns if a new Item can be added. We require to have the NewItem some Text
/// </summary>
private bool CanAddItem() => !string.IsNullOrWhiteSpace(NewItemContent);
/// <summary>
/// This command is used to add a new Item to the List
/// </summary>
[RelayCommand (CanExecute = nameof(CanAddItem))]
private void AddItem()
{
    // Add a new item to the list
    StudentItems.Add(new StudentItemViewModel() {Content = NewItemContent});

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
}



//will this work?
//Yes
public MainWindowViewModel()
{
    // StudentItem placeholder = new StudentItem();
    // placeholder.IsChecked(true);
    // placeholder.Content("Hello world, this is a Student");
    ObservableCollection<string> _slist = new ObservableCollection<string>();
    _slist.Add("bob");
    _slist.Add("tim");
    _slist.Add("bob (the better one)");

    for(int i = 0; i < _slist.Count; i++)
    {
        StudentItems.Add(new StudentItemViewModel() {Content = _slist[i]});
    }
}
}