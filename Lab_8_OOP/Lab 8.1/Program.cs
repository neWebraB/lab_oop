﻿using System;

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
        string input = Console.ReadLine();
        if (int.TryParse(input, out int intValue))
        {
            Box<int> intBox = new Box<int>(intValue);
            Console.WriteLine(intBox.ToString());
        }
        else
        {
            Box<string> stringBox = new Box<string>(input);
            Console.WriteLine(stringBox.ToString());
        }
    }
}