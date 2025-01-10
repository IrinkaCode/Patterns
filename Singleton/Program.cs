DatabaseHelper.GetConnection().InsertData("hello");
Console.WriteLine(DatabaseHelper.GetConnection().SelectData());
//DatabaseHelper help1 = DatabaseHelper.GetConnection();
//DatabaseHelper help2 = DatabaseHelper.GetConnection();
public class DatabaseHelper
{
    private string _data;
    private static DatabaseHelper instance;

    private DatabaseHelper() => Console.WriteLine("connect to database");
    public static DatabaseHelper GetConnection()
    {
        if(instance == null)
            instance = new DatabaseHelper();
        return instance;
    }
    public string SelectData()=> _data;
    public void InsertData(string d) => _data = d;  
}