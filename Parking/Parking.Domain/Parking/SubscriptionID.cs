using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parking
{
    public record SubscriptionID
    {
        public Guid ID { get; }
        public SubscriptionID(Guid id)
        {
            ID = id;
        }
        public SubscriptionID()
        {
            ID = Guid.NewGuid();
        }
        public static SubscriptionID Create(Guid i)
        {
            if (i == Guid.Empty)
                throw new ArgumentException(nameof(i), "ID абонемента не может быть пустым.");
            return new SubscriptionID(i);
        }
    }
}
