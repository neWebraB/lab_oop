using System.Text;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        char[] separators = new[] { ' ', '.', ',', '?', '!', ';' };
        StringBuilder result = new StringBuilder(text.Length);

        bool newWord = true;

        foreach (var c in text)
        {
            if (separators.Contains(c))
            {
                newWord = true;
                result.Append(c);
            }
            else
            {
                if (newWord)
                {
                    result.Append(char.ToUpper(c));
                    newWord = false;
                }
                else
                {
                    result.Append(c);
                }
            }
        }

        Console.WriteLine("Output:");
        Console.WriteLine(result.ToString());
    }
}
