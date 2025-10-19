using System;

namespace Parking.Domain.Parking.Subscriptions
{
    public record SubscriptionID
    {
        public Guid ID { get; }

        private SubscriptionID(Guid id)
        {
            ID = id;
        }

        public static SubscriptionID Create(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(nameof(id), "ID абонемента не может быть пустым.");

            return new SubscriptionID(id);
        }

        public static SubscriptionID CreateNew()
        {
            return new SubscriptionID(Guid.NewGuid());
        }
    }
}