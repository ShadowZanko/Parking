using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Parking;

namespace Domain.Parking
{
    public record NumberOfSeats
    {
        public int Number { get; }
        private NumberOfSeats(int number)
        {
            Number = number;
        }
        public static NumberOfSeats Create(int i)
        {
            if (i <=0)
                throw new ArgumentException(nameof(i), "Количество мест не может быть пустым.");
            return new NumberOfSeats(i);
        }
    }
}
