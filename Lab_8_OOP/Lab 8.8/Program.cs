﻿using System;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> where T : IComparable<T>
{
    private List<T> elements;

    public CustomList()
    {
        this.elements = new List<T>();
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove(int index)
    {
        T removedElement = this.elements[index];
        this.elements.RemoveAt(index);
        return removedElement;
    }

    public bool Contains(T element)
    {
        return this.elements.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.elements[index1];
        this.elements[index1] = this.elements[index2];
        this.elements[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (T item in this.elements)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }

    public T Max()
    {
        return this.elements.Count > 0 ? this.elements.Max() : default(T);
    }

    public T Min()
    {
        return this.elements.Count > 0 ? this.elements.Min() : default(T);
    }

    public void Print()
    {
        foreach (T element in this.elements)
        {
            Console.WriteLine(element);
        }
    }
}

public class Program
{
    public static void Main()
    {
        CustomList<string> customList = new CustomList<string>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] command = input.Split();
            string action = command[0];

            switch (action)
            {
                case "Add":
                    string elementToAdd = command[1];
                    customList.Add(elementToAdd);
                    break;

                case "Remove":
                    int indexToRemove = int.Parse(command[1]);
                    customList.Remove(indexToRemove);
                    break;

                case "Contains":
                    string elementToCheck = command[1];
                    bool contains = customList.Contains(elementToCheck);
                    Console.WriteLine(contains);
                    break;

                case "Swap":
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);
                    customList.Swap(index1, index2);
                    break;

                case "Greater":
                    string elementToCompare = command[1];
                    int countGreaterThan = customList.CountGreaterThan(elementToCompare);
                    Console.WriteLine(countGreaterThan);
                    break;

                case "Max":
                    Console.WriteLine(customList.Max());
                    break;

                case "Min":
                    Console.WriteLine(customList.Min());
                    break;

                case "Print":
                    customList.Print();
                    break;
            }
        }
    }
}
