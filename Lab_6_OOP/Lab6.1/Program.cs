using System;

public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Довжина імені не повинна бути менше 3 символів!");
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Вік має бути позитивним!");
            age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    

    public override string ToString()
    {
        return $"Ім'я: {Name}, Вік: {Age}";
    }
}

public class Child : Person
{
    public Child(string name, int age) : base(name, age)
    {
        if (age > 15)
            throw new ArgumentException("Вік дитини має бути менше 15!");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введіть дані для особи:");

            Console.Write("Ім'я: ");
            string name = Console.ReadLine();

            Console.Write("Вік: ");
            int age = int.Parse(Console.ReadLine());

            Person person = new Person(name, age);
            Console.WriteLine("Дані особи:");
            Console.WriteLine(person);

            Console.WriteLine("\nВведіть дані для дитини:");

            Console.Write("Ім'я дитини: ");
            name = Console.ReadLine();

            Console.Write("Вік дитини: ");
            age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine("Дані дитини:");
            Console.WriteLine(child);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
