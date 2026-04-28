using NUnit.Framework;
using ECommerceApp.Core;

namespace ECommerceApp.Tests;

[TestFixture]
public class UnitTests
{
    private Product _p;
    private Cart _c;
    private OrderService _s;

    [SetUp]
    public void Setup()
    {
        _p = new Product { Id = 1, Name = "Klavye", Price = 150m, Stock = 10 };
        _c = new Cart();
        _s = new OrderService();
    }

    [Test] public void T1_WhiteBox_StockDecrease() { _p.DecreaseStock(2); Assert.That(_p.Stock, Is.EqualTo(8)); }
    [Test] public void T2_WhiteBox_RemoveFromCart() { _c.AddProduct(_p); _c.RemoveProduct(_p); Assert.IsEmpty(_c.Items); }

    [Test] // FAIL BEKLENÝYOR (Kargo Bugý)
    public void T3_WhiteBox_ShippingFee_Logic()
    {
        _c.AddProduct(new Product { Price = 50m });
        Assert.That(_c.CalculateTotal(), Is.EqualTo(75m));
    }

    [Test] public void T4_BlackBox_AddToCart() { _c.AddProduct(_p); Assert.That(_c.Items.Count, Is.EqualTo(1)); }

    [Test] // FAIL BEKLENÝYOR (Ödeme Bugý)
    public void T5_BlackBox_ExactPayment_Check()
    {
        _c.AddProduct(_p);
        decimal total = _c.CalculateTotal();
        Assert.DoesNotThrow(() => _s.PlaceOrder(_c, total));
    }

    [Test] public void T6_BlackBox_NameValidation() { Assert.That(_p.Name, Is.Not.Null); }
    [Test] public void T7_GrayBox_StatusUpdate() { _c.AddProduct(_p); _s.PlaceOrder(_c, 500m); Assert.That(_c.Status, Is.EqualTo("Completed")); }
    [Test] public void T8_GrayBox_ZeroStockBoundary() { _p.Stock = 1; _p.DecreaseStock(1); Assert.That(_p.Stock, Is.EqualTo(0)); }
    [Test] public void T9_GrayBox_DiscountApply() { _c.AddProduct(new Product { Price = 200m }); Assert.That(_c.CalculateTotal(), Is.EqualTo(155m)); }
}