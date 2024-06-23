class Program
{
    static int FindPalindromeIndex(string s)
    {
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j])
            {
                if (IsPalindrome(s, i + 1, j))
                {
                    return i;
                }
                else if (IsPalindrome(s, i, j - 1))
                {
                    return j;
                }
            }
        }
        return -1;
    }

    static bool IsPalindrome(string s, int start, int end)
    {
        for (int i = start, j = end; i < j; i++, j--)
        {
            if (s[i] != s[j])
            {
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        Console.WriteLine("Enter string:");
        string input = Console.ReadLine();

        int index = FindPalindromeIndex(input);

        Console.WriteLine("Output:");
        Console.WriteLine(index);
    }
}
