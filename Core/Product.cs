namespace ECommerceApp.Core;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public void DecreaseStock(int amount)
    {
        if (amount > Stock)
            throw new InvalidOperationException("Stok yetersiz!");
        Stock -= amount;
    }
}