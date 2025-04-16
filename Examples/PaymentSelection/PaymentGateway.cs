namespace Examples.PaymentSelection;

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
}