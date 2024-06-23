using System.Text.RegularExpressions;

namespace series_of_letterss
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter a string:");
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                    break;

                string result = RemoveConsecutiveIdenticalLetters(input);

                Console.WriteLine(result);
            }
        }

        static string RemoveConsecutiveIdenticalLetters(string input)
        {
            string rejexPattern = @"(.)\1+";
            string replacement = "$1";

            string result = Regex.Replace(input, rejexPattern, replacement);

            return result;
        }
    }
}