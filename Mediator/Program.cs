////Паттерн посредник(Mediator)

//Designer designer = new Designer();
//Director director = new Director();
//Controller mediator = new Controller(designer,director);

//director.GiveCommand("Дизайн");
//designer.ExucuteWork();

//interface IMediator
//{
//    void Notify(Employee employee, string msg);
//}
//abstract class Employee
//{
//    protected IMediator Mediator;
//    public Employee(IMediator mediator)=> Mediator = mediator;  
//    public void SetMediator(IMediator mediator) => Mediator = mediator;
//}
//class Designer : Employee
//{
//    public Designer(IMediator mediator=null!) : base(mediator) { }
//    public void ExucuteWork()
//    {
//        Console.WriteLine("Дизайнер сделал работу");
//        Mediator.Notify(this, "Дизайн готов");
//    }
//    public void SetWork(bool state)
//    {
//        if (state) Console.WriteLine("Дизайнер делает работу");
//        else Console.WriteLine("Дизайнер работает");
//    }
//}
//class Director:Employee
//{
//    private string text;

//    public Director(IMediator mediator = null) : base(mediator) { }
//    public void GiveCommand(string _text)
//    {
//        text = _text;
//        if (text == "") Console.WriteLine("Директор знает,что дизайнер работает");
//        else Console.WriteLine("Директор дает задачу:" + text);
//        Mediator.Notify(this,text);
//    }
//}
//class Controller : IMediator
//{
//    private Designer designer;
//    private Director director;
//    public Controller(Designer designer, Director director)
//    {
//        this.designer = designer;
//        this.director = director;
//        designer.SetMediator(this);
//        director.SetMediator(this);
//    }

//    public void Notify(Employee employee, string msg)
//    {
//        if(employee is Director)
//        {
//            if(msg=="") designer.SetWork(false);
//            else designer.SetWork(true);
//        }
//        else if (employee is Designer)
//        {
//            if (msg.StartsWith("Делаю дизайн"))
//                director.GiveCommand("");
//        }
//    }
//}



using System;

Officiant officiant = new Officiant();
Povar povar = new Povar();
Deployment deployment = new Deployment();

Kassir mediator = new Kassir(officiant, povar, deployment);

officiant.ExecuteWork("Заказ блюда");
povar.ExecuteWork();
deployment.ExecuteWork();

interface IMediator
{
    void Notify(Employee employee, string msg);
}

abstract class Employee
{
    protected IMediator Mediator;

    public Employee(IMediator mediator) => Mediator = mediator;
    public void SetMediator(IMediator mediator) => Mediator = mediator;
}

class Officiant : Employee
{
    public Officiant(IMediator mediator = null!) : base(mediator) { }

    public void ExecuteWork(string work)
    {
        Console.WriteLine("Официант передал кассиру: " + work);
        Mediator.Notify(this, work);
    }

    public void SetWork(bool state)
    {
        if (state) Console.WriteLine("Официант занят");
        else Console.WriteLine("Официант свободен");
    }
}

class Povar : Employee
{
    public Povar(IMediator mediator = null!) : base(mediator) { }

    public void GiveCommand(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Заказа нет");
        }
        else
        {
            Console.WriteLine("Нужно заказать: " + text);
            Mediator.Notify(this, text);
        }
    }

    public void ExecuteWork()
    {
        Console.WriteLine("Повар выполняет работу...");
    }
}

class Deployment : Employee
{
    public Deployment(IMediator mediator = null!) : base(mediator) { }

    public void ExecuteWork()
    {
        Console.WriteLine("Поставщик выполняет работу...");
    }

    public void ReceiveOrder(string order)
    {
        Console.WriteLine("Поставщик принял заказ: " + order);
    }
}

class Kassir : IMediator
{
    private Officiant officiant;
    private Povar povar;
    private Deployment deployment;

    public Kassir(Officiant officiant, Povar povar, Deployment deployment)
    {
        this.officiant = officiant;
        this.povar = povar;
        this.deployment = deployment;

        officiant.SetMediator(this);
        povar.SetMediator(this);
        deployment.SetMediator(this);
    }

    public void Notify(Employee employee, string msg)
    {
        if (employee is Officiant)
        {
            Console.WriteLine("Кассир получил заказ от официанта: " + msg);
            povar.GiveCommand(msg);
        }
        else if (employee is Povar)
        {
            Console.WriteLine("Повар получил сообщение от кассира: " + msg);
            deployment.ReceiveOrder(msg); 
        }
        else if (employee is Deployment)
        {
            Console.WriteLine("Поставщик получил сообщение от повара: " + msg);
        }
    }
}


