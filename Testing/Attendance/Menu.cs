using attendance;

public class Menu
{
    public Menu()
    {

    }

    public void Execute()
    {
        Console.WriteLine("Main menu:\n");

        Console.WriteLine("1. add class\n2. save");

        switch(Console.ReadLine())
        {
            case "0":
                System.Environment.Exit(0);
                break;
            case "1":
            //add classS
                break;
            case "2":
            //save
                break;
        }
    }


}