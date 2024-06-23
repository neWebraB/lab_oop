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

        var sortedStudents = students
            .OrderBy(s => s.LastName)
            .ThenByDescending(s => s.FirstName)
            .ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
