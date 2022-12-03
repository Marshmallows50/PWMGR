using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DemoDataStructure;

namespace DemoDataStructure
{
    public class Entries
    {  
        public string Name { get; set; }
        public List<Entry> EntriesContainer { get; }

        public int Size { get; }

        public ConsoleColor GroupColor { get; set; }
        
        /// <summary>
        /// A group of login entries.
        /// </summary>
        /// <param name="name"></param> name for this group of entries 
        /// <param name="entries"></param>
        /// <param name="color"></param> a designated color for this group of entries 
        Entries(string name, List<Entry> entries = null, ConsoleColor color = ConsoleColor.Black) { 
            Name = name;
            EntriesContainer = entries;
            GroupColor = color;
        }
        #region Functionality Methods
        public void add(Entry entry) {
            EntriesContainer.Add(entry);
        }

        public void remove(Entry entry) {
            EntriesContainer.Remove(entry);
        }

        #endregion

        #region Filtering methods

        public IEnumerable<Entry> GetByTag(string tag) {
            return EntriesContainer
                .Where(e => e.URL.Equals(tag));
        }

        public IEnumerable<Entry> GetByTitle(string title)
        {
            return EntriesContainer
                .Where(e => e.URL.Equals(title));
        }

        public IEnumerable<Entry> GetByUsername(string username)
        {
            return EntriesContainer
                .Where(e => e.URL.Equals(username));
        }

        public IEnumerable<Entry> GetByURL(string url)
        {
            return EntriesContainer
                .Where(e => e.URL.Equals(url));
        }

        #endregion

        #region Sorting methods
        public IEnumerable<Entry> SortByTags()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entry> SortByTitle()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entry> SortByUsername()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entry> SortByURL()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Serialization

        //TODO

        #endregion

        #region Get attibutes

        //TODO

        #endregion

        /// <summary>
        /// Demonstration of basic functionality, LINQ, and lamdas.
        /// </summary>
        public static void Demonstration()
        {
            int n = 1;
            IEnumerable<Entry> logins = new List<Entry> {
                new Entry("Ri","Unh@ckab13PAsSW0rd","coolwebsite.com",n++, "2410 Group Project"),
                new Entry("Gabe","l33tMar$All0ooooow","hello.com",n++, "2410 Group Project"),
                new Entry("Hunter","CA1iTripp1n","goodbye.com",n++, "2410 Group Project"),
                new Entry("Jasmine","H1kinGH@Xz","coolwebsite.com",n++,"2410 Group Project"),
                new Entry("Steven","Mmmmyst3ryM@N","goodbye.com",n++,"2410 Group Project")
            };

            Console.WriteLine("All users:");
            Console.WriteLine("==================================================================================");
            foreach (Entry login in logins)
            {
                Console.WriteLine(login);
            }
            Console.WriteLine();

            Console.WriteLine("All users from 'goodbye.com':");
            Console.WriteLine("==================================================================================");
            IEnumerable<Entry> goodbyeLogins = logins
                .Where(l => l.URL.Equals("goodbye.com"));
            Console.WriteLine(String.Join("\n", goodbyeLogins));
            Console.WriteLine();

            Console.WriteLine("All users from 'coolwebsite.com':");
            Console.WriteLine("==================================================================================");
            IEnumerable<Entry> coolLogins = logins
                .Where(l => l.URL.Equals("coolwebsite.com"));
            Console.WriteLine(String.Join("\n", coolLogins));
            Console.WriteLine();

            Console.WriteLine("Users with password > 14 characters:");
            Console.WriteLine("==================================================================================");
            IEnumerable<Entry> strongLogins = logins
                .Where(l => l.Password.Length > 14);
            Console.WriteLine(String.Join("\n", strongLogins));
            Console.WriteLine();
        }
    }
}
