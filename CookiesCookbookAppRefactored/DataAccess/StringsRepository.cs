namespace CookiesCookbookAppRefactored.DataAccess;

public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToStrings(fileContents);
        }
        return [];
    }

    public void Write(string filepath, List<string> strings)
    {
        File.WriteAllText(filepath, StringsToText(strings));
    }

    protected abstract List<string> TextToStrings(string fileContents);

    protected abstract string StringsToText(List<string> strings);
}
