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
        public Entries(string name, ConsoleColor color = ConsoleColor.Black) { 
            Name = name;
            GroupColor = color;

            EntriesContainer = new List<Entry>();
        }
        
        
        #region Functionality Methods
        public void Add(Entry entry) {
            EntriesContainer.Add(entry);
        }

        public void Remove(Entry entry) {
            EntriesContainer.Remove(entry);
        }
        #endregion

        #region Filtering methods

        public IEnumerable<Entry> GetByTagList(string tag) {
            return EntriesContainer
                .Where(e => e.Tags.Contains(tag));
        }

        public IEnumerable<Entry> GetByTitle(string title)
        {
            return EntriesContainer
                .Where(e => e.Title.Equals(title));
        }

        public IEnumerable<Entry> GetByUsername(string username)
        {
            return EntriesContainer
                .Where(e => e.Username.Equals(username));
        }

        public IEnumerable<Entry> GetByURL(string url)
        {
            return EntriesContainer
                .Where(e => e.URL.Equals(url));
        }


        #endregion

        #region Sorting methods
        
        public IEnumerable<Entry> SortByPassword()
        {
            return 
                from e in EntriesContainer
                orderby e.Password
                select e;
        }
        public IEnumerable<Entry> SortByTags()
        {
            throw new NotImplementedException();
        }

        public IOrderedEnumerable<Entry> SortByTitle(string title)
        {
           return 
                from e in EntriesContainer
                orderby e.Title
                select e;
        }

        public IEnumerable<Entry> SortByUsername()
        {
            return 
                from e in EntriesContainer
                orderby e.Username
                select e;
        }

        public IEnumerable<Entry> SortByURL()
        {
            return 
                from e in EntriesContainer
                orderby e.URL
                select e;
        }

        #endregion

        
        #region Get attributes
        
        #endregion
        
        
        #region Serialization

        //TODO

        #endregion



        /// <summary>
        /// Demonstration of basic functionality, LINQ, and lamdas.
        /// </summary>
        public static void Demonstration()
        {
            int n = 1;
            IEnumerable<Entry> logins = new List<Entry> {
                new Entry("Person","Ri","Unh@ckab13PAsSW0rd","coolwebsite.com",n++, "2410 Group Project"),
                new Entry("Person","Gabe","l33tMar$All0ooooow","hello.com",n++, "2410 Group Project"),
                new Entry("Non-Person","Hunter","CA1iTripp1n","goodbye.com",n++, "2410 Group Project"),
                new Entry("Person","Jasmine","H1kinGH@Xz","coolwebsite.com",n++,"2410 Group Project"),
                new Entry("Person","Steven","Mmmmyst3ryM@N","goodbye.com",n++,"2410 Group Project")
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
