using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.Distance;
using ExtensionMethods.Measurement;

namespace UnitTests;

public class DistanceTests
{
    private static readonly Distance OneMeter = 1.0.Meters();
    private static readonly Distance OneKiloMeter = 1.0.KiloMeters();
    private static readonly Distance OneMile = 1.0.Miles();

    [Fact]
    public void Equality()
    {
        Assert.NotEqual(OneMeter, OneKiloMeter);
        Assert.NotEqual(OneMeter, new object());
        Assert.NotEqual(OneMeter, null);
    }

    [Fact]
    public void Addition()
    {
        Assert.Equal(OneKiloMeter, OneMeter + 999.0.Meters());
    }

    [Fact]
    public void Subtraction()
    {
        Assert.Equal(OneMeter, OneKiloMeter - 999.0.Meters());
        Assert.Equal(999.0.Meters(), OneKiloMeter - OneMeter);
    }

    [Fact]
    public void Comparison()
    {
        Assert.True(OneKiloMeter.IsBetterThan(OneMeter));
        Assert.False(OneKiloMeter.IsBetterThan(OneMile));
        Assert.True(OneMile.IsBetterThan(OneKiloMeter));

    }

    [Fact]
    public void InvalidValues()
    {
        Assert.Throws<ArgumentException>(() => (-1.0).Meters());
    }

}

