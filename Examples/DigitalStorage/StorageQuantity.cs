using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DigitalStorage
{
    public class StorageQuantity
    {
        protected readonly double _amount;
        protected readonly Unit _unit;

        internal StorageQuantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public bool IsBetterThan(StorageQuantity other) =>
            this._amount > ConvertedAmount(other);

        protected double ConvertedAmount(StorageQuantity other) =>
            this._unit.ConvertedAmount(other._amount, other._unit);

        public override bool Equals(object? obj) =>
            this == obj || obj is StorageQuantity other && this.Equals(other);

        private bool Equals(StorageQuantity other) =>
            Math.Abs(this._amount - ConvertedAmount(other)) < Unit.Epsilon;

        public override int GetHashCode() => _unit.GetHashCode(_amount);

        public static StorageQuantity operator +(StorageQuantity left, StorageQuantity right) =>
            new(left._amount + left.ConvertedAmount(right), left._unit);

        public static StorageQuantity operator -(StorageQuantity left, StorageQuantity right) =>
            new(left._amount - left.ConvertedAmount(right), left._unit);

        public double ToBytes() => _unit.ConvertedAmount(_amount, Unit.Byte);
    }
}
