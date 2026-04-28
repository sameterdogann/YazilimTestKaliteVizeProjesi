using NUnit.Framework;
using ECommerceApp.Core;

namespace ECommerceApp.Tests;

[TestFixture]
public class IntegrationTests
{
    [Test]
    public void T10_Integration_FullFlow()
    {
        var cart = new Cart();
        var product = new Product { Price = 50m, Stock = 5 };
        cart.AddProduct(product);
        var service = new OrderService();
        var result = service.PlaceOrder(cart, 200m);
        Assert.That(result.IsSuccessful, Is.True);
    }

    [Test] // FAIL BEKLENÝYOR (Kargo hatasý katlanýyor)
    public void T11_Integration_Total_Validation()
    {
        var cart = new Cart();
        cart.AddProduct(new Product { Price = 50m });
        cart.AddProduct(new Product { Price = 50m });
        Assert.That(cart.CalculateTotal(), Is.EqualTo(125m));
    }

    [Test]
    public void T12_Integration_EmptyCart_State()
    {
        var cart = new Cart();
        Assert.That(cart.Items.Count, Is.EqualTo(0));
    }
}