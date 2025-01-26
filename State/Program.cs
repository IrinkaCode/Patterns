//паттерн состояния

TrafficLight trafficLight = new TrafficLight(new RedState());
trafficLight.NextState();
trafficLight.NextState();
trafficLight.NextState();
trafficLight.PrevState();
trafficLight.PrevState();
trafficLight.PrevState();
abstract class State
{
    protected TrafficLight trafficLight;
    public TrafficLight TrafficLight
    {
        set => this.trafficLight = value;
    }
    public abstract void NextState();
    public abstract void PrevState();
}
class TrafficLight
{
    private State state;
    public TrafficLight(State state) { SetState(state); }
    public void SetState(State st)
    {
        state = st;
        state.TrafficLight = this;
    }
    public void NextState() { state.NextState(); }
    public void PrevState() { state.PrevState(); }
}
class RedState : State
{
    public override void NextState() => Console.WriteLine("Red color");
    public override void PrevState()
    {
        Console.WriteLine("from red to yellow");
        trafficLight.SetState(new YellowState());
    }
}
class YellowState : State
{
    public override void NextState()
    {
        Console.WriteLine("from yellow to red");
        trafficLight.SetState(new RedState());
    }
    public override void PrevState()
    {
        Console.WriteLine("from yellow to green");
        trafficLight.SetState(new GreenState());
    }
}
class GreenState : State
{
    public override void NextState()
    {
        Console.WriteLine("from green to yellow");
        trafficLight.SetState(new YellowState());
    }
    public override void PrevState()
    {
        Console.WriteLine("Green color");
    }
}