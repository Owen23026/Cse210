using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Internal;

namespace Testing;

class Program
{
    
    static void Main(string[] args)
    {
        String ctest = "hello";
        Console.WriteLine(ctest);
        ctest = Console.ReadLine();
        Console.WriteLine(ctest);
    }
}
