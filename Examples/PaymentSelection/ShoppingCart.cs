using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.PaymentSelection
{
    public record CartItem(string Name, double Price);

    public class ShoppingCart
    {
        private IPaymentStrategy? _paymentStrategy;
        private readonly List<CartItem> _items = [];

        public void SetPaymentStrategy(IPaymentStrategy paymentMethod)
        {
            _paymentStrategy = paymentMethod;
        }

        public void AddItem(string name, double price)
        {
            _items.Add(new CartItem(name, price));
        }

        public double CalculateTotal()
        {
            return _items.Sum(item => item.Price);
        }

        public PaymentResult Checkout()
        {
            var amount = CalculateTotal();
            if (_paymentStrategy == null)
                throw new InvalidOperationException("Payment strategy not set");
            var result = _paymentStrategy.ProcessPayment(amount);
            _items.Clear();
            return result;
        }
    }
}
