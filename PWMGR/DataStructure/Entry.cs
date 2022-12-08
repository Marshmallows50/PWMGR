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
    public class Entry
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public int Id { get; set; }
        public List<string> Tags { get; set; }
        
        [XmlIgnore]
        public EntryGroup Group { get; set; }

        private static int nextId = 0;
        


        public Entry
            (string title, EntryGroup group, string user=" ", string pass=" ", string url=" ")
        {
            Tags = new List<string>();
            Title = title;
            Username = user;
            Password = pass;
            URL = url;
            Id = nextId++;
            Group = group;
        }

        public Entry()
        {
            
        }

        public int GetIndex()
        {
            return Group.Entries.IndexOf(this);
        }
        
    }
}
