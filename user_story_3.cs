using User_Stories;

namespace User_Stories
{
    public class Asset
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

    public class potrfolio
    {
        List<Asset> assets = new List<Asset>();
        public void add_asset(Asset asset)
        {
                assets.Add(asset);
            Console.WriteLine("Assets Added. ");
        }

        public void edit_asset(Asset asset) 
        {
            Console.WriteLine("Enter new name: ");
            string newname = Console.ReadLine();
            asset.name = newname;

            Console.WriteLine("Enter new value: ");
            double value = Console.Read();
            asset.val = value;
        }

        public void remove_asset(Asset asset)
        {
           assets.Remove(asset);
        }

        public void display()
        {
            Console.WriteLine("Ur portfolio");
            foreach (Asset asset in assets)
            {
                Console.WriteLine($"Type: {asset.type} | Name: {asset.name} | Qty: {asset.val}");
            }
        }
        }
    }
    internal class Program
    {
        public static void menu()
            {
        potrfolio p = new potrfolio();
        string c;
        do { 
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
        Console.WriteLine("Enter asset name :");
        a.name = Console.ReadLine();
        Console.WriteLine("Enter asset val :");

        if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
        {
            Console.WriteLine("invalid value");
            return;
        }
        a.val = value;   
        p.add_asset(a);
        p.display();
        Console.Write("Do you want to add another asset? (y/n): ");
        c = Console.ReadLine().ToLower();

          } while (c == "y");

    }
        static void Main(string[] args)
        {
           menu();
        }
    }