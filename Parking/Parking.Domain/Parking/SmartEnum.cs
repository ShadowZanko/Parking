using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Parking.Enums
{
    public abstract class SmartEnum<TEnum> : IEquatable<SmartEnum<TEnum>> where TEnum : SmartEnum<TEnum>
    {
        private static readonly Dictionary<int, TEnum> Enums = new Dictionary<int, TEnum>();

        public int Value { get; }
        public string Name { get; }

        protected SmartEnum(int value, string name)
        {
            Value = value;
            Name = name;
            Enums[value] = (TEnum)this;
        }
        //Test
        public override string ToString() => Name;

        public static TEnum FromValue(int value)
        {
            if (Enums.TryGetValue(value, out var enumValue))
            {
                return enumValue;
            }
            throw new ArgumentException($"No {typeof(TEnum).Name} with value {value} found.");
        }

        public static IEnumerable<TEnum> GetAll() => Enums.Values.ToList();

        public bool Equals(SmartEnum<TEnum> other)
        {
            if (other is null)
                return false;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is SmartEnum<TEnum> otherValue)
            {
                return Equals(otherValue);
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}
