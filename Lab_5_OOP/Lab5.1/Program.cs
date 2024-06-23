using System;

class RectangularBox
{
    // Параметри коробки
    private double length;
    private double width;
    private double height;

    // Конструктор класу
    public RectangularBox(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
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
        double length = Convert.ToDouble(Console.ReadLine());
        double width = Convert.ToDouble(Console.ReadLine());
        double height = Convert.ToDouble(Console.ReadLine());

        // Створення екземпляра класу RectangularBox
        RectangularBox box = new RectangularBox(length, width, height);

        // Виведення результатів
        box.DisplayResults();
    }
}
