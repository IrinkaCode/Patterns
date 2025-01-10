IworkShop creator = new CarWorkShop();
IProduction car = creator.Create();
creator = new TruckWorkShop();
IProduction track = creator.Create();
car.Release();
track.Release();
interface IProduction
{
    void Release();
}
class Car:IProduction
{
    public void Release() =>  Console.WriteLine("Car");


}

class Truck:IProduction
{
    public void Release() =>  Console.WriteLine("Truck");



}
interface IworkShop
{
    IProduction Create();
}
class CarWorkShop : IworkShop
{
    public IProduction Create() => new Car();
}
class TruckWorkShop : IworkShop
{
    public IProduction Create() => new Truck();
}