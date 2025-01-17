﻿using System;
using System.Collections.Generic;

public class Program
{
    public static void Swap<T>(List<T> list, int index1, int index2)
    {
        if (index1 >= 0 && index1 < list.Count && index2 >= 0 && index2 < list.Count)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
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

        string[] swapCommand = Console.ReadLine().Split();
        int index1 = int.Parse(swapCommand[0]);
        int index2 = int.Parse(swapCommand[1]);

        Swap(elements, index1, index2);

        foreach (var element in elements)
        {
            string typeName = element.GetType().FullName;
            Console.WriteLine($"{typeName}: {element}");
        }
    }
}
