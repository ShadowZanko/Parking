using Domain.Parking;
using System;

namespace Parking.Domain.Parking.Subscriptions
{
    public record Subscriptions
    {
        public SubscriptionID SubscriptionID { get; private set; }
        public Discount Discount { get; private set; }
        public DurationTime Duration { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public Tariffs Tariff { get; private set; }

        public Subscriptions(
            SubscriptionID id,
            Discount discount,
            DurationTime duration,
            PaymentMethod paymentMethod,
            Tariffs tariff)
        {
            SubscriptionID = id;
            Discount = discount;
            Duration = duration;
            PaymentMethod = paymentMethod;
            Tariff = tariff;
        }
    }
}