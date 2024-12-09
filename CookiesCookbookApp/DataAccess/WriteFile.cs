namespace DataAccess;

public class WriteFile
{
    public static void Write(string filepath, string? content)
    {
        if(content != null)
        {
            File.AppendAllText(filepath, content + Environment.NewLine);
        }
    }
}
