using CSharpFunctionalExtensions;
using Parking.Domain.Parking.Customer;

namespace Domain.Parking
{
    public class ContactInformation : IEquatable<ContactInformation>
    {
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }

        private ContactInformation(Email email, PhoneNumber phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public static Result<ContactInformation> Create(Email email, PhoneNumber phoneNumber)
        {
            var errors = new List<string>();
            if (email == null)
                errors.Add("Email не указан");
            if (phoneNumber == null)
                errors.Add("Телефон не указан");
            if (errors.Count > 0)
                return Result.Failure<ContactInformation>(string.Join("; ", errors));
            return Result.Success(new ContactInformation(email, phoneNumber));
        }

        public static Result<ContactInformation> Create(string email, string phoneNumber)
        {
            var emailResult = Email.Create(email);
            if (!emailResult.IsSuccess)
                return Result.Failure<ContactInformation>(emailResult.Error);
            var phoneNumberResult = PhoneNumber.Create(phoneNumber);
            if (!phoneNumberResult.IsSuccess)
                return Result.Failure<ContactInformation>(phoneNumberResult.Error);
            return Create(emailResult.Value, phoneNumberResult.Value);
        }

        public bool Equals(ContactInformation other)
        {
            if (other is null)
                return false;
            return Email.Equals(other.Email) && PhoneNumber.Equals(other.PhoneNumber);
        }

        public override bool Equals(object obj)
        {
            return obj is ContactInformation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, PhoneNumber);
        }

        public override string ToString()
        {
            return $"Email: {Email}, Телефон: {PhoneNumber}";
        }
    }
}
