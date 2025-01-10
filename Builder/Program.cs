IDeveloper androidDeveloper = new AndroidDeveloper();
Director director = new Director(androidDeveloper);
Phone samsung = director.MountFullPhone();
Console.WriteLine(samsung.AboutPhone());

IDeveloper iphoneDeveloper = new IPhoneDeveloper();
director.SetDeveloper(iphoneDeveloper);
Phone iphone = director.MountOnlyPhone();
Console.WriteLine(iphone.AboutPhone());

class Phone
{
    private string data;
    public Phone() => data = "";
    public string AboutPhone() => data;
    public void AppendData(string str) => data += str;

}
interface IDeveloper
{
    void CreateDisplay();
    void CreateBox();
    void SystemInstall();
    Phone GetPhone();
}

class AndroidDeveloper : IDeveloper
{
    private Phone phone;
    public void CreateBox()=>phone = new Phone();
    public void CreateDisplay() => phone.AppendData(" (create) display Samsung");
    public Phone GetPhone()=>phone;
    public void SystemInstall() => phone.AppendData(" install Android");
}

class IPhoneDeveloper : IDeveloper
{
    private Phone phone;
    public void CreateBox() => phone = new Phone();
    public void CreateDisplay() => phone.AppendData(" (create) display Apple");
    public Phone GetPhone() => phone;
    public void SystemInstall() => phone.AppendData(" install IOS");
}

class Director
{
    private IDeveloper developer;

    public Director(IDeveloper developer) => this.developer = developer;
    public void SetDeveloper(IDeveloper developer) => this.developer = developer;
    public Phone MountOnlyPhone()
    {
        developer.CreateBox();
        developer.CreateDisplay();
        return developer.GetPhone();
    }
    public Phone MountFullPhone()
    {
        developer.CreateBox();
        developer.CreateDisplay();
        developer.SystemInstall();
        return developer.GetPhone();
    }
}