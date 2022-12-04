using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoDataStructure
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
        public string Group { get; set; }
        


        public Entry
            (string user, string pass, string url, int id, string group)
        {
            Username = user;
            Password = pass;
            URL = url;
            Id = id;
            Group = group;
        }

        public override string ToString()
        {
            return String.Format("Username: {0,7:S} || Password:{1,19:S} || URL: {2,15:S} || Id: {3,1:D}",
                                Username,Password,URL,Id);
        }
    }
}
