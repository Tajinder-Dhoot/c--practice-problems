using System.Text.Json;

namespace DataAccess;

public class WriteFile
{
    public static void AppendTotextFile(string filepath, string? content)
    {
        if(content != null)
        {
            File.AppendAllText(filepath, content + Environment.NewLine);
        }
    }

    public static void AppendToJsonFile(string filepath, string? content)
    {
        if(content != null)
        {
            string jsonString = File.ReadAllText(filepath);
            var data = JsonSerializer.Deserialize<List<string>>(jsonString);
            data.Add(content);
            jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filepath, jsonString);
        }
    }
}
