
namespace Attendance.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using Attendance.ViewModels;

/// <summary>
/// This is a ViewModel which represents a <see cref="Models.StudentItem"/>
/// </summary>
public partial class StudentItemViewModel : ViewModelBase
{
    /// <summary>
    /// Creates a new blank StudentItemViewModel
    /// </summary>
    public StudentItemViewModel()
    {
        // empty
    }

    /// <summary>
    /// Creates a new StudentItemViewModel for the given <see cref="Models.StudentItem"/>
    /// </summary>
    /// <param name="item">The item to load</param>
    public StudentItemViewModel(StudentItem item)
    {
        // Init the properties with the given values
        IsChecked = item.IsChecked;
        Content = item.Content;
    }



    /// <summary>
    /// Gets or sets the checked status of each item
    /// </summary>
    [ObservableProperty]
    private bool _isChecked;

    /// <summary>
    /// Gets or sets the content of the to-do item
    /// </summary>
    [ObservableProperty]
    private string? _content;


    /// <summary>
    /// Gets a StudentItem of this ViewModel
    /// </summary>
    /// <returns>The StudentItem</returns>
    public StudentItem GetStudentItem()
    {
        return new StudentItem()
        {
            IsChecked = this.IsChecked,
            Content = this.Content
        };
    }
}