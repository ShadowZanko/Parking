namespace Domain.Parking
{
    internal class Parking
    {
        public Subscriptions Subscriptions { get; private set; }
        public IDParking ParkingID { get; private set; }
        public NumberOfSeats NumberOfSeats { get; private set; }
        public Tariffs Tariffs { get; private set; }
        public CustomerID CustomerID { get; private set; }

        public Parking(
            Subscriptions sub,
            IDParking pid,
            NumberOfSeats nos,
            Tariffs tar,
            CustomerID cid
        )
        {
            Subscriptions = sub;
            ParkingID = pid;
            NumberOfSeats = nos;
            Tariffs = tar;
            CustomerID = cid;
        }

        public Parking(
            Subscriptions sub,
            IDParking pid,
            NumberOfSeats nos,
            Tariffs tar) : this(sub, pid, nos, tar, CustomerID.Create(Guid.NewGuid()))
        {

        }
    }
}