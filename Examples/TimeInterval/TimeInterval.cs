using Examples.TimeInterval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.TimeInterval
{
    public class TimeInterval
    {
        private readonly double _seconds; 
        private const double Epsilon = 1e-9;

        internal TimeInterval(double seconds)
        {
            if (seconds < 0.0)
                throw new ArgumentException("Time interval cannot be negative");
            _seconds = seconds;
        }

        public bool IsBetterThan(TimeInterval other) =>
            this._seconds > other._seconds;

        public override bool Equals(object? obj) =>
            this == obj || obj is TimeInterval other && this.Equals(other);

        private bool Equals(TimeInterval other) =>
            Math.Abs(this._seconds - other._seconds) < Epsilon;

        public override int GetHashCode() =>
            Math.Round(_seconds / Epsilon).GetHashCode();

        public TimeInterval Add(TimeInterval other) =>
            new TimeInterval(this._seconds + other._seconds);

        public static TimeInterval operator +(TimeInterval t1, TimeInterval t2) =>
            t1.Add(t2);

        public TimeInterval Subtract(TimeInterval other) =>
            new TimeInterval(this._seconds - other._seconds);

        public static TimeInterval operator -(TimeInterval t1, TimeInterval t2) =>
            t1.Subtract(t2);

        public TimeInterval Multiply(double factor)
        {
            if (factor < 0)
                throw new ArgumentException("Cannot multiply time by negative factor");
            return new TimeInterval(this._seconds * factor);
        }

        public static TimeInterval operator *(TimeInterval t, double factor) =>
            t.Multiply(factor);

        public double ToSeconds() => _seconds;
        public double ToMinutes() => _seconds / 60.0;
        public double ToHours() => _seconds / 3600.0;
        public double ToDays() => _seconds / (24 * 3600.0);
    }
}

namespace ExtensionMethods.Time
{
    public static class TimeIntervalConstructors
    {
        public static TimeInterval Seconds(this double value) =>
            new TimeInterval(value);

        public static TimeInterval Seconds(this int value) =>
            new TimeInterval(value);

        public static TimeInterval Minutes(this double value) =>
            new TimeInterval(value * 60);

        public static TimeInterval Hours(this double value) =>
            new TimeInterval(value * 3600);

        public static TimeInterval Days(this double value) =>
            new TimeInterval(value * 24 * 3600);
    }
}
