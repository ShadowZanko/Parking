using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parking
{
    public record Subscriptions
    {
        public string SubscriptionName { get; }
        public Subscriptions(string subscriptionName)
        {
            SubscriptionName = subscriptionName;
        }
        public SubscriptionID subscriptionID { get; private set; }
        public Discount Discount { get; private set; }
        public DurationTime duration { get; private set; }
        public PaymentMethod paymentMethod { get; private set; }
        public Subscriptions(
            SubscriptionID id,
            Discount name,
            DurationTime time,
            PaymentMethod payment
        )
        {
            subscriptionID = id;
            Discount = name;
            duration = time;
            paymentMethod = payment;
        }
        public Subscriptions(Discount name, DurationTime time,
            PaymentMethod payment) : this (new SubscriptionID(), name, time, payment)
        {

        }
        public static Tariffs Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Название абонемента было пустым.");
            string forma = name.Trim();
            if (forma.Length <= 2)
                throw new ArgumentException("Название абонемента слишком мало.");
            if (forma.Length >= 60)
                throw new ArgumentException("Название абонемента слишком большое.");
            return new Tariffs(forma);
        }
    }
}
