﻿using System;
using System.Collections.Generic;

class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }

    public int CompareTo(Person other)
    {
        int nameComparison = String.Compare(this.Name, other.Name, StringComparison.Ordinal);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        int ageComparison = this.Age.CompareTo(other.Age);
        if (ageComparison != 0)
        {
            return ageComparison;
        }

        return String.Compare(this.City, other.City, StringComparison.Ordinal);
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();

            // Перевіряємо, чи вдалося успішно зчитати ім'я, вік та місто
            if (tokens.Length != 3 || !int.TryParse(tokens[1], out int age))
            {
                Console.WriteLine("Некоректний формат введення. Спробуйте ще раз.");
                continue;
            }

            string name = tokens[0];
            string city = tokens[2];

            people.Add(new Person { Name = name, Age = age, City = city });
        }

        people.Sort();

        int equalCount = 0;
        int notEqualCount = 0;

        for (int i = 1; i < people.Count; i++)
        {
            if (people[i - 1].CompareTo(people[i]) == 0)
            {
                equalCount++;
            }
            else
            {
                notEqualCount++;
            }
        }

        if (equalCount == 0)
        {
            Console.WriteLine("Немає збігів");
        }
        else
        {
            Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
        }
    }
}
