using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Parking
{
    public record Tariffs
    {
        public enum TariffType
        {
            Hourly,
            Daily,
            Weekly,
            Monthly,
            Yearly
        }

        public TariffType Type { get; }
        public string TariffName { get; }
        public decimal Price { get; }

        private Tariffs(TariffType type, string tariffName, decimal price)
        {
            Type = type;
            TariffName = tariffName;
            Price = price;
        }

        public static Tariffs Create(TariffType type, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название тарифа не может быть пустым.", nameof(name));
            string forma = name.Trim();
            if (forma.Length <= 1)
                throw new ArgumentException("Название тарифа слишком короткое.");
            if (forma.Length > 50)
                throw new ArgumentException("Название тарифа слишком длинное.");
            if (price <= 0)
                throw new ArgumentException("Цена должна быть положительным числом.", nameof(price));

            return new Tariffs(type, forma, price);
        }
    }
}
