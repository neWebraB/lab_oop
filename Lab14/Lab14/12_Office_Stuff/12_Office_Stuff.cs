public class CompanyOrder
{
    public string CompanyName { get; set; }
    public int Amount { get; set; }
    public string Product { get; set; }

    public CompanyOrder(string companyName, int amount, string product)
    {
        CompanyName = companyName;
        Amount = amount;
        Product = product;
    }
}

class OfficeStuff
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var orders = new List<CompanyOrder>();

        for (int i = 0; i < n; i++)
        {
            string orderInput = Console.ReadLine();
            string[] orderParts = orderInput.Split(new[] { " - " }, StringSplitOptions.None);

            string company = orderParts[0].Trim('|', ' ');
            int amount = int.Parse(orderParts[1]);
            string product = orderParts[2].Trim('|', ' ');

            orders.Add(new CompanyOrder(company, amount, product));
        }

        var groupedOrders = orders
            .GroupBy(o => o.CompanyName)
            .OrderBy(g => g.Key)
            .ToDictionary(
                g => g.Key,
                g => g.GroupBy(o => o.Product)
                      .ToDictionary(pg => pg.Key, pg => pg.Sum(o => o.Amount))
            );

        foreach (var company in groupedOrders)
        {
            Console.WriteLine(" ");
            Console.Write($"{company.Key}: ");
            Console.WriteLine(string.Join(", ", company.Value.Select(p => $"{p.Key}-{p.Value}")));
        }
    }
}
