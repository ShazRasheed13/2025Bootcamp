using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.Distance;

namespace Examples.Distance
{

    public class Distance
    {
        private readonly double _meters; // Store everything in base unit (meters)
        private const double Epsilon = 1e-9;

        internal Distance(double meters)
        {
            if (meters < 0.0)
                throw new ArgumentException("Distance cannot be negative");
            _meters = meters;
        }

        public bool IsBetterThan(Distance other) => this._meters > other._meters;

        public override bool Equals(object? obj) =>
            this == obj || obj is Distance other && this.Equals(other);

        private bool Equals(Distance other) =>
            Math.Abs(this._meters - other._meters) < Epsilon;

        public override int GetHashCode() =>
            Math.Round(_meters / Epsilon).GetHashCode();

        public Distance Add(Distance other) =>
            new Distance(this._meters + other._meters);

        public static Distance operator +(Distance d1, Distance d2) =>
            d1.Add(d2);

        public Distance Subtract(Distance other) =>
            new Distance(this._meters - other._meters);

        public static Distance operator -(Distance d1, Distance d2) =>
            d1.Subtract(d2);

    }
}

namespace ExtensionMethods.Measurement
{
    public static class DistanceExtensions
    {
        public const double MetersInKiloMeter = 1000.0;
        public const double MetersInMile = 1609.344;

        public static Distance Meters(this double meters) =>
            new Distance(meters);
        public static Distance KiloMeters(this double meters) =>
            new Distance(meters * MetersInKiloMeter);
        public static Distance Miles(this double meters) =>
            new Distance(meters * MetersInMile);
    }
}

