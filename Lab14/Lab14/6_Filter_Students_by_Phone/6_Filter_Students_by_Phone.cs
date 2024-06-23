public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
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
                Phone = data[2]
            });
        }

        var studentsWithSofiaPhone = students
            .Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"))
            .ToList();

        foreach (var student in studentsWithSofiaPhone)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}
