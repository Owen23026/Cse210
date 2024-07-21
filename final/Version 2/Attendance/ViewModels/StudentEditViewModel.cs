using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Attendance.ViewModels;

public partial class StudentEditViewModel : ViewModelBase
{
    public StudentEditViewModel(StudentItemViewModel item)
    {
        Content = item.Content;
    }

    [ObservableProperty]
    private string? _content;

    [RelayCommand]
    private void DeleteStudent()
    {

    }
}