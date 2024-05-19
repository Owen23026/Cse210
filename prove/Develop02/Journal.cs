using System.Formats.Tar;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization.Metadata;
using System.Xml.Linq;

namespace Develop02;

public class Journal
{
    List<Entry> _jData = new List<Entry>();

    
    public void NewEntry()
    {
        Entry _newEntry = new Entry();
        _jData.Add(_newEntry);
    }
    //This will convert the 3 strings stored in _entry to a format for the file.
    //this format will die if brackets are used, so dont.
    //maybe ill learn to use toml or something later.
    // [
    // s1
    // s2
    // s3
    // ][
    // ]
    
    //this is going to be one of those very long methods isnt it.
    public void ConvertPush()
    {
        //I mean, you could have journal take in a file name, but that would be a bit redundant for something that in all actuallity should likely be defined by the user
        Fmanager _fileManager = new Fmanager("save.txt");
        //This list will be loaded to the file.
        List<string> _rawList = new List<string>();

        //this wasnt as bad as I thought
        foreach(Entry _e in _jData)
        {
            if(_e == _jData[0])
            {
                _rawList.Add("[");
            }
            _rawList.Add(_e._entry);
            _rawList.Add(_e._prompt);
            _rawList.Add(_e._date);
            if(_e == _jData[_jData.Count - 1])
            {
                _rawList.Add("]");
            }
            else
            {
                _rawList.Add("][");
            }
        }

        _fileManager._raw = _rawList;
        _fileManager.Save2File();
    }

    public void ConvertPush(string _fname)
    {
        //I mean, you could have journal take in a file name, but that would be a bit redundant for something that in all actuallity should likely be defined by the user
        Fmanager _fileManager = new Fmanager(_fname);
        //This list will be loaded to the file.
        List<string> _rawList = new List<string>();

        //this wasnt as bad as I thought
        foreach(Entry _e in _jData)
        {
            if(_e == _jData[0])
            {
                _rawList.Add("[");
            }
            _rawList.Add(_e._entry);
            _rawList.Add(_e._prompt);
            _rawList.Add(_e._date);
            if(_e == _jData[_jData.Count - 1])
            {
                _rawList.Add("]");
            }
            else
            {
                _rawList.Add("][");
            }
        }

        _fileManager._raw = _rawList;
        _fileManager.Save2File();
    }

    //now we just need to do all of that backwards. aaaand now I need a new constructor for entries.
    public void ConvertPull()
    {
        //this is getting a bit redundant, maybe I should make file_manager a dedicated class variable.
        Fmanager file_manager = new Fmanager("save.txt");
        file_manager.Load2Array();
        //we will see what this does.
        _jData.Clear();

        string t_entry = "how do";
        string t_prompt = "you use";
        string tDate = "c#?";
        int i = 0;
        foreach(string l in file_manager._raw)
        {
            //check if this is a special line.
            if(l.Contains("["))
            {
                i = 0;
            }
            else
            {
                i += 1;
                switch(i)
                {
                    case 1:
                        t_entry = l;
                        break;
                    case 2:
                        t_prompt = l;
                        break;
                    case 3:
                        tDate = l;
                        break;
                    default:
                        //this should not happen :(
                        break;
                }
            }
            //check if it has a closing bracket and write to 
            if(l.Contains("]"))
            {
                Entry temp_entry = new Entry(t_entry, t_prompt, tDate);
                _jData.Add(temp_entry);
            }
        }
    }

    public void ConvertPull(string _fname)
    {
        //this is getting a bit redundant, maybe I should make file_manager a dedicated class variable.
        Fmanager file_manager = new Fmanager(_fname);
        file_manager.Load2Array();
        //we will see what this does.
        _jData.Clear();

        string t_entry = "how do";
        string t_prompt = "you use";
        string tDate = "c#?";
        int i = 0;
        foreach(string l in file_manager._raw)
        {
            //check if this is a special line.
            if(l.Contains("["))
            {
                i = 0;
            }
            else
            {
                i += 1;
                switch(i)
                {
                    case 1:
                        t_entry = l;
                        break;
                    case 2:
                        t_prompt = l;
                        break;
                    case 3:
                        tDate = l;
                        break;
                    default:
                        //this should not happen :(
                        break;
                }
            }
            //check if it has a closing bracket and write to 
            if(l.Contains("]"))
            {
                Entry temp_entry = new Entry(t_entry, t_prompt, tDate);
                _jData.Add(temp_entry);
            }
        }
    }

    public string ToString()
    {
        string _rstr = "";
        for(int _i = 0; _i < _jData.Count; _i++)
        {
            Entry _e = _jData[_i];
            _rstr = _rstr + "\nJournal " + (_i + 1) + ":\n" + _e.ToString() + "\n";
        }

        return _rstr;
    }
}