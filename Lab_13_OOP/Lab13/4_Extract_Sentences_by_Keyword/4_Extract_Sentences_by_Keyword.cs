class ExtractSentences
{
    static void Main()
    {
        Console.WriteLine("Enter keyword:");
        string keyword = Console.ReadLine().Trim();

        Console.WriteLine("Enter text:");
        string text = Console.ReadLine().Trim();

        List<string> sentencesWithKeyword = ExtractSentencesWithWord(text, keyword);

        Console.WriteLine("Sentences with keyword:");
        foreach (string sentence in sentencesWithKeyword)
        {
            Console.WriteLine(sentence.Trim());
        }
    }

    static List<string> ExtractSentencesWithWord(string text, string keyword)
    {
        string[] sentences = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> sentencesWithKeyword = new List<string>();

        foreach (var sentence in sentences)
        {
            if (ContainsWord(sentence, keyword))
            {
                sentencesWithKeyword.Add(sentence);
            }
        }

        return sentencesWithKeyword;
    }

    static bool ContainsWord(string sentence, string keyword)
    {
        string[] words = sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (word.Equals(keyword))
            {
                return true;
            }
        }

        return false;
    }
}
