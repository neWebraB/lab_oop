using System.Text.RegularExpressions;

namespace replace_a_tag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "input.html";
            string htmlDocument;

            try
            {
                htmlDocument = File.ReadAllText(filePath);
            }
            catch (IOException ex)
            {
                Console.WriteLine("error while reading: " + ex.Message);
                return;
            }

            string result = ReplaceTagWithURL(htmlDocument);
            Console.WriteLine(result);
        }

        static string ReplaceTagWithURL(string html)
        {
            string rejexPattern = "<a\\s+href=\"(.*?)\">(.*?)</a>";
            string replacement = "[URL href=\"$1\"]$2[/URL]";
            string result = Regex.Replace(html, rejexPattern, replacement);

            return result;
        }
    }
}