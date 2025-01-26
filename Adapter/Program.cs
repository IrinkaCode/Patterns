Console.Write("Введите массу: ");
float kg = float.Parse(Console.ReadLine()!);
float lb= kg;
IScales rScales = new RusssianScales(kg);
IScales bScales = new AdapterForBritishScales(new BritishScales(lb));
Console.WriteLine(rScales.GetWeight());
Console.WriteLine(bScales.GetWeight());

interface IScales
{
    float GetWeight();

}
class RusssianScales : IScales
{
    private float currentWeght;
    public RusssianScales(float cw) => currentWeght=cw;

    public float GetWeight() => currentWeght;
 
}
class BritishScales : IScales
{
    private float currenrweight;
    public BritishScales(float cw) => currenrweight = cw;

    public float GetWeight() => currenrweight;

}

class AdapterForBritishScales : IScales
{
    private BritishScales britishScales;
    public AdapterForBritishScales(BritishScales britishScales)
    {
        this.britishScales = britishScales;
    }
    public float GetWeight() => britishScales.GetWeight() * 0.456f;
}