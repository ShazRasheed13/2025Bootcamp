using Examples.DigitalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DigitalStorage
{
    public class Unit
    {
        internal const double Epsilon = 1e-9;

        // Base unit definitions
        internal static readonly Unit Byte = new Unit();
        internal static readonly Unit Kilobyte = new Unit(1024, Byte);
        internal static readonly Unit Megabyte = new Unit(1024, Kilobyte);
        internal static readonly Unit Gigabyte = new Unit(1024, Megabyte);
        internal static readonly Unit Terabyte = new Unit(1024, Gigabyte);
        internal static readonly Unit Petabyte = new Unit(1024, Terabyte);

        private readonly Unit _baseUnit;
        private readonly double _baseUnitRatio;

        private Unit()
        {
            _baseUnit = this;
            _baseUnitRatio = 1.0;
        }

        private Unit(double relativeRatio, Unit relativeUnit)
        {
            _baseUnit = relativeUnit._baseUnit;
            _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
        }

        internal double ConvertedAmount(double otherAmount, Unit other)
        {
            if (!IsCompatible(other)) throw new ArgumentException("Incompatible units for operation");
            return otherAmount * other._baseUnitRatio / this._baseUnitRatio;
        }

        internal int GetHashCode(double amount) =>
            Math.Round(amount / Epsilon * _baseUnitRatio).GetHashCode();

        internal bool IsCompatible(Unit other) => this._baseUnit == other._baseUnit;
    }
}

namespace Exercises.DigitalStorage.Extensions
{
    public static class StorageExtensions
    {
        public static StorageQuantity Bytes(this double amount) =>
            new(amount, Unit.Byte);

        public static StorageQuantity Bytes(this int amount) =>
            new(amount, Unit.Byte);

        public static StorageQuantity KB(this double amount) =>
            new(amount, Unit.Kilobyte);

        public static StorageQuantity KB(this int amount) =>
            new(amount, Unit.Kilobyte);

        public static StorageQuantity MB(this double amount) =>
            new(amount, Unit.Megabyte);

        public static StorageQuantity MB(this int amount) =>
            new(amount, Unit.Megabyte);

        public static StorageQuantity GB(this double amount) =>
            new(amount, Unit.Gigabyte);

        public static StorageQuantity GB(this int amount) =>
            new(amount, Unit.Gigabyte);

        public static StorageQuantity TB(this double amount) =>
            new(amount, Unit.Terabyte);

        public static StorageQuantity TB(this int amount) =>
            new(amount, Unit.Terabyte);

        public static StorageQuantity PB(this double amount) =>
            new(amount, Unit.Petabyte);

        public static StorageQuantity PB(this int amount) =>
            new(amount, Unit.Petabyte);
    }
}