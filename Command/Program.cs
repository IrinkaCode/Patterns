//паттерн команда

Convoyer convoyer = new Convoyer();
Multipult multipult = new Multipult();
multipult.SetCommand(0, new ConveyerWorkCommand(convoyer));
multipult.SetCommand(1, new ConveyerAdjustCommand(convoyer));
multipult.PressOn(0);
multipult.PressOn(1);
multipult.PressCancel();
multipult.PressCancel();

interface ICommand
{
    void Positive();
    void Negative();
}
class Convoyer
{
    public void On() => Console.WriteLine("the pipeline is running");
    public void Off() => Console.WriteLine("the conveyer is stop");
    public void SpeedIncrase() => Console.WriteLine("increised conveyer speed");
    public void SpeedDecrase() => Console.WriteLine("decraised conveyer speed");
}
class ConveyerWorkCommand : ICommand
{
    private Convoyer convoyer;
    public ConveyerWorkCommand(Convoyer convoyer) =>
        this.convoyer = convoyer;
    public void Negative() => convoyer.Off();
    public void Positive() => convoyer.On();
}
class ConveyerAdjustCommand : ICommand
{
    private Convoyer convoyer;
    public ConveyerAdjustCommand(Convoyer convoyer) => this.convoyer = convoyer;
    public void Negative() => convoyer.SpeedDecrase();
    public void Positive() => convoyer.SpeedIncrase();
}
class Multipult
{
    private List<ICommand>? commands;
    private Stack<ICommand>? history;
    public Multipult()
    {
        commands = new List<ICommand>() { null, null };
        history = new Stack<ICommand>();
    }
    public void SetCommand(int button, ICommand command) => commands[button] = command;
    public void PressOn(int button)
    {
        commands[button].Positive();
        history.Push(commands[button]);
    }
    public void PressCancel()
    {
        if (history.Count != 0) history.Pop().Negative();
    }
}