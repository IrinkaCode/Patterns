using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
void People_CollectionChanged(object? sender,
    NotifyCollectionChangedEventArgs e)
{
    switch (e.Action)
    {
        case NotifyCollectionChangedAction.Add:
            if (e.NewItems?[0] is Person newPerson)
                Console.WriteLine($"Добавлен новый объект:{newPerson.Name}");
            break;
        case NotifyCollectionChangedAction.Remove:
            if (e.OldItems?[0] is Person oldPerson)
                Console.WriteLine($"Удален объект:{oldPerson.Name}");
            break;
        case NotifyCollectionChangedAction.Replace:
            if ((e.NewItems?[0] is Person replacingPerson) &&
                (e.OldItems?[0] is Person replacedPerson))
                Console.WriteLine($"Объект:{replacedPerson.Name} заменен " +
                    $"{replacingPerson.Name}");
            break;
    }
}
var people = new ObservableCollection<Person>()
{
    new Person("Tom"),
    new Person("Jerry")
};
people.CollectionChanged += People_CollectionChanged;
people.Add(new Person("Bob"));
people.RemoveAt(1);
people[0] = new Person("Sam");
Console.WriteLine("Список пользователей:");
foreach (var item in people) Console.WriteLine(item.Name);
class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}
