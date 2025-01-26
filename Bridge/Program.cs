using System.Threading.Channels;

Sender sender = new EMailSender(new DataBaseReader());
sender.Send();
sender.SetDataReader(new FileReader());
sender.Send();
sender = new TelegramBotSender(new DataBaseReader());
sender.Send();

interface IDataReader
{
    void Read();

}
class DataBaseReader : IDataReader
{
    public void Read() => Console.WriteLine("Данные с БД");

}
class FileReader : IDataReader
{
    public void Read() => Console.WriteLine("Данные с файла");
}

abstract class Sender
{
    protected IDataReader reader;

    protected Sender(IDataReader reader) => this.reader = reader;
    public void SetDataReader(IDataReader _reader)=>reader = _reader;
    public abstract void Send();

}
class EMailSender : Sender
{
    public EMailSender(IDataReader reader) : base(reader) { }
    public override void Send()
    {
       reader.Read();
        Console.WriteLine("send by email");
    }
}
class TelegramBotSender : Sender
{
    public TelegramBotSender(IDataReader reader): base(reader) { }
    public override void Send()
    {
        reader.Read();
        Console.WriteLine("send by telegram bot");
    }
}