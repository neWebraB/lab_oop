﻿using System;
using System.Collections.Generic;

public class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public T Value => this.value;

    public int CompareTo(T other)
    {
        return this.value.CompareTo(other);
    }
}

public class Program
{
    public static int CountGreaterThan<T>(List<T> list, T valueToCompare) where T : IComparable<T>
    {
        int count = 0;
        foreach (var item in list)
        {
            if (item.CompareTo(valueToCompare) > 0)
            {
                count++;
            }
        }
        return count;
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<double> elements = new List<double>();

        for (int i = 0; i < n; i++)
        {
            double element = double.Parse(Console.ReadLine());
            elements.Add(element);
        }

        double valueToCompare = double.Parse(Console.ReadLine());

        int count = CountGreaterThan(elements, valueToCompare);
        Console.WriteLine(count);
    }
}
