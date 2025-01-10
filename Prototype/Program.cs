IAnimal sheepDonor = new Sheep();
sheepDonor.SetName("sheep");
IAnimal sheepClone = sheepDonor.Clone();
Console.WriteLine(sheepDonor.GetName());
Console.WriteLine(sheepClone.GetName());

interface IAnimal
{
    void SetName(string name);
    string GetName();
    IAnimal Clone();
}
class Sheep : IAnimal
{
    private string _name;
    public Sheep() { }
    public Sheep(Sheep donor)=> this._name=donor._name;
    public IAnimal Clone() => new Sheep(this); 
    public string GetName() => _name;
    public void SetName(string name)=>this._name=name;
}
