
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIApp;
public interface IAPIDataReader
{
    Task<string> READ(string baseUrl, string requestUri);
}

public class APIDataReader : IAPIDataReader
{
    public async Task<string> READ(string baseUrl, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        HttpResponseMessage response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public record Annotations(
    [property: JsonPropertyName("source_name")] string source_name,
    [property: JsonPropertyName("source_description")] string source_description,
    [property: JsonPropertyName("dataset_name")] string dataset_name,
    [property: JsonPropertyName("dataset_link")] string dataset_link,
    [property: JsonPropertyName("table_id")] string table_id,
    [property: JsonPropertyName("topic")] string topic,
    [property: JsonPropertyName("subtopic")] string subtopic
);

public record Datum(
    [property: JsonPropertyName("ID Nation")] string IDNation,
    [property: JsonPropertyName("Nation")] string Nation,
    [property: JsonPropertyName("ID Year")] int IDYear,
    [property: JsonPropertyName("Year")] string Year,
    [property: JsonPropertyName("Population")] int Population,
    [property: JsonPropertyName("Slug Nation")] string SlugNation
);

public record Root(
    [property: JsonPropertyName("data")] IReadOnlyList<Datum> data,
    [property: JsonPropertyName("source")] IReadOnlyList<Source> source
);

public record Source(
    [property: JsonPropertyName("measures")] IReadOnlyList<string> measures,
    [property: JsonPropertyName("annotations")] Annotations annotations,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("substitutions")] IReadOnlyList<object> substitutions
);

public class Program
{
    public static async Task Main()
    {
        IAPIDataReader dataReader = new APIDataReader();
        string baseUrl = "https://datausa.io/";
        string requestUri = "api/data?drilldowns=Nation&measures=Population";
        string response = await dataReader.READ(baseUrl, requestUri);

        Console.WriteLine(response);
        Root root = JsonSerializer.Deserialize<Root>(response);

        foreach (var yearlydata in root.data)
        {
            Console.WriteLine($"Year:  {yearlydata.Year}, population: {yearlydata.Population}");
        }
    }
}

