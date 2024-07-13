namespace attendance;
public class Class{
    private List<Student> _students;
    private string _name;
    
    //returns a string for the menu. I like to have the main tostring be used for returning all data
    public String ToMenuString()
    {
        return _name;
    }
}