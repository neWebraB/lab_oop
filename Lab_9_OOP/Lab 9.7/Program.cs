﻿using System;
using System.Collections.Generic;

public class Person : IEquatable<Person>, IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }

    public bool Equals(Person other)
    {
        if (ReferenceEquals(other, null))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Name == other.Name && Age == other.Age;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Age.GetHashCode();
    }

    public int CompareTo(Person other)
    {
        // Спробуйте спочатку порівняти за іменем, а якщо імена однакові, то за віком.
        int nameComparison = String.Compare(Name, other.Name, StringComparison.Ordinal);
        return nameComparison == 0 ? Age.CompareTo(other.Age) : nameComparison;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of people (N):");
        int N = int.Parse(Console.ReadLine());

        SortedSet<Person> sortedSet = new SortedSet<Person>();

        Console.WriteLine("Enter information about people in the format '<name> <age>':");

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person person = new Person(name, age);

            sortedSet.Add(person);
        }

        Console.WriteLine("\nSize of the SortedSet: " + sortedSet.Count);
    }
}
