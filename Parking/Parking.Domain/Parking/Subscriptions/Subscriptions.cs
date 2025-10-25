using System;
using Domain.Parking;
using Domain.Parking.Subscriptions;

namespace Parking.Domain.Parking.Subscriptions
{
    public record Subscriptions
    {
        public SubscriptionID SubscriptionID { get; }
        public Discount Discount { get; }
        public DurationTime Duration { get; }
        public PaymentMethod PaymentMethod { get; }
        public Tariffs Tariff { get; }

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

