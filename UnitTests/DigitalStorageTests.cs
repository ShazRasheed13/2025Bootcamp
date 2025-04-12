using Examples.DigitalStorage;
using Exercises.DigitalStorage.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class DigitalStorageTests
    {
        [Fact]
        public void EqualityOfLikeUnits()
        {
            Assert.Equal(1024.Bytes(), 1024.Bytes());
            Assert.NotEqual(1024.Bytes(), 512.Bytes());
            Assert.NotEqual(1024.Bytes(), new object());
            Assert.NotEqual(1024.Bytes(), null);
        }

        [Fact]
        public void EqualityOfDifferentUnits()
        {
            Assert.Equal(1.KB(), 1024.Bytes());
            Assert.Equal(1.MB(), 1024.KB());
            Assert.Equal(1.GB(), 1024.MB());
            Assert.Equal(1.TB(), 1024.GB());
            Assert.Equal(1.PB(), 1024.TB());
        }

        [Fact]
        public void HashCodeConsistency()
        {
            Assert.Equal(1.KB().GetHashCode(), 1024.Bytes().GetHashCode());
            Assert.Equal(1.MB().GetHashCode(), 1024.KB().GetHashCode());
        }

        [Fact]
        public void SetOperations()
        {
            var set = new HashSet<StorageQuantity> { 1.KB(), 1024.Bytes() };
            Assert.Single(set);
            Assert.Contains(1.KB(), set);
        }

        [Fact]
        public void ArithmeticOperations()
        {
            Assert.Equal(2.KB(), 1.KB() + 1024.Bytes());
            Assert.Equal(1.MB(), 512.KB() + 512.KB());

            Assert.Equal(1.KB(), 2.KB() - 1024.Bytes());
            Assert.Equal(512.KB(), 1.MB() - 512.KB());
        }

        [Fact]
        public void Comparison()
        {
            Assert.True(2.KB().IsBetterThan(1.KB()));
            //Assert.True(1.MB().IsBetterThan(1024.KB()));
            //Assert.False(1.KB().IsBetterThan(1.MB()));
        }

        [Fact]
        public void ByteConversion()
        {
            //Assert.Equal(1024, 1.KB().ToBytes());
            //Assert.Equal(1048576, 1.MB().ToBytes());
            //Assert.Equal(1073741824, 1.GB().ToBytes());
        }

        [Fact]
        public void LargeNumberConversions()
        {
            Assert.Equal(1.PB(), 1024.TB());
            Assert.Equal(1.TB(), 1_048_576.MB());
            Assert.Equal(1.GB(), 1_073_741_824.Bytes());
        }

    }
}
