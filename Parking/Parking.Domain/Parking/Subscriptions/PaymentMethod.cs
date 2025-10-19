using System;

namespace Parking.Domain.Parking.Subscriptions
{
    public record PaymentMethod
    {
        public string Payment { get; }

        private PaymentMethod(string payment)
        {
            Payment = payment;
        }

        public static PaymentMethod Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Способ оплаты не может быть пустым.", nameof(name));
            string forma = name.Trim();
            if (forma.Length <= 1)
                throw new ArgumentException("Способ оплаты слишком короткий.");
            if (forma.Length > 50)
                throw new ArgumentException("Способ оплаты слишком длинный.");
            return new PaymentMethod(forma);
        }
    }
}
