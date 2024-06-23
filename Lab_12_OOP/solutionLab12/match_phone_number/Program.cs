using System.Text.RegularExpressions;

namespace match_phone_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter number");
                string number = Console.ReadLine();
                if (number.ToLower() == "end")
                    break;

                if (IsValidNumber(number))
                    Console.WriteLine(number);
                else
                    Console.WriteLine("not match");
            }
        }

        public static bool IsValidNumber(string number)
        {
            string regexPattern = @"\+?\b359[ -]2[ -]\d{3}[ -]\d{4}\b";


            Regex reg = new Regex(regexPattern);

            if (reg.IsMatch(number))
                return true;
            else
                return false;
        }
    }
}