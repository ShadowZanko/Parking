using Domain.Parking;
using SubscriptionType = Parking.Domain.Parking.Subscriptions.Subscriptions; // Псевдоним

namespace Domain.Parking
{
    public class Parking
    {
        public SubscriptionType Subscription { get; }
        public IDParking ParkingID { get; }
        public NumberOfSeats NumberOfSeats { get; }
        public Tariffs Tariff { get; }
        public Customer Customer { get; }

        public Parking(
            SubscriptionType subscription,
            IDParking parkingID,
            NumberOfSeats numberOfSeats,
            Tariffs tariff,
            Customer customer)
        {
            Subscription = subscription;
            ParkingID = parkingID;
            NumberOfSeats = numberOfSeats;
            Tariff = tariff;
            Customer = customer;
        }
    }
}
