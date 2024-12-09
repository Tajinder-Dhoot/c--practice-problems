namespace DataAccess;

public class ReadFile
{
    public static List<string>? Read(string path)
    {
        if(File.Exists(path))
        {
            return [.. File.ReadAllLines(path)];
        }
        else
        {
            return null;
        }
    }

    public static void PrintData(string path, string message)
    {
        List<string>? data = Read(path);
        if(data != null)
        {
            Console.WriteLine(message);
            foreach (var line in data)
            {
                Console.WriteLine(line);
            }
        }
    }
}
