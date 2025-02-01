// Паттерн - Цепочка обязанностей

Design designer = new Design();
Carpenters carpenters = new Carpenters();
Whistleblower whistleblower = new Whistleblower();

designer.SetNextWorker(carpenters).SetNextWorker(whistleblower);
GiveCommand(designer, "Спроектируй дизайн");
GiveCommand(carpenters, "Стрaгай");
GiveCommand(whistleblower, "Сделай по дизайну проекту");

void GiveCommand(IWorker worker,string command)
{
    string str= worker.Execute(command);
    if (str == "")
    {
        Console.WriteLine("Нет работы");
    }

    else Console.WriteLine(str);
}

interface IWorker
{
    IWorker SetNextWorker(IWorker worker);
    string Execute(string command);
}

abstract class AbsWorker : IWorker
{
    private IWorker _nextWorker;

    public AbsWorker() => _nextWorker = null;
    public AbsWorker(IWorker worker) => _nextWorker = worker;

    public virtual string Execute(string command)
    {
        if (_nextWorker == null) return _nextWorker.Execute(command);
        return string.Empty;
    }

    public IWorker SetNextWorker(IWorker worker)
    {
        _nextWorker = worker;
        return worker; 
    }
}

class Design : AbsWorker
{
    public override string Execute(string command)
    {
        if (command == "Спроектируй дизайн") return "проектирую дизайн";
        return base.Execute(command);
    }
}
class Carpenters : AbsWorker
{
    public override string Execute(string command)
    {
        if (command == "Страгай") return "страгаю";
        return base.Execute(command);
    }
}

class Whistleblower : AbsWorker
{
    public override string Execute(string command)
    {
        if (command == "Сделай по дизайну проекту") return "делаю";
        return base.Execute(command);
    }
}
