using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApp1;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class User
    {
        public string name;
        public string user_name;
        public string email;
        public string password;

        public bool Register()
        {
            Console.Write("Name: ");
            this.name = Console.ReadLine();

            Console.Write("Email: ");
            this.email = Console.ReadLine();

            Console.Write("User Name: ");
            this.user_name = Console.ReadLine();

            Console.Write("Password: ");
            this.password = Console.ReadLine();

            bool flag = false;
            for (int i = 0; i < this.email.Length; i++)
            {
                if (this.email[i] == '@')
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine("Invalid email address - must contain @ symbol!");
                return false;
            }

            if (this.password.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters!");
                return false;
            }

            string userData = $"{user_name}#//#{password}#//#{name}#//#{email}";
            File.AppendAllText("SignUp.txt", userData + Environment.NewLine);

            return true;
        }

        public bool Login()
        {
            Console.Write("please enter your user name: ");
            String user = Console.ReadLine();
            Console.Write("please enter your password: ");
            String pass = Console.ReadLine();
            string filePath = @"SignUp.txt";

            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                if (parts[0] == user && parts[1] == pass)
                {
                    this.user_name = user;
                    this.password = pass;

                    Console.WriteLine("loged in successfully!");
                    return true;
                }
            }
            Console.WriteLine("Invalid username or password.");
            return false;
        }
    }

    class Asset
    {
        private string Name;
        private string Type;
        private double Val;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string type
        {
            get { return Type; }
            set { Type = value; }
        }

        public double val
        {
            get { return Val; }
            set { Val = value; }
        }
    }

    class potrfolio
    {
        protected List<Asset> assets = new List<Asset>();

        public void add_asset(Asset asset)
        {
            assets.Add(asset);
            Console.WriteLine("Assets Added. ");
        }

        public void edit_asset(Asset asset)
        {
            foreach (Asset a in assets)
            {
                if (a.name == asset.name && a.val == asset.val && a.type == asset.type)
                {
                    Console.Write("Enter new name: ");
                    string newname = Console.ReadLine();
                    a.name = newname;

                    Console.Write("Enter new value: ");
                    if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
                    {
                        Console.WriteLine("Invalid value");
                        return;
                    }
                    a.val = value;

                    Console.WriteLine("Asset updated successfully.");
                    return;
                }
            }

            Console.WriteLine("Asset not found for editing.");
        }

        public List<Asset> get_asset()
        {
            return assets;
        }

        public void display()
        {
            Console.WriteLine("Ur portfolio");
            foreach (Asset asset in assets)
            {
                Console.WriteLine($"Type: {asset.type} | Name: {asset.name} | Qty: {asset.val}");
            }
        }

        public void remove_asset(Asset asset)
        {
            assets.Remove(asset);
        }

        public void menu_3()
        {
            string c;
            do
            {
                Asset a = new Asset();
                Console.WriteLine("=== Add Assets ===");
                Console.WriteLine("Select Asset Type:\n1. Stocks\n2. Real Estate\n3. Crypto\n4. Gold\nChoice: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        a.type = "Stock";
                        break;
                    case 2:
                        a.type = "Real Estate";
                        break;
                    case 3:
                        a.type = "Crypto";
                        break;
                    case 4:
                        a.type = "Gold";
                        break;
                    default:
                        Console.WriteLine("please choose a valid number;");
                        break;
                }

                Console.Write("Enter asset name :");
                a.name = Console.ReadLine();
                Console.Write("Enter asset val :");

                if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
                {
                    Console.WriteLine("invalid value");
                    return;
                }

                a.val = value;
                add_asset(a);
                display();

                Console.Write("Do you want to add another asset? (y/n): ");
                c = Console.ReadLine().ToLower();
            } while (c == "y");
        }

        public void calculate_Zakat()
        {
            //int num_of_assets;
            //Console.WriteLine("please enter the number of assets you want to calculate zakat for: ");
            //num_of_assets = Convert.ToInt32(Console.ReadLine());

            //while (num_of_assets <= 0)
            //{
            //    Console.WriteLine("invalid number of investments!");
            //    Console.WriteLine("please enter the number of assets you want to calculate zakat for: ");
            //    num_of_assets = Convert.ToInt32(Console.ReadLine());
            //}

            double total_investment = 0;
            foreach (Asset a in assets)
            {
                total_investment += a.val;
            }

            if (total_investment < 500000)
            {
                Console.WriteLine("Not enough enough amount to pay the zakat");
            }
            else
            {
                Console.WriteLine($"Zakat amount: {total_investment * .025}");
            }
        }
    }

    class market
    {
        private User user;
        public market(User user)
        {
            this.user = user;
        }
        public bool Check( string u, string pass)
        {
            return this.user.user_name == u && this.user.password == pass;
        }


        public void menu_market()
        {
            Console.WriteLine("=== Connect Stock Market Account ===");
            List<string> platforms = new List<string> { "Robinhood", "E*TRADE", "Fidelity", "Charles Schwab" };
            Console.WriteLine("Ur platforms :");

            for (int i = 0; i < platforms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {platforms[i]}");
            }

            Console.Write("select platform from platforms : ");
            int s = Convert.ToInt32(Console.ReadLine());
            if (s < 1 || s > platforms.Count) Console.WriteLine("invalid selection");

            string pf = platforms[s - 1];

            Console.WriteLine($"You selected: {pf}");

            Console.Write("Enter username: ");
            string user = Console.ReadLine();

            Console.Write("Enter password: ");
            string pass = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                Console.WriteLine("Credentials cannot be empty. Please try again.");
                return;
            }

            bool t = Check( user, pass);

            if (t) {
                Console.WriteLine($" Account linked successfully with {pf}!");
                string[] lines = File.ReadAllLines(@"SignUp.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(new string[] { "#//#" }, StringSplitOptions.None);
                    if (parts[0] == user)
                    {
                        if (parts.Length < 5)
                        {
                            lines[i] += $"#//#{pf}";
                        }
                        else
                        {
                            parts[4] = pf;
                            lines[i] = string.Join("#//#", parts);
                        }
                        break;
                    }
                }
                File.WriteAllLines(@"SignUp.txt", lines);
            }

            else Console.WriteLine("Invalid credentials. Please try again.");
        }
    }

    class edit
    {
        private potrfolio p;

        public edit(potrfolio portfolio)
        {
            p = portfolio;
        }

        public bool check(Asset a)
        {
            foreach (Asset asset in p.get_asset())
            {
                if (a.val == asset.val && a.name == asset.name)
                {
                    return true;
                }
            }
            return false;
        }

        public void menu_edit()
        {
            string c;
            do
            {
                Asset a = new Asset();
                Console.WriteLine("=== Edit Assets ===");
                Console.WriteLine("Select Asset Type:\n1. Stocks\n2. Real Estate\n3. Crypto\n4. Gold\nChoice: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        a.type = "Stock";
                        break;
                    case 2:
                        a.type = "Real Estate";
                        break;
                    case 3:
                        a.type = "Crypto";
                        break;
                    case 4:
                        a.type = "Gold";
                        break;
                    default:
                        Console.WriteLine("please choose a valid number;");
                        break;
                }

                Console.Write("Enter asset name :");
                a.name = Console.ReadLine();

                Console.Write("Enter asset val :");

                if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
                {
                    Console.WriteLine("invalid value");
                    return;
                }

                a.val = value;

                if (check(a))
                {
                    p.edit_asset(a);
                    p.display();
                }
                else
                {
                    Console.WriteLine("Invalid information!");
                }

                Console.Write("Do you want to edit another asset? (y/n): ");
                c = Console.ReadLine().ToLower();

            } while (c == "y");
        }
    }

    class RemoveAsset
    {
        private potrfolio p;

        public RemoveAsset(potrfolio portfolio)
        {
            p = portfolio;
        }

        public bool check(Asset a)
        {
            foreach (Asset asset in p.get_asset())
            {
                if (a.val == asset.val && a.name == asset.name)
                {
                    return true;
                }
            }
            return false;
        }

        public void menu_remove()
        {
            string c;
            do
            {
                Asset a = new Asset();
                Console.WriteLine("=== Remove Assets ===");
                Console.WriteLine("Select Asset Type:\n1. Stocks\n2. Real Estate\n3. Crypto\n4. Gold\nChoice: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        a.type = "Stock";
                        break;
                    case 2:
                        a.type = "Real Estate";
                        break;
                    case 3:
                        a.type = "Crypto";
                        break;
                    case 4:
                        a.type = "Gold";
                        break;
                    default:
                        Console.WriteLine("please choose a valid number;");
                        break;
                }

                Console.WriteLine("Enter asset name :");
                a.name = Console.ReadLine();

                Console.WriteLine("Enter asset val :");

                if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
                {
                    Console.WriteLine("invalid value");
                    return;
                }

                a.val = value;

                if (check(a))
                {
                    p.remove_asset(a);
                    p.display();
                }
                else
                {
                    Console.WriteLine("Invalid information!");
                }

                Console.Write("Do you want to remove another asset? (y/n): ");
                c = Console.ReadLine().ToLower();

            } while (c == "y");
        }
    }

    internal class Program
    {
        public static void Menu(User user)
        {
            potrfolio p = new potrfolio();
            
            market m = new market(user);
            edit e = new edit(p);
            RemoveAsset remove = new RemoveAsset(p);

            int ch;
            do
            {
                Console.WriteLine("===Welcome in investwise===");
                Console.WriteLine("Choose option : ");
                Console.WriteLine("1.Add Assets ");
                Console.WriteLine("2.Edit Assets ");
                Console.WriteLine("3.Remove Assets ");
                Console.WriteLine("4.Zakat Calc ");
                Console.WriteLine("5.Connect Acount with market ");
                Console.WriteLine("6. Exist");
                Console.Write("Enter ur choice : ");
                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        p.menu_3();
                        break;
                    case 2:
                        e.menu_edit();
                        break;
                    case 3:
                        remove.menu_remove();
                        break;
                    case 4:
                        p.calculate_Zakat();
                        break;
                    case 5:
                        m.menu_market();
                        break;
                    case 6:
                        Console.WriteLine("Exist of program , salam ");
                        break;
                    default:
                        Console.WriteLine("invalid option , please try again ");
                        break;
                }

                if (ch != 6)
                {
                    Console.WriteLine("Press any key to continue to menu...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (ch != 6);
        }

        static void Main(string[] args)
        {
            User user = new User();
            bool log = false;

            while (!log)
            {
                Console.WriteLine("=== Welcome to InvestWise ===");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (user.Register())
                        {
                            Console.WriteLine("Sign up successful. You can now login.");
                        }
                        else
                        {
                            Console.WriteLine("Sign up failed. Please try again.");
                        }
                        break;

                    case "2":
                        if (user.Login())
                        {
                            log = true;
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Try again.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }

                Console.WriteLine();
            }

            Menu(user);
        }

    }
}
