using System;

class RectangularBox
{
    // Параметри коробки
    private double length;
    private double width;
    private double height;

    // Конструктор класу з перевіркою даних
    public RectangularBox(double length, double width, double height)
    {
        ValidateInput(length, width, height);

        this.length = length;
        this.width = width;
        this.height = height;
    }

    private void ValidateInput(double length, double width, double height)
    {
        if (length <= 0 || width <= 0 || height <= 0)
        {
            throw new ArgumentException("Розміри коробки повинні бути додатніми числами.");
        }
    }

    // Метод для обчислення площі поверхні
    public double CalculateSurfaceArea()
    {
        return 2 * (length * width + length * height + width * height);
    }

    // Метод для обчислення площі бічної поверхні
    public double CalculateLateralSurfaceArea()
    {
        return 2 * (length * height + width * height);
    }

    // Метод для обчислення об'єму
    public double CalculateVolume()
    {
        return length * width * height;
    }

    // Метод для виведення результатів
    public void DisplayResults()
    {
        Console.WriteLine("Площа поверхні: " + CalculateSurfaceArea());
        Console.WriteLine("Площа бічної поверхні: " + CalculateLateralSurfaceArea());
        Console.WriteLine("Об'єм: " + CalculateVolume());
    }
    
}

class Program
{
    static void Main()
    {
        // Введення параметрів коробки
        Console.WriteLine("Введіть довжину, ширину та висоту коробки:");

        // Зчитування та перетворення введених даних
        double length = Convert.ToDouble(Console.ReadLine());
        double width = Convert.ToDouble(Console.ReadLine());
        double height = Convert.ToDouble(Console.ReadLine());

        try
        {
            // Створення екземпляра класу RectangularBox з перевіркою даних
            RectangularBox box = new RectangularBox(length, width, height);

            // Виведення результатів
            box.DisplayResults();
        }
        catch (ArgumentException ex)
        {
            // Виведення повідомлення про помилку
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}
