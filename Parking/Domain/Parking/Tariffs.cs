using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parking
{
    public record Tariffs
    {
        public string TariffName { get; }
        public Tariffs(string tariffName)
        {
            TariffName = tariffName;
        }
        public static Tariffs Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Способ оплаты не может быть пустым.", nameof(name));
            string forma = name.Trim();
            if (forma.Length <= 1)
                throw new ArgumentException("Название тарифа слишком мало.");
            if (forma.Length >= 50)
                throw new ArgumentException("Название тарифа слишком большое.");
            return new Tariffs(forma);
        }
    }
}
