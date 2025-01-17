﻿using System;

public class Tuple<T1, T2>
{
    public T1 Item1 { get; set; }
    public T2 Item2 { get; set; }

    public Tuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}

public class Program
{
    public static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        string fullName = $"{input1[0]} {input1[1]}";
        string address = input1[2];

        string[] input2 = Console.ReadLine().Split();
        string name = input2[0];
        int litersOfBeer = int.Parse(input2[1]);

        string[] input3 = Console.ReadLine().Split();
        int integer = int.Parse(input3[0]);
        double doubleValue = double.Parse(input3[1]);

        Tuple<string, string> personInfo = new Tuple<string, string>(fullName, address);
        Tuple<string, int> drinkInfo = new Tuple<string, int>(name, litersOfBeer);
        Tuple<int, double> numbersInfo = new Tuple<int, double>(integer, doubleValue);

        Console.WriteLine(personInfo);
        Console.WriteLine(drinkInfo);
        Console.WriteLine(numbersInfo);
    }
}