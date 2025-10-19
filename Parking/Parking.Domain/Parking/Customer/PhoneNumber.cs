using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace Parking.Domain.Parking.Customer
{
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        public string Value { get; }

        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static Result<PhoneNumber> Create(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return Result.Failure<PhoneNumber>("Номер телефона не может быть пустым");
            string pattern = @"^(\+?\d{1,3})?[-.\s]?(\(\d{1,}\))?[-.\s]?[\d-.\s]{3,}$";
            if (!Regex.IsMatch(phoneNumber.Trim(), pattern))
                return Result.Failure<PhoneNumber>("Неверный формат номера телефона");
            return Result.Success(new PhoneNumber(phoneNumber.Trim()));
        }

        public bool Equals(PhoneNumber other)
        {
            if (other is null)
                return false;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is PhoneNumber other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
