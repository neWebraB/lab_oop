using System;

public class Book
{
    private string title;
    private string author;
    private double price;

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new Exception("Заголовок недійсний!");
            }
            title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            if (Char.IsDigit(value[0]))
            {
                throw new Exception("Автор недійсний!");
            }
            author = value;
        }
    }

    public virtual double Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Ціна недійсна!");
            }
            price = value;
        }
    }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public override string ToString()
    {
        return $"Назва: {Title}, Автор: {Author}, Ціна: {Price:F2}";
    }
}

public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string title, string author, double price) : base(title, author, price)
    {
    }

    public override double Price
    {
        get
        {
            return base.Price * 1.3; // Золоте видання коштує на 30% більше
        }
    }
}
