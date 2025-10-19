using System;

namespace Domain.Parking
{
    public record Tariffs
    {
        public string TariffName { get; }

        private Tariffs(string tariffName)
        {
            TariffName = tariffName;
        }

        public static Tariffs Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название тарифа не может быть пустым.", nameof(name));

            string forma = name.Trim();

            if (forma.Length <= 1)
                throw new ArgumentException("Название тарифа слишком короткое.");
            if (forma.Length > 50)
                throw new ArgumentException("Название тарифа слишком длинное.");

            return new Tariffs(forma);
        }
    }
}