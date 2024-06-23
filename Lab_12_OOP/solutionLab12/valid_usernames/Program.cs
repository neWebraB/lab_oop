using System.Text.RegularExpressions;

namespace valid_usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "(abc_12 /def_gh) hij*kl_mn 3op qr /stu/vw_xyz";
            char[] separators = new char[] { ' ', '/', '\\', '(', ')' };

            string[] usernames = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"\b^[A-Za-z]\w{2,24}\b";
            Regex regex = new Regex(pattern);

            List<string> validUsernames = new List<string>();
            foreach (string username in usernames)
            {
                string trimmedUsername = username.Trim();
                if (regex.IsMatch(trimmedUsername))
                {
                    validUsernames.Add(trimmedUsername);
                }
            }

            int maxSum = 0;
            string firstMax = "";
            string secondMax = "";

            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                int sum = validUsernames[i].Length + validUsernames[i + 1].Length;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    firstMax = validUsernames[i];
                    secondMax = validUsernames[i + 1];
                }
            }

            Console.WriteLine(firstMax);
            Console.WriteLine(secondMax);
        }
    }
}