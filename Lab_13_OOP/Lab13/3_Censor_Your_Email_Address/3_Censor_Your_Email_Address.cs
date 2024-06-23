class EmailCensor
{
    static void Main()
    {
        Console.WriteLine("Enter your email address:");
        string email = Console.ReadLine();

        Console.WriteLine("Enter text to censor it:");
        string text = Console.ReadLine();

        string censoredEmail = CensorEmail(email);
        string censoredText = text.Replace(email, censoredEmail);

        Console.WriteLine("Censored Text:");
        Console.WriteLine(censoredText);
    }

    static string CensorEmail(string email)
    {
        int atIndex = email.IndexOf('@');
        string username = email.Substring(0, atIndex);
        string domain = email.Substring(atIndex);

        string censoredUsername = new string('*', username.Length);
        return censoredUsername + domain;
    }
}

