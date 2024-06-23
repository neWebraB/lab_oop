public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Marks { get; set; }

    public Student()
    {
        Marks = new List<int>();
    }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>();
        string inputLine;

        while ((inputLine = Console.ReadLine()) != "END")
        {
            var parts = inputLine.Split(' ');
            var student = new Student
            {
                FirstName = parts[0],
                LastName = parts[1]
            };

            for (int i = 2; i < parts.Length; i++)
            {
                student.Marks.Add(int.Parse(parts[i]));
            }

            students.Add(student);
        }

        var weakStudents = students
            .Where(s => s.Marks.Count(m => m <= 3) >= 2)
            .ToList();

        foreach (var student in weakStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
