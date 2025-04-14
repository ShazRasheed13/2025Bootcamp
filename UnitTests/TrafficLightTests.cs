using Examples.TrafficLight;

namespace UnitTests;

public class TrafficLightTests
{
    private readonly TrafficLight _light = new TrafficLight();

    [Fact]
    public void TrafficLight_StartsWithRed()
    {
        Assert.Equal(TrafficLightColor.Red, _light.GetCurrentColor());
        Assert.Equal(30, _light.GetCurrentDuration());
    }

    [Fact]
    public void RedLight_ChangesToGreen()
    {
        _light.Change();
        Assert.Equal(TrafficLightColor.Yellow, _light.GetCurrentColor());
        Assert.Equal(5, _light.GetCurrentDuration());
        
        _light.Change();
        Assert.Equal(TrafficLightColor.Green, _light.GetCurrentColor());
        Assert.Equal(45, _light.GetCurrentDuration());
    }

    [Fact]
    public void GreenLight_ChangesToYellow()
    {
        _light.Change();
        _light.Change();
        Assert.Equal(TrafficLightColor.Green, _light.GetCurrentColor());
        Assert.Equal(45, _light.GetCurrentDuration());
        
        _light.Change();
        Assert.Equal(TrafficLightColor.Yellow, _light.GetCurrentColor());
        Assert.Equal(5, _light.GetCurrentDuration());
    }

    [Fact]
    public void YellowLight_ChangesToRed()
    {
        _light.Change();
        _light.Change();
        _light.Change();
        Assert.Equal(TrafficLightColor.Yellow, _light.GetCurrentColor());
        Assert.Equal(5, _light.GetCurrentDuration());
        
        _light.Change();
        Assert.Equal(TrafficLightColor.Red, _light.GetCurrentColor());
        Assert.Equal(30, _light.GetCurrentDuration());
    }

    [Fact]
    public void CompleteTrafficLightCycle()
    {
        Assert.Equal(TrafficLightColor.Red, _light.GetCurrentColor());
        _light.Change();
        Assert.Equal(TrafficLightColor.Yellow, _light.GetCurrentColor());

        _light.Change();
        Assert.Equal(TrafficLightColor.Green, _light.GetCurrentColor());

        _light.Change();
        Assert.Equal(TrafficLightColor.Yellow, _light.GetCurrentColor());
    }
}