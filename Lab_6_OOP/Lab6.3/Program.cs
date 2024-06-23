using System;

class Human
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

class Student : Human
{
    public string FacultyNumber { get; set; }

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public void PrintInfo()
    {
        Console.WriteLine("Інформація про студента:");
        Console.WriteLine($"Ім'я: {FirstName}");
        Console.WriteLine($"Прізвище: {LastName}");
        Console.WriteLine($"Номер факультету: {FacultyNumber}");
    }
}

class Worker : Human
{
    public decimal WeeklySalary { get; set; }
    public int HoursPerDay { get; set; }

    public Worker(string firstName, string lastName, decimal weeklySalary, int hoursPerDay)
        : base(firstName, lastName)
    {
        WeeklySalary = weeklySalary;
        HoursPerDay = hoursPerDay;
    }

    public decimal CalculateHourlySalary()
    {
        return WeeklySalary / (5 * HoursPerDay); // 5 робочих днів на тиждень
    }

    public void PrintInfo()
    {
        Console.WriteLine("Інформація про працівника:");
        Console.WriteLine($"Ім'я: {FirstName}");
        Console.WriteLine($"Прізвище: {LastName}");
        Console.WriteLine($"Зарплата за тиждень: {WeeklySalary:F2}");
        Console.WriteLine($"Кількість годин на день: {HoursPerDay}");
        Console.WriteLine($"Заробітна плата за годину: {CalculateHourlySalary():F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть ім'я та номер факультету студента (розділіть пробілом):");
        string studentInfo = Console.ReadLine();
        string[] studentData = studentInfo.Split(' ');

        Console.WriteLine("Введіть ім'я, прізвище, зарплату та кількість годин на день працівника (розділіть пробілом):");
        string workerInfo = Console.ReadLine();
        string[] workerData = workerInfo.Split(' ');

        string studentFirstName = studentData[0];
        string studentLastName = studentData[1];
        string facultyNumber = studentData[2];

        string workerFirstName = workerData[0];
        string workerLastName = workerData[1];
        decimal weeklySalary = decimal.Parse(workerData[2]);
        int hoursPerDay = int.Parse(workerData[3]);

        Student student = new Student(studentFirstName, studentLastName, facultyNumber);
        Worker worker = new Worker(workerFirstName, workerLastName, weeklySalary, hoursPerDay);

        Console.WriteLine();
        student.PrintInfo();
        Console.WriteLine();
        worker.PrintInfo();
    }
}
