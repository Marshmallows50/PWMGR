using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataStructure
{   /// <summary>
    /// A class representation of a username - password pair for an associated website. 
    /// </summary>
    public class LoginInfo
    {
        public string Username { get; }
        public string Password { get; }
        public string URL { get; }
        public int Id { get; }


        public LoginInfo(string user, string pass, string url, int id)
        {
            Username = user;
            Password = pass;
            URL = url;
            Id = id;
        }

        public override string ToString()
        {
            return String.Format("Username: {0,7:S} || Password:{1,19:S} || URL: {2,15:S} || Id: {3,1:D}",
                                Username,Password,URL,Id);
        }
        
        /// <summary>
        /// Demonstration of basic functionality, LINQ, and lamdas.
        /// </summary>
        public static void Demonstration()
        {
            int n = 1;
            IEnumerable<LoginInfo> logins = new List<LoginInfo> {
                new LoginInfo("Ri","Unh@ckab13PAsSW0rd","coolwebsite.com",n++),
                new LoginInfo("Gabe","l33tMar$All0ooooow","hello.com",n++),
                new LoginInfo("Hunter","CA1iTripp1n","goodbye.com",n++),
                new LoginInfo("Jasmine","H1kinGH@Xz","coolwebsite.com",n++),
                new LoginInfo("Steven","Mmmmyst3ryM@N","goodbye.com",n++),
            };

            Console.WriteLine("All users:");
            Console.WriteLine("==================================================================================");
            foreach (LoginInfo login in logins)
            {
                Console.WriteLine(login);
            }
            Console.WriteLine();

            Console.WriteLine("All users from 'goodbye.com':");
            Console.WriteLine("==================================================================================");
            IEnumerable<LoginInfo> goodbyeLogins = logins
                .Where(l => l.URL.Equals("goodbye.com"));
            Console.WriteLine(String.Join("\n", goodbyeLogins));
            Console.WriteLine();

            Console.WriteLine("All users from 'coolwebsite.com':");
            Console.WriteLine("==================================================================================");
            IEnumerable<LoginInfo> coolLogins = logins
                .Where(l => l.URL.Equals("coolwebsite.com"));
            Console.WriteLine(String.Join("\n", coolLogins));
            Console.WriteLine();

            Console.WriteLine("Users with password > 14 characters:");
            Console.WriteLine("==================================================================================");
            IEnumerable<LoginInfo> strongLogins = logins
                .Where(l => l.Password.Length > 14);
            Console.WriteLine(String.Join("\n", strongLogins));
            Console.WriteLine();
        }
    }
}
