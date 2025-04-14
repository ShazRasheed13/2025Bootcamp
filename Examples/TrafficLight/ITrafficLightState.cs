namespace Examples.TrafficLight;

public interface ITrafficLightState
{
    void Change(TrafficLight light);
    TrafficLightColor GetColor();
    int GetDuration();
}