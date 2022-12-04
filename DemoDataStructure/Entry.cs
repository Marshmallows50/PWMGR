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
            (string title, string user, string pass, string url, int id, string group)
        {
            Tags = new List<string>();
            Title = title;
            Username = user;
            Password = pass;
            URL = url;
            Id = id;
            Group = group;
        }

        public override string ToString()
        {
            return String.Format("Title: {0,7:S}  || Username: {1,7:S} || Password:{2,19:S} || URL: {3,15:S} || Id: {4,1:D}",
                                Title,Username,Password,URL,Id);
        }
    }
}
