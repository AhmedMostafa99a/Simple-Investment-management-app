using System;

internal class User
{
    private string name;
    private string username;
    private string email;
    private string password;
    // private Portfolio portfolio;

    public bool Register()
    {
        // Name input
        Console.WriteLine("Name: ");
        this.name = Console.ReadLine();

        // Email input
        Console.WriteLine("Email: ");
        this.email = Console.ReadLine();

        // Username input
        Console.WriteLine("User Name: ");
        this.username = Console.ReadLine();

        // Password input
        Console.WriteLine("Password: ");
        this.password = Console.ReadLine();

        // Validate email
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

        return true;
    }

    public bool Login() {
        
        Console.Write("please enter your user name: ");
        username = Console.ReadLine();
        Console.Write("please enter your password: ");
        password = Console.ReadLine();
        string filePath = @"SignUp.txt";
        foreach (string line in File.ReadLines(filePath))
        {
            string[] parts = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
            if (parts[0] == username && parts[1] == password)
            {
                Console.WriteLine("loged in successfully!");
                return true;
            }
        }
        Console.WriteLine("Invalid username or password.");
        return false;
        }

}

internal class Program
{
    static public void Main()
    {
        User user = new User();
        if (user.Register())
        {
            Console.WriteLine("Sign up successfully done!");
        }
        else
        {
            Console.WriteLine("Sign up failed. Please try again.");
        }
    }
}