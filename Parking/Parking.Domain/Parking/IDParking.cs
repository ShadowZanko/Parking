using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parking
{
    public record IDParking
    {
        public Guid ID { get; }
        private IDParking(Guid id)
        {
            ID = id;
        }
        public static IDParking Create(Guid i)
        {
            if (i == Guid.Empty)
                throw new ArgumentException(nameof(i), "ID парковки не может быть пустым.");
            return new IDParking(i);
        }
    }
}
