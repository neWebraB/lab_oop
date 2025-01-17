﻿using System;
using System.Collections.Generic;

public class Program
{
    public static int CountGreaterThan(List<string> list, string valueToCompare)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (item.Length >= valueToCompare.Length)
            {
                count++;
            }
        }
        return count;
    }
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<string> elements = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string element = Console.ReadLine();
            elements.Add(element);
        }

        string valueToCompare = Console.ReadLine();

        int count = CountGreaterThan(elements, valueToCompare);
        Console.WriteLine(count);
    }
}