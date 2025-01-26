Transmitter transmitter = new Transmitter("12345");
transmitter.Process();
Shell hamingCode = new HammingCode(transmitter);
hamingCode.Process();
Shell encoder = new Encrypt(transmitter);
encoder.Process();

interface IProcessor
{
    void Process();

}
class Transmitter : IProcessor
{
    private string data;

    public Transmitter(string data) => this.data = data;
    public void Process() => Console.WriteLine("Данные " + data + " " + "передаем по каналу");

}
abstract class Shell : IProcessor
{
    protected IProcessor Processor;

    protected Shell(IProcessor processor) => Processor = processor;

    public virtual void Process() => Processor.Process();
}
class HammingCode : Shell
{
    public HammingCode(IProcessor processor) : base(processor)
    {

    }
    public override void Process()
    {
        Console.WriteLine("Кодирование методом Хэминга было выполнено!");
        Processor.Process();
    }
}
class Encrypt : Shell
{
    public Encrypt(IProcessor processor) : base(processor)
    {

    }
    public override void Process()
    {
        Console.WriteLine("Данные зашифрованы");
        Processor.Process();
    }
}


//дописать из гитхаба
