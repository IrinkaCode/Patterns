// Паттерн - Цепочка обязанностей

//Design designer = new Design();
//Carpenters carpenters = new Carpenters();
//Whistleblower whistleblower = new Whistleblower();

//designer.SetNextWorker(carpenters).SetNextWorker(whistleblower);
//GiveCommand(designer, "Спроектируй дизайн");
//GiveCommand(carpenters, "Стрaгай");
//GiveCommand(whistleblower, "Сделай по дизайну проекту");

//void GiveCommand(IWorker worker,string command)
//{
//    string str= worker.Execute(command);
//    if (str == "")
//    {
//        Console.WriteLine("Нет работы");
//    }

//    else Console.WriteLine(str);
//}

//interface IWorker
//{
//    IWorker SetNextWorker(IWorker worker);
//    string Execute(string command);
//}

//abstract class AbsWorker : IWorker
//{
//    private IWorker _nextWorker;

//    public AbsWorker() => _nextWorker = null;
//    public AbsWorker(IWorker worker) => _nextWorker = worker;

//    public virtual string Execute(string command)
//    {
//        if (_nextWorker == null) return _nextWorker.Execute(command);
//        return string.Empty;
//    }

//    public IWorker SetNextWorker(IWorker worker)
//    {
//        _nextWorker = worker;
//        return worker; 
//    }
//}

//class Design : AbsWorker
//{
//    public override string Execute(string command)
//    {
//        if (command == "Спроектируй дизайн") return "проектирую дизайн";
//        return base.Execute(command);
//    }
//}
//class Carpenters : AbsWorker
//{
//    public override string Execute(string command)
//    {
//        if (command == "Страгай") return "страгаю";
//        return base.Execute(command);
//    }
//}

//class Whistleblower : AbsWorker
//{
//    public override string Execute(string command)
//    {
//        if (command == "Сделай по дизайну проекту") return "делаю";
//        return base.Execute(command);
//    }
//}


//2 задача

//Architector designer = new Architector();
//Builder carpenters = new Builder();
//Electric whistleblower = new Electric();

//designer.SetNextWorker(carpenters).SetNextWorker(whistleblower);
//GiveCommand(designer, "Составить план здания");
//GiveCommand(designer, "Установка дверей");
//GiveCommand(designer, "Монтаж электропроводки");
//GiveCommand(designer, "Облицовка стен");



//void GiveCommand(IWorker worker, string command)
//{
//    string str = worker.Execute(command);
//    if (str == "")
//    {
//        Console.WriteLine("Работа прервана");
//    }
//    else Console.WriteLine(str);
//}

//interface IWorker
//{
//    IWorker SetNextWorker(IWorker worker);
//    string Execute(string command);
//}
//abstract class AbsWorker : IWorker
//{
//    private IWorker _nextWorker;
//    public AbsWorker() => _nextWorker = null;

//    public virtual string Execute(string command)
//    {
//        if (_nextWorker != null) return _nextWorker.Execute(command);
//        return string.Empty;
//    }
//    public IWorker SetNextWorker(IWorker worker)
//    {
//        _nextWorker = worker;
//        return worker;
//    }
//}
//class Architector : AbsWorker
//{
//    public override string Execute(string command)
//    {
//        if (command == "Спроектируй дизайн") return "проектирую дизайн";
//        else if (command == "Составить план здания") return "Составляю план здания";
//        return base.Execute(command);
//    }
//}
//class Builder : AbsWorker
//{
//    public override string Execute(string command)
//    {
//        if (command == "Залить фундамент") return "Заливаю фундамент";
//        else if (command == "Возвести стены") return "Возвожу стены";
//        else if (command == "Уложить кровлю") return "Укладываю кровлю";
//        return base.Execute(command);
//    }
//}
//class Electric : AbsWorker
//{
//    public override string Execute(string command)
//    {
//        if (command == "Монтаж электропроводки")
//            return "Выполняю монтаж электропроводки";
//        else if (command == "Монтаж электрооборудования")
//            return "Выполняю монтаж электрооборудования";
//        else if (command == "Монтаж розеток")
//            return "Выполняю монтаж розеток";
//        else if (command == "Монтаж осветительных приборов")
//            return "Выполняю монтаж осветительных приборов";
//        return base.Execute(command);
//    }
//}

using System;

Worker architect = new Architect();
Worker builder = new Builder();
Worker electrician = new Electrician();
Worker finisher = new Finisher();

// Устанавливаем цепочку обязанностей
architect.SetNext(builder);
builder.SetNext(electrician);
electrician.SetNext(finisher);


string[] tasks = {
            "Составить план здания",
            "Залить фундамент",
            "Монтаж электропроводки",
            "Облицовка стен",
            "Покраска",
            "Установка дверей"
        };

foreach (var task in tasks)
{
    Console.WriteLine("Новая задача: " + task);
    architect.HandleTask(task);
    Console.WriteLine();
}

// Задача, которую никто не сможет выполнить
string impossibleTask = "Неподходящая задача";
Console.WriteLine("Новая задача: " + impossibleTask);
architect.HandleTask(impossibleTask);
    
abstract class Worker
{
    protected Worker NextWorker;

    public void SetNext(Worker worker)
    {
        NextWorker = worker;
    }

    public abstract void HandleTask(string task);
}

class Architect : Worker
{
    public override void HandleTask(string task)
    {
        if (task == "Составить план здания" || task == "Оформить чертеж")
        {
            Console.WriteLine("Архитектор выполнил задачу: " + task);
        }
        else if (NextWorker != null)
        {
            NextWorker.HandleTask(task);
        }
        else
        {
            Console.WriteLine("Не удалось выполнить задачу: " + task);
        }
    }
}

class Builder : Worker
{
    public override void HandleTask(string task)
    {
        if (task == "Залить фундамент" || task == "Возвести стены" || task == "Уложить кровлю")
        {
            Console.WriteLine("Строитель выполнил задачу: " + task);
        }
        else if (NextWorker != null)
        {
            NextWorker.HandleTask(task);
        }
        else
        {
            Console.WriteLine("Не удалось выполнить задачу: " + task);
        }
    }
}

class Electrician : Worker
{
    public override void HandleTask(string task)
    {
        if (task == "Монтаж электропроводки" || task == "Монтаж электрооборудования" ||
            task == "Монтаж розеток" || task == "Монтаж осветительных приборов")
        {
            Console.WriteLine("Электрик выполнил задачу: " + task);
        }
        else if (NextWorker != null)
        {
            NextWorker.HandleTask(task);
        }
        else
        {
            Console.WriteLine("Не удалось выполнить задачу: " + task);
        }
    }
}

class Finisher : Worker
{
    public override void HandleTask(string task)
    {
        if (task == "Заливка полов" || task == "Облицовка стен" || task == "Покраска" ||
            task == "Поклейка обоев" || task == "Установка дверей" || task == "Монтаж оконных рам")
        {
            Console.WriteLine("Отделочник выполнил задачу: " + task);
        }
        else if (NextWorker != null)
        {
            NextWorker.HandleTask(task);
        }
        else
        {
            Console.WriteLine("Не удалось выполнить задачу: " + task);
        }
    }
}