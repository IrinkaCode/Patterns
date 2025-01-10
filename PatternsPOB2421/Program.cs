//Абстрактная фабрика
using System.Threading.Channels;

IFactory jfactory = new JapaneseFactory();
IEngine jEngine = jfactory.CreateEngine();
ICar jCar = jfactory.CreateCar();
jCar.ReleaseCar(jEngine);

IFactory rfactory = new RussianFactory();
IEngine rEngine = rfactory.CreateEngine();
ICar rCar = rfactory.CreateCar();
rCar.ReleaseCar(rEngine);
interface IEngine
{
    void ReleaseEngine();

}
class JapaneseEngine:IEngine
{
    public void ReleaseEngine() => Console.WriteLine("Японский инженер");

}
class RussianEngine : IEngine
{
    public void ReleaseEngine() => Console.WriteLine("Русский инженер");

}
interface ICar
{
    void ReleaseCar(IEngine engine);
}
class JapaneseCar:ICar
{
    public void ReleaseCar(IEngine engine)
    {
        Console.WriteLine("Make Toyota");
        engine.ReleaseEngine();
    }
}
class RussianCar : ICar
{
    public void ReleaseCar(IEngine engine)
    {
        Console.WriteLine("Make Lada");
        engine.ReleaseEngine();
    }
}
interface IFactory
{
    IEngine CreateEngine();
    ICar CreateCar();
}

class JapaneseFactory : IFactory
{
    public ICar CreateCar() => new JapaneseCar();
    public IEngine CreateEngine() => new JapaneseEngine();
}
class RussianFactory : IFactory
{
    public ICar CreateCar() => new RussianCar();
    public IEngine CreateEngine() => new RussianEngine();
}