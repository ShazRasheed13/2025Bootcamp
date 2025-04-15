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
    private static readonly Distance _oneMeter = 1.0.Meters();
    private static readonly Distance _oneKiloMeter = 1.0.KiloMeters();
    private static readonly Distance _oneMile = 1.0.Miles();

    [Fact]
    public void Equality()
    {
        Assert.NotEqual(_oneMeter, _oneKiloMeter);
        Assert.NotEqual(_oneMeter, new object());
        Assert.NotEqual(_oneMeter, null);
    }

    [Fact]
    public void Addition()
    {
        Assert.Equal(_oneKiloMeter, _oneMeter + 999.0.Meters());
    }

    [Fact]
    public void Subtraction()
    {
        Assert.Equal(_oneMeter, _oneKiloMeter - 999.0.Meters());
    }

    [Fact]
    public void Comparison()
    {
        Assert.True(_oneKiloMeter.IsBetterThan(_oneMeter));
        Assert.False(_oneKiloMeter.IsBetterThan(_oneMile));
        Assert.True(_oneMile.IsBetterThan(_oneKiloMeter));

    }

    [Fact]
    public void InvalidValues()
    {
        Assert.Throws<ArgumentException>(() => (-1.0).Meters());
    }

}

