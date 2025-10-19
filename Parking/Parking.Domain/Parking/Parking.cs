using Parking.Domain.Parking.Subscriptions;

namespace Domain.Parking
{
    public class Parking
    {
        public Subscriptions Subscriptions { get; private set; }
        public IDParking ParkingID { get; private set; }
        public NumberOfSeats NumberOfSeats { get; private set; }
        public Tariffs Tariffs { get; private set; }
        public Customer Customer { get; private set; }

        public Parking(
            Subscriptions subscriptions,
            IDParking parkingID,
            NumberOfSeats numberOfSeats,
            Tariffs tariffs,
            Customer customer)
        {
            Subscriptions = subscriptions;
            ParkingID = parkingID;
            NumberOfSeats = numberOfSeats;
            Tariffs = tariffs;
            Customer = customer;
        }
    }
}
