class URLParser
{
    static Dictionary<string, string> ParseURL(string url)
    {
        var urlParts = new Dictionary<string, string>
        {
            {"protocol", ""},
            {"server", ""},
            {"resource", ""}
        };

        int protocolEnd = url.IndexOf("://");
        if (protocolEnd != -1)
        {
            urlParts["protocol"] = url.Substring(0, protocolEnd);
            url = url.Substring(protocolEnd + "://".Length);
        }

        int serverEnd = url.IndexOf("/");
        if (serverEnd != -1)
        {
            urlParts["server"] = url.Substring(0, serverEnd);
            urlParts["resource"] = url.Substring(serverEnd + 1);
        }
        else
        {
            urlParts["server"] = url;
        }

        return urlParts;
    }

    static void DisplayURLParts(Dictionary<string, string> urlParts)
    {
        Console.WriteLine("[protocol] = \"" + urlParts["protocol"] + "\"");
        Console.WriteLine("[server] = \"" + urlParts["server"] + "\"");
        Console.WriteLine("[resource] = \"" + urlParts["resource"] + "\"");
    }

    static void Main()
    {
        Console.WriteLine("Enter URL or exit");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
                break;

            var parsedURL = ParseURL(input);
            DisplayURLParts(parsedURL);

            Console.WriteLine("\nEnter URL or exit");
        }
    }
}
