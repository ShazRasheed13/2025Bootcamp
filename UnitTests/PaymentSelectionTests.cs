using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.PaymentSelection;
using Xunit;

namespace UnitTests
{
    public class PaymentSelectionTests
    {
        [Fact]
        public void PaymentStrategyNotSet()
        {
            var cart = new ShoppingCart();
            cart.AddItem("Item 1", 10.50);
            cart.AddItem("Item 2", 20.75);
            Assert.Throws<InvalidOperationException>(()=>cart.Checkout());

        }

        [Fact]
        public void CreditCardPayment()
        {
            var creditCardPayment = new CreditCardPayment();
            double amount = 100.50;

            var result = creditCardPayment.ProcessPayment(amount);

            Assert.True(result.Success);
            Assert.NotNull(result.TransactionId);
            Assert.Equal(PaymentMethod.CreditCard, result.PaymentMethod);
            Assert.Equal(100.50, result.TotalAmount);
        }

        [Fact]
        public void PayPalPayment()
        {
            var payPalPayment = new PayPalPayment();
            double amount = 75.25;

            var result = payPalPayment.ProcessPayment(amount);

            Assert.True(result.Success);
            Assert.Equal(PaymentMethod.PayPal, result.PaymentMethod);
            Assert.NotNull(result.TransactionId);
        }

        [Fact]
        public void BankTransferPayment()
        {
            var bankTransferPayment = new BankTransferPayment();
            double amount = 200.00;
            var result = bankTransferPayment.ProcessPayment(amount);
            Assert.True(result.Success);
            Assert.Equal(PaymentMethod.BankTransfer, result.PaymentMethod);
            Assert.NotNull(result.TransactionId);
        }

        [Fact]
        public void AddItem_CalculatesShoppingCartTotal()
        {
            var cart = new ShoppingCart();

            cart.AddItem("Item 1", 10.50);
            cart.AddItem("Item 2", 20.75);
            cart.AddItem("Item 3", 5.99);

            Assert.Equal(37.24, cart.CalculateTotal(), 2);
        }

        [Fact]
        public void AfterPaymentCartTotalCleared()
        {
            var cart = new ShoppingCart();
            cart.AddItem("Item 1", 10.50);
            cart.AddItem("Item 2", 20.75);
            var paymentStrategy = new CreditCardPayment();
            cart.SetPaymentStrategy(paymentStrategy);

            var result = cart.Checkout();

            Assert.True(result.Success);
            Assert.NotNull(result.TransactionId);
            Assert.Equal(31.25, result.TotalAmount);
            Assert.Equal(0, cart.CalculateTotal());
        }

    }
}
