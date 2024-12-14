namespace DataAccess;

public class ReadFile
{
    public static List<string>? AllLines(string path)
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

    public static string? AsText(string path)
    {
        if(File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        else
        {
            return null;
        }
    }

    public static List<string>? AllLinesFromTextFile(string path)
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
}
