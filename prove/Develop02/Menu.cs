namespace Develop02;

public class Menu{

    public Journal _mainJournal = new();
    string _cFname = "save.txt";
    public int DisplayMenu()
    {
        Console.Write("Please select one of the following choices:\n1. Write\n2. Display\n3. Open File\n4. Load\n5. Save As\n6. Save\n7. Quit\nWhat would you like to do? ");
        return int.Parse(Console.ReadLine());
    }

//consider merging the menu methods for better looping. Alternatively, store this statement in main, where it might make more sense
    public void Execute(int i)
    {
        switch(i)
        {
            case 1:
                //Write
                _mainJournal.NewEntry();
                break;
            case 2:
                //Display
                Console.WriteLine(_mainJournal.ToString());
                break;
            case 3:
                //Open File
                Console.WriteLine("File name: ");
                _mainJournal.ConvertPull(_cFname = Console.ReadLine());
                Console.WriteLine("File loaded to ram!");
                break;
            case 4:
                //Load
                _mainJournal.ConvertPull(_cFname);
                Console.WriteLine("File loaded to ram!");
                break;
            case 5:
                //save as
                Console.WriteLine("File name: ");
                _mainJournal.ConvertPush(_cFname = Console.ReadLine());
                Console.WriteLine("File saved!");
                break;
            case 6:
                //save
                _mainJournal.ConvertPush(_cFname);
                Console.WriteLine("File saved!");
                break;
            case 7:
                //Quit
                Console.WriteLine("Thank you for using the Journal Program!");
                System.Environment.Exit(0);
                break;
            default:
                //Death
                Console.WriteLine("Not a valid number!!!");
                break;
        }
    }

}