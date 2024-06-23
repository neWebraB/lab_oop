class Program
{
    static void Main()
    {
        var phonebook = new Dictionary<string, string>();
        var outputs = new List<string>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var parts = inputLine.Split(' ');
            var command = parts[0];

            switch (command)
            {
                case "A":
                    phonebook[parts[1]] = parts[2];
                    break;
                case "S":
                    var name = parts[1];
                    if (phonebook.TryGetValue(name, out var number))
                    {
                        outputs.Add($"{name} -> {number}");
                    }
                    else
                    {
                        outputs.Add($"Contact {name} does not exist.");
                    }
                    break;
                case "ListAll":
                    var sortedContacts = phonebook.OrderBy(c => c.Key).ToList();
                    sortedContacts.ForEach(c => outputs.Add($"{c.Key} -> {c.Value}"));
                    break;
            }
        }

        foreach (var output in outputs)
        {
            Console.WriteLine(output);
        }
    }
}