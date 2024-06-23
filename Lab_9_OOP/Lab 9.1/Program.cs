using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private List<T> collection;
    private int currentIndex;

    // Конструктор класу, який отримує колекцію
    public ListyIterator(List<T> collection)
    {
        this.collection = new List<T>(collection);
        this.currentIndex = 0;
    }

    // Метод для переміщення до наступного індексу в колекції
    public bool Move()
    {
        if (HasNext())
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    // Метод для перевірки наявності наступного індексу
    public bool HasNext()
    {
        return currentIndex < collection.Count - 1;
    }

    // Метод для друку поточного елемента
    public void Print()
    {
        if (collection.Count == 0)
        {
            throw new InvalidOperationException("Неприпустима операція! Колекція порожня.");
        }

        Console.WriteLine(collection[currentIndex]);
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання класу ListyIterator
        ListyIterator<string> listyIterator = null;

        Console.WriteLine("Введіть команду Create та елементи колекції через пробіл:");

        string[] input = Console.ReadLine().Split();
        if (input[0] == "Create")
        {
            // Створення класу ListyIterator з переданою колекцією
            List<string> elements = new List<string>(input[1..]);
            listyIterator = new ListyIterator<string>(elements);
            Console.WriteLine("ListyIterator успішно створено.");
        }

        // Обробка команд введених з консолі
        while (true)
        {
            Console.WriteLine("Введіть команду (Move, HasNext, Print або END):");

            input = Console.ReadLine().Split();
            string command = input[0];

            if (command == "END")
            {
                Console.WriteLine("Програма завершена.");
                break;
            }

            try
            {
                // Виклик відповідних методів класу ListyIterator згідно з командою
                switch (command)
                {
                    case "Move":
                        Console.WriteLine("Move: " + listyIterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine("HasNext: " + listyIterator.HasNext());
                        break;

                    case "Print":
                        Console.Write("Print: ");
                        listyIterator.Print();
                        break;

                    default:
                        Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                // Обробка винятку, якщо відбувається неприпустима операція
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
