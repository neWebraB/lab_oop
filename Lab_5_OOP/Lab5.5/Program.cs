using System;
using System.Collections.Generic;

class Dough
{
    private string flourType;
    private string bakingTechnique;
    private int weight;

    private static Dictionary<string, double> flourModifiers = new Dictionary<string, double>
    {
        {"білий", 1.5},
        {"Цільнозернові", 1.0},
        {"Хрустка", 0.9},
        {"Жувальний", 1.1},
        {"Домашнє", 1.0}
    };

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get { return flourType; }
        set
        {
            if (!flourModifiers.ContainsKey(value))
            {
                throw new ArgumentException("Неправильний тип тіста");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            if (!flourModifiers.ContainsKey(value))
            {
                throw new ArgumentException("Неправильна техніка випічки");
            }
            bakingTechnique = value;
        }
    }

    public int Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Вага тіста має бути в межах [1..200].");
            }
            weight = value;
        }
    }

    public double CalculateCalories()
    {
        double baseCalories = 2 * Weight;
        double modifier = flourModifiers[FlourType] * flourModifiers[BakingTechnique];
        return baseCalories * modifier;
    }
}

class Topping
{
    private string type;
    private int weight;

    private static Dictionary<string, double> toppingModifiers = new Dictionary<string, double>
    {
        {"М'ясо", 1.2},
        {"Овочі", 0.8},
        {"Сир", 1.1},
        {"Соус", 0.9}
    };

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get { return type; }
        set
        {
            if (!toppingModifiers.ContainsKey(value))
            {
                throw new ArgumentException($"Неможливо помістити {value} на вашу піцу.");
            }
            type = value;
        }
    }

    public int Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} вага має бути в межах [1..50].");
            }
            weight = value;
        }
    }

    public double CalculateCalories()
    {
        double baseCalories = 2 * Weight;
        double modifier = toppingModifiers[Type];
        return baseCalories * modifier;
    }
}

class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Назва піци має бути від 1 до 15 символів");
            }
            name = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count < 10)
        {
            toppings.Add(topping);
        }
        else
        {
            throw new ArgumentException("Кількість доповнень має бути в межах [0..10].");
        }
    }

    public double CalculateTotalCalories()
    {
        double totalCalories = dough.CalculateCalories();
        foreach (var topping in toppings)
        {
            totalCalories += topping.CalculateCalories();
        }
        return totalCalories;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть інформацію про піцу (назва, тісто, начинка):");
        Console.Write("Назва піци: ");
        string pizzaName = Console.ReadLine();
        if (string.IsNullOrEmpty(pizzaName))
        {
            Console.WriteLine("Помилка: Назва піци не може бути порожнім рядком.");
            return;
        }

        Console.WriteLine("Тісто (тип борошна, техніка випічки, вага):");
        Console.Write("Тип борошна (білий, Цільнозернові): ");
        string flourType = Console.ReadLine();
        Console.Write("Техніка випічки (Хрустка, Жувальний, Домашнє): ");
        string bakingTechnique = Console.ReadLine();
        Console.Write("Вага тіста (1-200 г): ");
        int doughWeight = int.Parse(Console.ReadLine());

        try
        {
            Dough pizzaDough = new Dough(flourType, bakingTechnique, doughWeight);
            Pizza pizza = new Pizza(pizzaName, pizzaDough);

            Console.WriteLine("Додайте начинку (назва, вага):");
            while (true)
            {
                Console.Write("Назва начинки (М'ясо, Овочі, Сир, Соус) або 'КІНЕЦЬ': ");
                string toppingInfo = Console.ReadLine();
                if (toppingInfo.ToUpper() == "КІНЕЦЬ")
                {
                    break;
                }

                string[] toppingData = toppingInfo.Split(' ');
                string toppingType = toppingData[0];
                int toppingWeight = int.Parse(toppingData[1]);

                try
                {
                    Topping pizzaTopping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(pizzaTopping);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }

            double totalCalories = pizza.CalculateTotalCalories();
            Console.WriteLine($"Піца: {pizza.Name}, Загальні калорії: {totalCalories:F2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
