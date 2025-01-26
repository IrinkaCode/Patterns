// Паттерн наблюдатель           

Product product = new Product(400);
Wholesale wholesale = new Wholesale(product);
Buyer buyer = new Buyer(product);
product.ChangePrice(320);
product.ChangePrice(280);
interface IObserver
{
    void Update(double p);
}
interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void Notify();
}
class Product : IObservable
{
    private List<IObserver> observers;
    private double price;
    public Product(double price)
    {
        this.price = price;
        observers = new List<IObserver>();
    }
    public void AddObserver(IObserver observer) => observers.Add(observer);
    public void Notify()
    {
        foreach (var item in observers.ToList())
        {
            item.Update(price);
        }
    }
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);
    public void ChangePrice(double p)
    {
        price = p;
        Notify();
    }
}

class Wholesale : IObserver
{
    private IObservable product;
    public Wholesale(IObservable obj)
    {
        product = obj;
        obj.AddObserver(this);
    }
    public void Update(double p)
    {
        if (p < 300)
        {
            Console.WriteLine("Не оптовый покупатель");
            product.RemoveObserver(this);
        }
    }
}
class Buyer : IObserver
{
    private IObservable product;
    public Buyer(IObservable obj)
    {
        product = obj;
        obj.AddObserver(this);
    }
    public void Update(double p)
    {
        if (p < 350)
        {
            Console.WriteLine("Не покупатель");
            product.RemoveObserver(this);
        }
    }
}