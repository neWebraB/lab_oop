public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
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
                Age = int.Parse(data[2])
            });
        }

        var studentsWithinAgeRange = students
            .Where(s => s.Age >= 18 && s.Age <= 24)
            .ToList();

        foreach (var student in studentsWithinAgeRange)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
        }
    }
}
