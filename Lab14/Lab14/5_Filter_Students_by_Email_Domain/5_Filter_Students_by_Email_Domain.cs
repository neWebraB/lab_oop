public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
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
                Email = data[2]
            });
        }

        var studentsWithGmail = students
            .Where(s => s.Email.EndsWith("@gmail.com"))
            .ToList();

        foreach (var student in studentsWithGmail)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
