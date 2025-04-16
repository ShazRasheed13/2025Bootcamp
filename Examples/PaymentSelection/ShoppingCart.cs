namespace Examples.PaymentSelection
{
    public record CartItem(string Name, decimal Price, int Quantity);

    public class ShoppingCart
    {
        private readonly List<CartItem> _items = [];
        public void AddItem(string name, decimal price, int quantity = 1) => _items.Add(new CartItem(name, price, quantity));
        public decimal CalculateTotal() => _items.Sum(item => item.Price * item.Quantity);
        public PaymentResult Checkout(IPaymentStrategy paymentOption)
        {
           var result = PaymentGateway.GeneratePayment(CalculateTotal(), paymentOption).ProcessPayment();
           if(result.Success) _items.Clear();
           return result;
        }
    }
}
