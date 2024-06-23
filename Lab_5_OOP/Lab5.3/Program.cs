using System;

class Chicken
{
    private string name;
    private int age;

    // Конструктор класу Chicken
    public Chicken(string name, int age)
    {
        SetName(name);
        SetAge(age);
    }

    // Метод для отримання імені курки
    public string GetName()
    {
        return name;
    }

    // Метод для отримання віку курки
    public int GetAge()
    {
        return age;
    }

    // Приватний метод для встановлення імені курки
    private void SetName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Ім'я не може бути пустим.");
        }
        this.name = value; // Доступ до приватного поля напряму
    }

    // Приватний метод для встановлення віку курки
    private void SetAge(int value)
    {
        if (value < 0 || value > 15)
        {
            throw new ArgumentOutOfRangeException("Вік має бути від 0 до 15");
        }
        this.age = value; // Доступ до приватного поля напряму
    }

}

class Program
{
    static void Main()
    {
        try
        {
            // Введення ім'я курки через консоль
            Console.Write("Введіть ім'я курки: ");
            string name = Console.ReadLine();

            // Введення віку курки через консоль
            Console.Write("Введіть вік курки: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                // Створення об'єкта класу Chicken на основі введених даних
                Chicken chicken = new Chicken(name, age);
                Console.WriteLine($"Ім'я: {chicken.GetName()}, Вік: {chicken.GetAge()}");
            }
            else
            {
                Console.WriteLine("Некоректний вік. Будь ласка, введіть коректне ціле число.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (Exception ex) when (ex is ArgumentOutOfRangeException || ex is ArgumentException)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
