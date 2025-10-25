using System;
using System.Linq;

namespace Domain.Parking.Subscriptions
{
    public record PaymentMethod
    {
        public enum PaymentMethodType
        {
            Cash,
            CreditCard,
            BankTransfer,
            MobilePayment,
            ElectronicWallet
        }

        public PaymentMethodType Type { get; }

        private PaymentMethod(PaymentMethodType type)
        {
            Type = type;
        }

        public static PaymentMethod Create(PaymentMethodType type)
        {
            return new PaymentMethod(type);
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

            if (Enum.TryParse(forma, true, out PaymentMethodType type))
            {
                return new PaymentMethod(type);
            }
            throw new ArgumentException("Некорректный способ оплаты.");
        }
    }
}
