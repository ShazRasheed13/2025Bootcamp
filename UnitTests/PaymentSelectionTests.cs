using Examples.PaymentSelection;

namespace UnitTests
{
    public class PaymentSelectionTests
    {
        [Fact]
        public void PaymentStrategyNotSet()
        {
            var cart = new ShoppingCart();
            cart.AddItem("Item 1", 10.50m);
            cart.AddItem("Item 2", 20.75m, 2);
            Assert.Throws<InvalidOperationException>(()=>cart.Checkout(null!));

        }

        [Fact]
        public void CreditCardPayment()
        {
            var creditCardPayment = PaymentGateway.CreditCard();
            const decimal amount = 100.50m;
            var result = creditCardPayment.ProcessPayment(amount);

            Assert.True(result.Success);
            Assert.NotNull(result.TransactionId);
            Assert.Equal(PaymentMethod.CreditCard, result.PaymentMethod);
            Assert.Equal(100.50m, result.TotalAmount);
        }

        [Fact]
        public void PayPalPayment()
        {
            var payPalPayment = PaymentGateway.PayPal();
            const decimal amount = 100.50m;

            var result = payPalPayment.ProcessPayment(amount);

            Assert.True(result.Success);
            Assert.Equal(PaymentMethod.PayPal, result.PaymentMethod);
            Assert.NotNull(result.TransactionId);
        }

        [Fact]
        public void BankTransferPayment()
        {
            var bankTransferPayment = PaymentGateway.BankTransfer();
            const decimal amount = 100.50m;
            var result = bankTransferPayment.ProcessPayment(amount);
            Assert.True(result.Success);
            Assert.Equal(PaymentMethod.BankTransfer, result.PaymentMethod);
            Assert.NotNull(result.TransactionId);
        }

        [Fact]
        public void AddItem_CalculatesShoppingCartTotal()
        {
            var cart = new ShoppingCart();

            cart.AddItem("Item 1", 10.50m, 2);
            cart.AddItem("Item 2", 20.75m);
            cart.AddItem("Item 3", 5.99m,2);

            Assert.Equal(53.73m, cart.CalculateTotal(), 2);
        }

        [Fact]
        public void AfterPaymentCartTotalCleared()
        {
            var cart = new ShoppingCart();
            cart.AddItem("Item 1", 10.50m);
            cart.AddItem("Item 2", 20.75m);

            var result = cart.Checkout(PaymentGateway.CreditCard());

            Assert.True(result.Success);
            Assert.NotNull(result.TransactionId);
            Assert.Equal(31.25m, result.TotalAmount);
            Assert.Equal(0, cart.CalculateTotal());
        }

    }
}
