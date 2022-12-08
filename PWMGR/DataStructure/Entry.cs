using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PWMGR
{   /// <summary>
    /// A class representation of a username - password pair for an associated website. 
    /// </summary>
    [Serializable]
    public class Entry
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public int Id { get; set; }
        public List<string> Tags { get; set; }
        
        public EntryGroup Group { get; set; }
        



        public Entry
            (string title, EntryGroup group, int id, string user=" ", string pass=" ", string url=" ")
        {
            Tags = new List<string>();
            Title = title;
            Username = user;
            Password = pass;
            URL = url;
            Id = id;
            Group = group;
        }
        
        public int GetIndex()
        {
            return Group.Entries.IndexOf(this);
        }
        
    }
}
