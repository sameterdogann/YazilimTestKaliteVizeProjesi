using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Core;

public class Cart
{
    public List<Product> Items { get; set; } = new();
    public string Status { get; set; } = "Active";

    public void AddProduct(Product product) => Items.Add(product);
    public void RemoveProduct(Product product) => Items.Remove(product);

    public decimal CalculateTotal()
    {
        decimal total = Items.Sum(x => x.Price);

        // 100 TL üzerine %10 indirim
        if (total > 100) total *= 0.9m;

        // BUG: Kargo (+25) eklenmek yerine (-25) çýkarýlýyor.
        return total - 25.0m;
    }
}