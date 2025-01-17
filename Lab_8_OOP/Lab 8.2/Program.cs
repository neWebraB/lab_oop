﻿using System;
using System.Collections.Generic;

public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public override string ToString()
    {
        string typeName = typeof(T).FullName;
        return $"{typeName}: {this.value}";
    }
}

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<string>> boxes = new List<Box<string>>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);
            boxes.Add(box);
        }

        foreach (var box in boxes)
        {
            Console.WriteLine(box.ToString());
        }
    }
}
