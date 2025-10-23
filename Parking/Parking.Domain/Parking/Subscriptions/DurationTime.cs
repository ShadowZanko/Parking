using System;

namespace Domain.Parking.Subscriptions
{
    public record DurationTime
    {
        public enum DurationType
        {
            OneDay,
            OneWeek,
            OneMonth,
            ThreeMonths,
            SixMonths,
            OneYear
        }

        public DurationType Type { get; }
        public long Time { get; }

        private DurationTime(DurationType type, long time)
        {
            Type = type;
            Time = time;
        }

        public static DurationTime Create(DurationType type, long time)
        {
            if (time <= 0)
                throw new ArgumentOutOfRangeException(nameof(time), "Продолжительность должна быть положительным числом.");
            if (time > 100_000)
                throw new ArgumentOutOfRangeException(nameof(time), "Продолжительность слишком велика для допустимого диапазона.");

            return new DurationTime(type, time);
        }

        public static DurationTime Create(DurationType type)
        {
            long time = type switch
            {
                DurationType.OneDay => 1,
                DurationType.OneWeek => 7,
                DurationType.OneMonth => 30,
                DurationType.ThreeMonths => 90,
                DurationType.SixMonths => 180,
                DurationType.OneYear => 365,
                _ => throw new ArgumentException("Некорректный тип продолжительности.")
            };

            return new DurationTime(type, time);
        }
    }
}
