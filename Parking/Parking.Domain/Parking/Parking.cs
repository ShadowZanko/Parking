using Domain.Parking;
using ParkingSubscriptions = Parking.Domain.Parking.Subscriptions.Subscriptions;

namespace Domain.Parking
{
    public class Parking
    {
        public ParkingSubscriptions Subscription { get; private set; }
        public IDParking ParkingID { get; private set; }
        public NumberOfSeats NumberOfSeats { get; private set; }
        public Tariffs Tariff { get; private set; }
        public Customer Customer { get; private set; }

        public Parking(
            ParkingSubscriptions subscription,
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
