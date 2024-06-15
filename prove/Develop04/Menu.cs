public class Menu
{

    private Breathing _breathing = new();
    private Reflecting _reflecting = new();
    private Listing _listing = new();

    private Stretching _stretching = new();
    public Menu()
    {

    }
    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("Menu options:\n1. Start " + _breathing.ToString() + "\n2. Start "  + _reflecting.ToString() + "\n3. Start " + _listing.ToString() + "\n4. Start " + _stretching.ToString() + 
        "\n0. Quit");
        switch(int.Parse(Console.ReadLine()))
        {
            case 0:
                System.Environment.Exit(0);
                break;
            case 1:
                _breathing.Execute();
                //_breathing.
                break;
            case 2:
                _reflecting.Execute();
                break;
            case 3:
                _listing.Execute();
                break;
            case 4:
                _stretching.Execute();
                break;
            default:
                break;
        }
    }
}