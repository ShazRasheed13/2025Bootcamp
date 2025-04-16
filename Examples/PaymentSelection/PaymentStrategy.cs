using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.PaymentSelection
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer
    }

    public record PaymentResult(bool Success, string TransactionId, double TotalAmount, DateTime TransactionDate, PaymentMethod PaymentMethod);

    public interface IPaymentStrategy
    {
        PaymentResult ProcessPayment(double amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(double amount)
        {
            return new PaymentResult
            (
               true,
               Guid.NewGuid().ToString(),
               amount,
               DateTime.Now,
               PaymentMethod.CreditCard
            );
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(double amount)
        {
            return new PaymentResult
            (
                true,
                Guid.NewGuid().ToString(),
                amount,
                DateTime.Now,
                PaymentMethod.PayPal
            );
        }
    }

    public class BankTransferPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(double amount)
        {
            return new PaymentResult
            (
                true,
                Guid.NewGuid().ToString(),
                amount,
                DateTime.Now,
                PaymentMethod.BankTransfer
            );
        }
    }
}
