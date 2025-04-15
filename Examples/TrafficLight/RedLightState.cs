namespace Examples.TrafficLight;

public class RedLightState : ITrafficLightState
{
    private const int Duration = 30;
    public void Change(TrafficLight light) => light.SetState(new YellowLightState(this));
    public TrafficLightColor GetColor() => TrafficLightColor.Red;
    public int GetDuration() => Duration;
}

public class YellowLightState(ITrafficLightState previousState) : ITrafficLightState
{
    private const int Duration = 5;
    public void Change(TrafficLight light)
    {
        if (previousState is GreenLightState) light.SetState(new RedLightState());
        if (previousState is RedLightState) light.SetState(new GreenLightState());
    }
    public TrafficLightColor GetColor() => TrafficLightColor.Yellow;
    public int GetDuration() => Duration;
}

public class GreenLightState : ITrafficLightState
{
    private const int Duration = 45;
    public void Change(TrafficLight light) => light.SetState(new YellowLightState(this));
    public TrafficLightColor GetColor() => TrafficLightColor.Green;
    public int GetDuration() => Duration;
}

public enum TrafficLightColor
{
    Red,
    Yellow,
    Green
}