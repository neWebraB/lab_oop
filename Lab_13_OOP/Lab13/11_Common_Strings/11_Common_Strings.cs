class Program
{
    static string HaveCommonSubstring(string a, string b)
    {
        bool commonSubstringExists = a.Any(charA => b.Contains(charA));

        return commonSubstringExists ? "yes" : "no";
    }

    static void Main()
    {
        Console.WriteLine("Enter A string:");
        string stringA = Console.ReadLine();
        Console.WriteLine("Enter B string:");
        string stringB = Console.ReadLine();

        string result = HaveCommonSubstring(stringA, stringB);

        Console.WriteLine("Output:");
        Console.WriteLine(result);
    }
}
