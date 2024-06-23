class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text with <upcase> tags:");
        string text = Console.ReadLine();

        string startTag = "<upcase>";
        string endTag = "</upcase>";

        while (text.Contains(startTag) && text.Contains(endTag))
        {
            int startIndex = text.IndexOf(startTag);
            int endIndex = text.IndexOf(endTag);

            if (startIndex < endIndex)
            {
                int length = endIndex - startIndex - startTag.Length;
                string uppercase = text.Substring(startIndex + startTag.Length, length).ToUpper();

                text = text.Remove(startIndex, endIndex + endTag.Length - startIndex)
                           .Insert(startIndex, uppercase);
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("Output:");
        Console.WriteLine(text);
    }
}
