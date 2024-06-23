class Program
{
    static void Main()
    {
        Console.WriteLine("Enter sentence:");
        string sentence = Console.ReadLine();

        char[] separators = new char[] { '.', ',', ':', ';', '=', '(', ')', '[', ']', '"', '\\', '/', '!', '?', ' ' };

        string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

        string[] punctuation = sentence.Split(words, StringSplitOptions.RemoveEmptyEntries);

        string reversedSentence = string.Empty;
        for (int i = 0; i < words.Length; i++)
        {
            reversedSentence += words[i];
            if (i < punctuation.Length)
            {
                reversedSentence += punctuation[i];
            }
        }

        Console.WriteLine("Reversed sentence:");
        Console.WriteLine(reversedSentence);
    }
}
