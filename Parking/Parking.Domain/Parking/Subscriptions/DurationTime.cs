using System;

namespace Domain.Parking.Subscriptions
{
    public record DurationTime
    {
        public long Time { get; }

        private DurationTime(long time)
        {
            Time = time;
        }

        public static DurationTime Create(long time)
        {
            if (time <= 0)
                throw new ArgumentOutOfRangeException(nameof(time), "Продолжительность должна быть положительным числом.");
            if (time > 100_000)
                throw new ArgumentOutOfRangeException(nameof(time), "Продолжительность слишком велика для допустимого диапазона.");
            return new DurationTime(time);
        }
    }
}
