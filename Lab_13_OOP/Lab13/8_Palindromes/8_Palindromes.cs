class Program
{
    static bool IsPalindrome(string word)
    {
        return word.SequenceEqual(word.Reverse());
    }

    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        char[] delimiters = new[] { ' ', ',', '.', '?', '!' };
        var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        var palindromes = words.Where(w => IsPalindrome(w)).ToList();

        var sortedPalindromes = palindromes.Distinct().OrderBy(p => p).ToList();

        Console.WriteLine(string.Join(", ", sortedPalindromes));
    }
}
