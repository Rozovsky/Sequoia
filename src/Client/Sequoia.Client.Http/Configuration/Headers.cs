namespace Sequoia.Client.Http.Configuration;

public class Headers
{
    public Dictionary<string, string> HeadersCollection { get; set; } = new();

    protected internal void SetOrReplaceHeader(string key, string value)
    {
        if (HeadersCollection.Any(c => c.Key == key))
            HeadersCollection.Remove(key);

        HeadersCollection.Add(key, value);
    }
}