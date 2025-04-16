namespace Examples.PaymentSelection
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer
    }

    public record PaymentResult(bool Success, string TransactionId, decimal TotalAmount, DateTime TransactionDate, PaymentMethod PaymentMethod);

    public interface IPaymentStrategy
    {
        PaymentResult ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(decimal amount) =>
            new(
                true,
                Guid.NewGuid().ToString(),
                amount,
                DateTime.Now,
                PaymentMethod.CreditCard
            );
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(decimal amount) =>
            new(
                true,
                Guid.NewGuid().ToString(),
                amount,
                DateTime.Now,
                PaymentMethod.PayPal
            );
    }

    public class BankTransferPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(decimal amount) =>
            new(
                true,
                Guid.NewGuid().ToString(),
                amount,
                DateTime.Now,
                PaymentMethod.BankTransfer
            );
    }
}
