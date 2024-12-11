namespace Practice;


public interface IItem
{
    string Name { get; set; }
    decimal  Price { get; set; }
}

public class Item : IItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class PerishableItem  : IItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpiryDate { get; set; }
}

public class NonPerishableItem  : IItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}


public static class ItemExtensions
{
    public static void ApplyDiscount(this IItem item, decimal discount)
    {
        item.Price *= discount;
    }
}