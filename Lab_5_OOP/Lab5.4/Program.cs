using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public decimal Money { get; set; }
    public List<Product> Bag { get; set; } = new List<Product>();
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main()
    {
        try
        {
            // Введення даних про людей
            List<Person> people = new List<Person>();
            Console.WriteLine("Введіть дані про людей. Для завершення введіть 'end'.");
            while (true)
            {
                Console.Write("Ім'я: ");
                string name = Console.ReadLine();

                if (name.ToLower() == "end")
                    break;

                Console.Write("Гроші: ");
                decimal money = Convert.ToDecimal(Console.ReadLine());

                people.Add(new Person { Name = name, Money = money });
            }

            // Введення даних про продукти (тут використовується статичний список продуктів)
            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 800 },
                new Product { Name = "Phone", Price = 400 },
                new Product { Name = "Headphones", Price = 50 }
            };

            // Список команд покупки
            List<Tuple<string, string>> purchaseCommands = new List<Tuple<string, string>>();
            Console.WriteLine("Введіть команди покупки (Phone price=400, Laptop price=800, Headphones price=50). Для завершення введіть 'end'.");
            while (true)
            {
                Console.Write("Ім'я людини: ");
                string personName = Console.ReadLine();

                if (personName.ToLower() == "end")
                    break;

                Console.Write("Назва продукту: ");
                string productName = Console.ReadLine();

                purchaseCommands.Add(new Tuple<string, string>(personName, productName));
            }

            // Виконання команд покупки
            foreach (var command in purchaseCommands)
            {
                var person = people.Find(p => p.Name == command.Item1);
                var product = products.Find(p => p.Name == command.Item2);

                if (person != null && product != null)
                {
                    BuyProduct(person, product);
                }
                else
                {
                    Console.WriteLine("Неправильне ім'я або продукт.");
                }
            }

            // Друк замовлення
            PrintOrder(people);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void BuyProduct(Person person, Product product)
    {
        if (string.IsNullOrWhiteSpace(person.Name))
        {
            throw new Exception("Ім'я не може бути порожнім");
        }

        if (person.Money < product.Price)
        {
            Console.WriteLine($"{person.Name} не можу собі дозволити {product.Name}");
        }
        else
        {
            person.Money -= product.Price;
            person.Bag.Add(product);
        }
    }

    static void PrintOrder(List<Person> people)
    {
        foreach (var person in people)
        {
            Console.Write($"{person.Name}: ");
            if (person.Bag.Count > 0)
            {
                foreach (var product in person.Bag)
                {
                    Console.Write($"{product.Name}, ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Нічого не куплено");
            }
        }
    }
}
