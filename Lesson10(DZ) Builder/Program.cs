//Задача: Создание диаграммы классов для приготовления супа с помощью паттерна
//Builder
//Вам предлагается создать диаграмму классов для процесса приготовления супа в ресторане, используя паттерн Builder.
//Каждый суп представлен отдельным строителем, определяющим ингредиенты и этапы приготовления.
//Класс SoupChef действует как директор, управляя процессом приготовления, а класс Soup представляет готовый суп с добавленными ингредиентами и прошедшими этапами.

ISoupBuilder soupBuilder = new VegetableSoupBuilder();
SoupChef chef = new SoupChef(soupBuilder);
Soup Vegatable = chef.MakeSoup();
Console.WriteLine(Vegatable.GetCookingSteps());

class Soup
{
    public List<string> Ingredients { get; private set; } = new List<string>();
    public string CookingSteps { get; private set; } = "";

    public void AddIngredient(string ingredient) => Ingredients.Add(ingredient);
    public void SetCookingSteps(string steps) => CookingSteps = steps;
    public string GetCookingSteps() => CookingSteps;
}

interface ISoupBuilder
{
    void AddVegetables();
    void AddBroth();
    void Cook();
    Soup GetSoup();
}

class VegetableSoupBuilder : ISoupBuilder
{
    private Soup _soup = new Soup();

    public void AddVegetables()
    {
        _soup.AddIngredient("Carrots");
        _soup.AddIngredient("Potatoes");
    }

    public void AddBroth() => _soup.AddIngredient("Vegetable Broth");

    public void Cook() => _soup.SetCookingSteps("Cook for 30 minutes.");

    public Soup GetSoup() => _soup;

}

// Директор
class SoupChef
{
    private ISoupBuilder _builder;

    public SoupChef(ISoupBuilder builder) => _builder = builder;

    public Soup MakeSoup()
    {
        _builder.AddVegetables();
        _builder.AddBroth();
        _builder.Cook();
        return _builder.GetSoup();
    }

    public Soup GetSoup() => _builder.GetSoup();
}
