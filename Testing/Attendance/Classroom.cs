//this file should manage the classes and send string information when asked
//perhaps we should use classroom as much as possible with gui in mind, and then interface the menu with it.
namespace attendance;
public class Classroom()
{
    private List<Class> _classes;
    int _selectedClass;
    public string ListClasses()
    {
        return "todo";
    }

    public void AddClass()
    {
        _classes.Add(new Class());
    }

    
    public void EditStudent(List<Student> students)
    {

    }

    
}