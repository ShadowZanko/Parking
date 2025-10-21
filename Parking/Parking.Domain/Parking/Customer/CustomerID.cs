namespace Domain.Parking
{
    public record CustomerID
    {
        public Guid Value { get; }
        private CustomerID(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Идентификатор клиента не может быть пустым.");
            Value = value;
        }
        public static CustomerID Create(Guid value)
        {
            return new CustomerID(value);
        }
        public static CustomerID CreateNew()
        {
            return new CustomerID(Guid.NewGuid());
        }
    }
}