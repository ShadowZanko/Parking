using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace Domain.Parking
{
    public class Email : IEquatable<Email>
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Email>("Email не может быть пустым");
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email.Trim(), pattern))
                return Result.Failure<Email>("Неверный формат email");
            return Result.Success(new Email(email.Trim()));
        }

        public bool Equals(Email other)
        {
            if (other is null)
                return false;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Email other && Equals(other);
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
