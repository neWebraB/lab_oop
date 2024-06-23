public class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }

    public StudentSpecialty(string specialtyName, string facultyNumber)
    {
        SpecialtyName = specialtyName;
        FacultyNumber = facultyNumber;
    }
}

public class Student
{
    public string Name { get; set; }
    public string FacultyNumber { get; set; }

    public Student(string name, string facultyNumber)
    {
        Name = name;
        FacultyNumber = facultyNumber;
    }
}

class Program
{
    static void Main()
    {
        var specialties = new List<StudentSpecialty>();
        var students = new List<Student>();
        string inputLine;

        while ((inputLine = Console.ReadLine()) != "Students:")
        {
            var parts = inputLine.Split(' ');
            var specialtyName = string.Join(" ", parts.Take(parts.Length - 1));
            var facultyNumber = parts.Last();

            specialties.Add(new StudentSpecialty(specialtyName, facultyNumber));
        }

        while ((inputLine = Console.ReadLine()) != "END")
        {
            var parts = inputLine.Split(' ');
            var facultyNumber = parts[0];
            var studentName = string.Join(" ", parts.Skip(1));

            students.Add(new Student(studentName, facultyNumber));
        }

        var joinedData = from student in students
                         join specialty in specialties on student.FacultyNumber equals specialty.FacultyNumber
                         orderby student.Name
                         select new
                         {
                             Name = student.Name,
                             FacultyNumber = student.FacultyNumber,
                             SpecialtyName = specialty.SpecialtyName
                         };

        foreach (var item in joinedData)
        {
            Console.WriteLine($"{item.Name} {item.FacultyNumber} {item.SpecialtyName}");
        }
    }
}
