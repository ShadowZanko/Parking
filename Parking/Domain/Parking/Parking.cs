namespace Domain.Parking
{
    internal class Parking
    {
        public Subscriptions subscriptions { get; private set; }
        public IDParking parkingID { get; private set; }
        public NumberOfSeats numberofseats { get; private set; }
        public Tariffs tariffs { get; private set; }
        public CustomerID customerID { get; private set; }
        public Parking(
            Subscriptions sub,
            IDParking PID,
            NumberOfSeats NOS,
            Tariffs tar,
            CustomerID CID
        )
        {
            subscriptions = sub;
            parkingID = PID;
            numberofseats = NOS;
            tariffs = tar;
            customerID = CID;
        }
        public Parking(Subscriptions sub, IDParking PID,
            NumberOfSeats NOS, Tariffs tar) : this(new CustomerID(), sub, PID, NOS, tar, CID)
        {

        }
    }
}
