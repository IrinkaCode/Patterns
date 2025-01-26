//Паттерн стратегия
using System.Data;
using System.Threading.Channels;


ResourceReader resourceReader = new ResourceReader(new NewsSiteReader());
string url = "dzen.ru";
resourceReader.Read(url);

url = "vk.com";
resourceReader.SetStrategy(new SocialNetworkReader());
resourceReader.Read(url);

url = "Telegram channel";
resourceReader.SetStrategy(new TelegramReader());
resourceReader.Read(url);

interface IReader
{
    void Parse(string url);
}
class NewsSiteReader : IReader
{
    public void Parse(string url) => Console.WriteLine("site parse " + url);
}
class SocialNetworkReader : IReader
{
    public void Parse(string url) => Console.WriteLine("social network parse " + url);
}
class TelegramReader : IReader
{
    public void Parse(string url) => Console.WriteLine("telegram parse " + url);
}
class ResourceReader
{
    private IReader reader;
    public ResourceReader(IReader reader) => this.reader = reader;
    public void SetStrategy(IReader reader) => this.reader = reader;
    public void Read(string url) => reader.Parse(url);
}