using System.Text.RegularExpressions;

namespace sentence_extractor
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("enter a keyword");
            string keyword = Console.ReadLine().ToLower();

            Console.WriteLine("enter text");
            string text = Console.ReadLine();

            string[] sentences = text.Split(new char[] { '.', '!', '?' });

            Console.WriteLine("result: ");
            foreach (string sentence in sentences)
            {
                if (ContainsKeyword(sentence, keyword))
                {
                    Console.WriteLine(sentence.Trim() + ".");
                }
            }
        }

        static bool ContainsKeyword(string sentence, string keyword)
        {
            string pattern = @"\b" + Regex.Escape(keyword) + @"\b";
            return Regex.IsMatch(sentence, pattern, RegexOptions.IgnoreCase);
        }
    }
}