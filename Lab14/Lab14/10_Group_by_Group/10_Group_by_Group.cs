public class Person
{
    public string Name { get; set; }
    public int Group { get; set; }

    public Person(string name, int group)
    {
        Name = name;
        Group = group;
    }
}

class Program
{
    static void Main()
    {
        var people = new List<Person>();
        string inputLine;

        while ((inputLine = Console.ReadLine()) != "END")
        {
            var parts = inputLine.Split(' ');
            var name = string.Join(" ", parts.Take(parts.Length - 1));
            var group = int.Parse(parts.Last());

            people.Add(new Person(name, group));
        }

        var groupedPeople = people
            .GroupBy(p => p.Group)
            .OrderBy(g => g.Key); 

        foreach (var group in groupedPeople)
        {
            var names = group.Select(p => p.Name);
            Console.WriteLine($"{group.Key} - {string.Join(", ", names)}");
        }
    }
}
