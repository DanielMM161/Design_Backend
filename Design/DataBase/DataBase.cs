using System.Text.Json;

namespace Design.DataBase
{
  public static class DataBaseHelper
  {

    private static string FilePath(string path)
    {      
      return $"{Environment.CurrentDirectory}/FakeData/{path}.json";
    }

    public static T GetData<T>(string path)
    {
      string jsonData = File.ReadAllText(FilePath(path));
      return JsonSerializer.Deserialize<T>(jsonData);
    }

    public static List<T> GetListData<T>(string path)
    {
      string jsonData = File.ReadAllText(path);
      return JsonSerializer.Deserialize<List<T>>(jsonData);
    }

    public static bool WriteJsonData<T>(T value, string path)
    {
      try
      {
        var jsonData = JsonSerializer.Serialize<T>(value);
        File.WriteAllText(FilePath(path), jsonData);
      } catch(Exception e)
      {
        Console.WriteLine($"Exception WriteJsonData in {path}: {e.Message}", e.Source);   
        return false;
      }
      return true;
    }
  }
}