public class FitStringIn20Chars
{
    public static void Main()
    {
        string input = Console.ReadLine();

        string resultString;

        if (input.Length > 20)
        {
            resultString = input.Substring(0, 20);
        }
        else
        {
            resultString = input.PadRight(20, '*');
        }

        Console.WriteLine(resultString);
    }
}
