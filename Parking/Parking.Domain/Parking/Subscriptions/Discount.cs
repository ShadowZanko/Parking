using System;

namespace Parking.Domain.Parking.Subscriptions
{
    public record Discount
    {
        public string Name { get; }

        private Discount(double value)
        {
            Name = $"{value}%";
        }

        public static Discount Create(double value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Скидка должна быть от 0 до 100 процентов.");
            return new Discount(value);
        }
    }
}
