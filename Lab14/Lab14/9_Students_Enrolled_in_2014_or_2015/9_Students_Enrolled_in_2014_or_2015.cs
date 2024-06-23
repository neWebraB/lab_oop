public class Student
{
    public string FacultyNumber { get; set; }
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
                FacultyNumber = parts[0]
            };

            student.Marks.AddRange(parts.Skip(1).Select(int.Parse));

            students.Add(student);
        }

        var students2014or2015 = students
            .Where(s => s.FacultyNumber.EndsWith("14") || s.FacultyNumber.EndsWith("15"))
            .Select(s => s.Marks);

        foreach (var marks in students2014or2015)
        {
            Console.WriteLine(string.Join(" ", marks));
        }
    }
}
