using Examples.TimeInterval;
using ExtensionMethods.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtensionMethods.Measurement;


namespace UnitTests
{
    public class TimeIntervalTests
    {
        private static readonly TimeInterval OneMinute = 1.0.Minutes();
        private static readonly TimeInterval OneHour = 1.0.Hours();
        private static readonly TimeInterval OneDay = 1.0.Days();

        [Fact]
        public void Equality()
        {
            Assert.Equal(60.Seconds(), 1.0.Minutes());
            Assert.Equal(60.0.Minutes(), 1.0.Hours());
            Assert.NotEqual(OneMinute, OneHour);
            Assert.NotEqual(OneHour, new object());
        }

        [Fact]
        public void Addition()
        {
            Assert.Equal(61.0.Minutes(), OneHour + OneMinute);
            Assert.Equal(25.0.Hours(), OneDay + OneHour);
        }

        [Fact]
        public void Multiplication()
        {
            Assert.Equal(2.0.Hours(), OneHour * 2);
            Assert.Equal(30.0.Minutes(), OneMinute * 30);
        }

        [Fact]
        public void Conversion()
        {
            var twoHours = 2.0.Hours();
            Assert.Equal(120, twoHours.ToMinutes());
            Assert.Equal(7200, twoHours.ToSeconds());
            Assert.Equal(2, twoHours.ToHours());
        }

        [Fact]
        public void Comparison()
        {
            Assert.True(OneHour.IsBetterThan(OneMinute));
            Assert.True(OneDay.IsBetterThan(OneHour));
        }

        [Fact]
        public void InvalidValues()
        {
            Assert.Throws<ArgumentException>(() => (-1.0).Minutes());
            Assert.Throws<ArgumentException>(() => OneHour.Multiply(-1));
        }
    }
}
