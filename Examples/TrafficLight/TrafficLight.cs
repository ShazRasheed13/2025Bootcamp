namespace Examples.TrafficLight;

public class TrafficLight
{
    private ITrafficLightState _currentState = new RedLightState();

    public void Change() => _currentState.Change(this);
    internal void SetState(ITrafficLightState newState) => _currentState = newState;
    public TrafficLightColor GetCurrentColor() => _currentState.GetColor();
    public int GetCurrentDuration() => _currentState.GetDuration();
    
}