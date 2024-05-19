namespace Develop02;

class Entry
{
    public string _prompt, _entry, _date;

    //since this will be run each time a new _entry is created, why not handle the _prompt and stuff inside the constructor?
    //I could also implement constructor overloading, so that An _entry can be created without using this process.
    public Entry(){
        Gentry gen = new Gentry("prompt.txt");
        this._prompt = gen.Genentry();
        Console.WriteLine(this._prompt);
        this._entry = Console.ReadLine();
        DateTime theCurrentTime = DateTime.Now;
        this._date = theCurrentTime.ToShortDateString();
    }

    //turns out I ended up needing one.
    public Entry(string _entry, string _prompt, string _date){
        this._entry = _entry;
        this._prompt = _prompt;
        this._date = _date;
    }


    public string ToString(){
        return _prompt + "\n" + _entry + "\nWritten " + _date;
    }
}