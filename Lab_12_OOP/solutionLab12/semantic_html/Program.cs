using System.Text.RegularExpressions;
using System.Text;

namespace semantic_html
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tagMapping = new Dictionary<string, string>
            {
                { "header", "header" },
                { "nav", "nav" },
                { "main", "main" },
                { "article", "article" },
                { "section", "section" },
                { "aside", "aside" },
                { "footer", "footer" }
            };

            var inputLines = new List<string>();

            string line;
            while ((line = Console.ReadLine()).ToLower() != "end")
            {
                inputLines.Add(line);
            }

            var output = new StringBuilder();
            foreach (string inputLine in inputLines)
            {
                string outputLine = inputLine;

                foreach (var kvp in tagMapping)
                {
                    outputLine = Regex.Replace(outputLine, $"<div\\s+(id|class)=\"{kvp.Key}\"", $"<{kvp.Value}");
                    outputLine = Regex.Replace(outputLine, $"</div>\\s+<!--\\s+{kvp.Key}\\s+-->", $"</{kvp.Value}>");

                    outputLine = Regex.Replace(outputLine, " +", " ");
                }

                output.AppendLine(outputLine);
            }

            Console.WriteLine(output.ToString());
        }
    }
}