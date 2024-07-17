using System.Collections.ObjectModel;
using Attendance.ViewModels;

public class PeriodItem
{
    public string? Title { get; set; }
    public ObservableCollection<StudentItemViewModel>? Students { get; set; }
}