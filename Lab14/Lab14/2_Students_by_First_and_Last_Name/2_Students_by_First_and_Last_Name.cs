public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
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
                LastName = data[1]
            });
        }

        var studentsWithFirstBeforeLast = students
            .Where(s => string.Compare(s.FirstName, s.LastName) < 0)
            .ToList();

        foreach (var student in studentsWithFirstBeforeLast)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
