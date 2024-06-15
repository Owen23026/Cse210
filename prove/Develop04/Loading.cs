using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

public class Loading
{
    public Loading(){
        
    }

    public void Start(){

    }

    public void Stop(){
        
    }

    public void SetPercent(int pc){
        
    }

    public void SetPercent(int pc, string description){
        
    }

    public void Load(int seconds)
    {   
        char[] _ldbar = new string(' ' , seconds + 2).ToCharArray();
        _ldbar[0] = '[';
        _ldbar[_ldbar.Length -1] = ']';

        for(int i = 1; i < seconds + 2; i ++)
        {
            Console.Write(_ldbar);
            if(i > 1){_ldbar[i-1] = '=';}
            _ldbar[i]= '>';
            Thread.Sleep(1000);
            Console.Write(string.Concat(Enumerable.Repeat("\b", _ldbar.Length)));
        }
    }

//rename this to count down
    public void LoadNum(int seconds)
    {   
        for(double i = seconds; i > 0; i -= 0.25)
        {
            if((i % 1) == 0)
            {
                Console.Write(i.ToString());
            }
            else
            {
                Console.Write(".");
            }
            Thread.Sleep(250);
        }
    }

}