using System;

namespace ECommerceApp.Core;

public class OrderService
{
    public class Order { public bool IsSuccessful { get; set; } }

    public Order PlaceOrder(Cart cart, decimal paymentAmount)
    {
        decimal total = cart.CalculateTotal();

        // BUG: Tutar tam eþitse (payment == total) hata veriyor.
        // Sadece ödeme büyükse kabul ediyor.
        if (paymentAmount > total)
        {
            foreach (var item in cart.Items) item.DecreaseStock(1);
            cart.Status = "Completed";
            return new Order { IsSuccessful = true };
        }
        throw new ArgumentException("Ödeme reddedildi!");
    }
}