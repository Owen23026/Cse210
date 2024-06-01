using System.Collections;
using System.ComponentModel;
using Microsoft.VisualBasic;

public class Menu
{

    private int _iter = 0;
    private int _remv = 3;

    private static Reference _helamanr = new Reference("Helaman", 5, [12]);
    private static Reference _proverbsr = new Reference("Proverbs", 3, [3, 4, 5]);
    private static Reference _mosesr = new Reference("Moses", 7, 18);
    private Scripture _helaman = new Scripture(_helamanr, "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall");
    private Scripture _proverbs = new Scripture(_proverbsr, "Let not mercy and truth forsake thee bind them about thy neck; write them upon the table of thine heart So shalt thou find favour and good understanding in the sight of God and man Trust in the Lord with all thine heart; and lean not unto thine own understanding");
    private Scripture _moses = new Scripture(_mosesr, "And the Lord called his people Zion For they were of one heart and one mind and dwelt in righteousness");

    private WordDisplay _wds;
    public Menu(int script)
    {
        Console.WriteLine("Welcome to the Memorization Program!\n -Press enter to go Forward and \"A\" to go back.\n -Press \"A\" to enter how many words to replace at a time. (default 3)\n -Press \"S\" to generate a new seed\n -Press \"Q\" to quit.\n");
        //I know this is a terrible way of doing things. I mainly focused on logic and modularity rather than getting everything I could possibly implement
        switch(script)
        {
            case 1:
                //Console.WriteLine(_pro)
                _wds = new WordDisplay(_proverbs.FilledIndex(), _proverbs.EverythingList());
                break;
            case 2:
                _wds = new WordDisplay(_helaman.FilledIndex(), _helaman.EverythingList());
                break;
            case 3:
                _wds = new WordDisplay(_moses.FilledIndex(), _moses.EverythingList());
                break;
            default:
                break;
        }
    }
    public void Execute(ConsoleKey key)
    {
        switch(key)
        {
            case (ConsoleKey.Enter):
                //checks if enter has been pressed once.
                Console.Clear();
                if(_iter == 0){
                    _iter = 1;
                    _wds.Display();
                }else{
                    _wds.Remove(_remv);
                    _wds.Display();
                }
                
                break;
            case (ConsoleKey.B):
                Console.Clear();
                if(_iter == 0){
                    _iter = 1;
                    _wds.Display();
                }else{
                    _wds.Remove(-_remv);
                    _wds.Display();
                }
                
                break;
            case (ConsoleKey.A):
                Console.Clear();
                Console.WriteLine("How many characters to remove? ");
                _remv = int.Parse(Console.ReadLine());
                Console.Clear();
                break;
            case (ConsoleKey.Q):
                System.Environment.Exit(0);
                break;
            case (ConsoleKey.S):
                _wds.update();
                Console.Clear();
                _wds.Display();
                break;
            default:
                //Death
                Console.WriteLine("Not a valid input!!!");
                break;
        }
    }

}