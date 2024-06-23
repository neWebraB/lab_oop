public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Group { get; set; }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var data = input.Split(' ');
            students.Add(new Student
            {
                FirstName = data[0],
                LastName = data[1],
                Group = int.Parse(data[2])
            });
        }

        var studentsInGroup2 = students
            .Where(s => s.Group == 2)
            .OrderBy(s => s.FirstName)
            .ToList();

        foreach (var student in studentsInGroup2)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
