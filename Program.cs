using System;
using System.IO;

namespace User_Story_11
{
    internal class Program
    {
        public static bool Check(string file_name, string user, string pass)
        {
            string[] lines = File.ReadAllLines(file_name);
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                string username = words[0];
                string password = words[1];

                if (username == user && password == pass) return true;
            }
            return false;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("=== Connect Stock Market Account ===");
            List<string> platforms = new List<string> { "Robinhood", "E*TRADE", "Fidelity", "Charles Schwab" };
            Console.WriteLine("Ur platforms :");

            for (int i = 0; i < platforms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {platforms[i]}");
            }

            Console.WriteLine("select platform from platforms : ");
            int s = Convert.ToInt32(Console.ReadLine());
            if (s < 1 || s > platforms.Count) Console.WriteLine("invalid selection");

            string pf = platforms[s - 1];

            Console.WriteLine($"You selected: {pf}");


            Console.WriteLine("Enter username: ");
            string user = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string pass = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine("Credentials cannot be empty. Please try again.");
                return;
            }

            bool t = Check("C:\\Users\\hp\\Desktop\\User_Story_11\\User_Story_11\\user.txt", user, pass);

            if (t) Console.WriteLine($" Account linked successfully with {pf}!");
            else Console.WriteLine("Invalid credentials. Please try again.");
        }
    }
}
