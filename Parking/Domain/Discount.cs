using Domain.Parking;

namespace Domain
{
    public record Discount
    {
        public string Name { get; }
        public Discount(string name)
        {
            Name = name;
        }
        public static Discount Create(double i)
        {
            if (i < 0 || i > 100)
                throw new ArgumentOutOfRangeException(nameof(i), "Скидка должна быть от 0 до 100 процентов.");
            return new Discount(i);
        }
    }
}