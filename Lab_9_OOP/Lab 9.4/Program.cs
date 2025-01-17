﻿using System;
using System.Collections;
using System.Collections.Generic;

class Озеро : IEnumerable<int>
{
    private List<int> камені;

    // Конструктор класу Озеро, приймає масив каменів
    public Озеро(int[] камені)
    {
        // Ініціалізуємо список каменів
        this.камені = new List<int>(камені);
    }

    // Реалізація методу GetEnumerator() інтерфейсу IEnumerable<int>
    public IEnumerator<int> GetEnumerator()
    {
        // Перший прохід - парні позиції в порядку зростання
        for (int i = 0; i < камені.Count; i += 2)
        {
            yield return камені[i]; // Повертаємо значення каменя
        }

        // Другий прохід - непарні позиції в зворотньому порядку
        for (int i = камені.Count % 2 == 0 ? камені.Count - 1 : камені.Count - 2; i >= 0; i -= 2)
        {
            yield return камені[i]; // Повертаємо значення каменя
        }
    }

    // Реалізація необхідного для інтерфейсу IEnumerable методу GetEnumerator()
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть номери каменів через пробіл:");

        // Підказка: Введення даних з консолі та обробка їх для створення масиву каменів
        int[] камені = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Console.WriteLine("\nЗміна порядку стрибків жаби:\n");

        // Використання класу Озеро та циклу foreach для ітерації через всі камені в порядку, описаному в завданні
        Озеро озеро = new Озеро(камені);
        foreach (int камінь in озеро)
        {
            Console.Write(камінь + " ");
        }
    }
}
