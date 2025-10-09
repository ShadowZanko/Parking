using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parking
{
    public record CustomerID
    {
        public Guid ID { get; }
        public CustomerID(Guid id)
        {
            ID = id;
        }
        public static CustomerID Create(Guid i)
        {
            if (i == Guid.Empty)
                throw new ArgumentException(nameof(i), "ID клиента не может быть пустым.");
            return new CustomerID(i);
        }
    }
}
