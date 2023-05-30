namespace Sequoia.Client.Http.Configuration
{
    public class Headers
    {
        public Dictionary<string, object> HeadersCollection { get; set; }

        protected internal void SetOrReplaceHeader(string key, object value)
        {
            if (HeadersCollection.Any(c => c.Key == key))
                HeadersCollection.Remove(key);

            HeadersCollection.Add(key, value);
        }
    }
}
