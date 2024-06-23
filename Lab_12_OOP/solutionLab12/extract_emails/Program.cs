using System.Text.RegularExpressions;

namespace extract_emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter text");

            string text = Console.ReadLine();

            string regexPattern = @"\b[A-Za-z0-9._-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
            Regex regex = new Regex(regexPattern);

            foreach(Match match in regex.Matches(text))
            {
                Console.WriteLine(match);
            }
        }
    }
}