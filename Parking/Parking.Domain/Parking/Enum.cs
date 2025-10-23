using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Parking.Enums
{
    public abstract class Enum<TEnum, TValue> : IEquatable<Enum<TEnum, TValue>> where TEnum : Enum<TEnum, TValue>
    {
        private static readonly Dictionary<TValue, TEnum> Enums = new Dictionary<TValue, TEnum>();

        public TValue Value { get; }
        public string Name { get; }

        protected Enum(TValue value, string name)
        {
            Value = value;
            Name = name;
            Enums[value] = (TEnum)this;
        }

        public override string ToString() => Name;

        public static TEnum FromValue(TValue value)
        {
            if (Enums.TryGetValue(value, out var enumValue))
            {
                return enumValue;
            }
            throw new ArgumentException($"No {typeof(TEnum).Name} with value {value} found.");
        }

        public static IEnumerable<TEnum> GetAll() => Enums.Values.ToList();

        public bool Equals(Enum<TEnum, TValue> other)
        {
            if (other is null)
                return false;
            return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is Enum<TEnum, TValue> otherValue)
            {
                return Equals(otherValue);
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
