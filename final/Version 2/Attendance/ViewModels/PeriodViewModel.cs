
namespace Attendance.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using Attendance.ViewModels;
using System.Collections.ObjectModel;

/// <summary>
/// This is a ViewModel which represents a <see cref="Models.Period"/>
/// </summary>
public partial class PeriodViewModel : ViewModelBase
{
    /// <summary>
    /// Creates a new blank PeriodViewModel
    /// </summary>
    public PeriodViewModel()
    {
        // empty
    }

    /// <summary>
    /// Creates a new PeriodViewModel for the given <see cref="Models.Period"/>
    /// </summary>
    /// <param name="item">The item to load</param>
    public PeriodViewModel(PeriodItem item)
    {
        // Init the properties with the given values
        Students = item.Students;
        Title = item.Title;
        
    }



    /// <summary>
    /// Gets or sets the checked status of each item
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<StudentItemViewModel> _students;

    /// <summary>
    /// Gets or sets the content of the to-do item
    /// </summary>
    [ObservableProperty]
    private string? _title;


    /// <summary>
    /// Gets a Period of this ViewModel
    /// </summary>
    /// <returns>The Period</returns>
    public PeriodItem GetPeriod()
    {
        return new PeriodItem()
        {
            Title = this.Title,
            Students = this.Students
        };
    }

    public PeriodViewModel NoRef()
    {
        return new PeriodViewModel()
        {
            Title = this.Title,
            Students = this.Students
        };
    }

    public ObservableCollection<StudentItemViewModel> GetStudents()
    {
        PeriodItem temp = new PeriodItem() {
            Students = this.Students
        };
        Students ??= [];
        return temp.Students;
    }

    public string ToDebugString()
    {
        if(Students != null)
        {
        return Title + ", Students: " + Students.ToString();
        }
        else
        {
            return Title + " Students: Null";
        }
    }
}