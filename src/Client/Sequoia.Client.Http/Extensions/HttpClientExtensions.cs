using Sequoia.Client.Http.Configuration;

namespace Sequoia.Client.Http.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient ApplyConfiguration(this HttpClient httpClient, ClientConfiguration configuration)
        {
            // headers
            if (configuration.Headers.HeadersCollection.Count > 0)
            {
                foreach (var header in configuration.Headers.HeadersCollection)
                {
                    if (httpClient.DefaultRequestHeaders.Any(c => c.Key == header.Key))
                        httpClient.DefaultRequestHeaders.Remove(header.Key);

                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            // auth
            if (!string.IsNullOrEmpty(configuration.Auth.Token))
            {
                var key = "Authorization";
                if (httpClient.DefaultRequestHeaders.Any(c => c.Key == key))
                    httpClient.DefaultRequestHeaders.Remove(key);

                httpClient.DefaultRequestHeaders.Add(key, configuration.Auth.Token);
            }

            return httpClient;
        }
    }
}
