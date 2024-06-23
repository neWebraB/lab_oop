using System.Text.RegularExpressions;

namespace match_full_name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter name");
                string name = Console.ReadLine();

                if (IsValidName(name))
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine("not match");
            }
        }
        public static bool IsValidName(string name)
        {
            string regexString = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            Regex reg = new Regex(regexString);

            if (reg.IsMatch(name))
                return true;
            else
                return false;

        }
    }

}