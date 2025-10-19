using CSharpFunctionalExtensions;

namespace Domain.Parking
{
    public class Customer : IEquatable<Customer>
    {
        public CustomerID CustomerID { get; }
        public ContactInformation ContactInformation { get; }
        public CustomerName CustomerName { get; }

        private Customer(CustomerID id, ContactInformation contact, CustomerName customerName)
        {
            CustomerID = id;
            ContactInformation = contact;
            CustomerName = customerName;
        }

        public static Result<Customer> Create(ContactInformation contact, CustomerName customerName)
        {
            var id = CustomerID.CreateNew();
            return Result.Success(new Customer(id, contact, customerName));
        }

        public static Result<Customer> CreateWithID(CustomerID id, ContactInformation contact, CustomerName customerName)
        {
            if (id == null)
                return Result.Failure<Customer>("Идентификатор клиента не может быть пустым.");
            if (contact == null)
                return Result.Failure<Customer>("Контактная информация не может быть пустой.");
            if (customerName == null)
                return Result.Failure<Customer>("Имя клиента не может быть пустым.");

            return Result.Success(new Customer(id, contact, customerName));
        }

        public bool Equals(Customer other)
        {
            if (other is null)
                return false;
            return CustomerID.Equals(other.CustomerID) &&
                   ContactInformation.Equals(other.ContactInformation) &&
                   CustomerName.Equals(other.CustomerName);
        }

        public override bool Equals(object obj)
        {
            return obj is Customer other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CustomerID, ContactInformation, CustomerName);
        }

        public override string ToString()
        {
            return $"{CustomerName}: {ContactInformation}";
        }
    }
}