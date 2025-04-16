namespace Examples.PaymentSelection;

public interface IPaymentStrategy
{
    PaymentResult ProcessPayment(decimal amount);
}

public class PaymentGateway
{
    private readonly decimal _amount;
    private readonly IPaymentStrategy _paymentOption;

    private PaymentGateway(decimal amount, IPaymentStrategy paymentOption)
    {
        _paymentOption = paymentOption ?? throw new InvalidOperationException("Payment strategy not set");
        _amount = amount;
    }

    public static PaymentGateway GeneratePayment(decimal amount, IPaymentStrategy paymentOption) => new(amount, paymentOption);
    public PaymentResult ProcessPayment() => _paymentOption.ProcessPayment(_amount);
    public static IPaymentStrategy CreditCard() => new CreditCardPayment();
    public static IPaymentStrategy PayPal() => new PayPalPayment();
    public static IPaymentStrategy BankTransfer() => new BankTransferPayment();

    private class CreditCardPayment : IPaymentStrategy
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

    private class PayPalPayment : IPaymentStrategy
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

    private class BankTransferPayment : IPaymentStrategy
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

public record PaymentResult(bool Success, string TransactionId, decimal TotalAmount, DateTime TransactionDate, PaymentMethod PaymentMethod);

public enum PaymentMethod
{
    CreditCard,
    PayPal,
    BankTransfer
}