using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PWMGR
{
    public class EntryGroup
    {  
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }
        public int Size => Entries.Count;
        
        public Entry selectedEntry;
        public ConsoleColor GroupColor { get; set; }
        
        /// <summary>
        /// A group of login entries.
        /// </summary>
        /// <param name="name"></param> name for this group of entries 
        /// <param name="color"></param> a designated color for this group of entries 
        public EntryGroup(string name, ConsoleColor color = ConsoleColor.Black) { 
            Name = name;
            GroupColor = color;

            Entries = new List<Entry>();
            selectedEntry = new Entry("", this);
        }

        public EntryGroup()
        {
            
        }
        
        
        #region Functionality Methods
        public void Add(Entry entry) {
            Entries.Add(entry);
            SelectEntry(entry);
        }

        public void Remove(Entry entry) {
            try
            {
                Entries.Remove(entry);
            }
            catch
            {
                int i = 0;
            }
            
        }

        public void SelectEntry(Entry entry)
        {
            selectedEntry = entry;
        }
        
        #endregion

        #region Filtering methods

        public IEnumerable<Entry> GetByTagList(string tag) {
            return Entries
                .Where(e => e.Tags.Contains(tag));
        }

        public IEnumerable<Entry> GetByTitle(string title)
        {
            return Entries
                .Where(e => e.Title.Equals(title));
        }

        public IEnumerable<Entry> GetByUsername(string username)
        {
            return Entries
                .Where(e => e.Username.Equals(username));
        }

        public IEnumerable<Entry> GetByURL(string url)
        {
            return Entries
                .Where(e => e.URL.Equals(url));
        }


        #endregion

        #region Sorting methods
        
        public IEnumerable<Entry> SortByPassword()
        {
            return 
                from e in Entries
                orderby e.Password
                select e;
        }

        public IOrderedEnumerable<Entry> SortByTitle(string title)
        {
           return 
                from e in Entries
                orderby e.Title
                select e;
        }

        public IEnumerable<Entry> SortByUsername()
        {
            return 
                from e in Entries
                orderby e.Username
                select e;
        }

        public IEnumerable<Entry> SortByURL()
        {
            return 
                from e in Entries
                orderby e.URL
                select e;
        }

        #endregion

        
        #region Get attributes

        public IEnumerable<string[]> GetTableData()
        {
            return Entries
                .Select(e => new string[] 
                    { e.Title, e.Username, e.Password, e.URL, e.Id.ToString() });
        }
        #endregion
        
        
        #region Serialization

        public void ApplyParent()
        {
            foreach (Entry entry in Entries)
            {
                entry.Group = this;
            }
        }
        

        #endregion
    }
}
