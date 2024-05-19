using System.Runtime;
using System.Runtime.CompilerServices;

namespace Develop02;
class Program
{
    /*
    for the exceeding requirements, I added save as, and open file
    prompts were generated from chatgpt. Maybe Ill make this a dedicated app with chat integration later
    I first made this program under a different directory with the namespace project. Whoops.
    Hopefully everything still runs correctly. I compiled and tested it via bash. I am not sure how this will affect windows if at all.
    */
    static void Main(string[] args)
    {
        Menu _menu = new Menu();
        
        // Console.WriteLine(menu.displayMenu());
        while(true)
        {
            _menu.Execute(_menu.DisplayMenu());
        }

    }   
}
