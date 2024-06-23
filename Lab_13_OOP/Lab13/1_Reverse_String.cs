public class ReverseString
{
    public static void Main()
    {
        Console.WriteLine("Enter string:");
        string input = Console.ReadLine();

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);

        Console.WriteLine("Reversed string:");
        Console.WriteLine(reversed);
    }
}
