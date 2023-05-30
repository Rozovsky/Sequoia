using Newtonsoft.Json;
using System.Text;

namespace Sequoia.Client.Http
{
    public static class ClientExtensions
    {
        public static IClient Path(this IClient client, string uri)
        {
            client.Configuration.Path.SetUri(uri);

            return client;
        }

        public static IClient Query(this IClient client, object queryParams)
        {
            client.Configuration.Query.SetQueryParams(queryParams);

            return client;
        }

        public static IClient Headers(this IClient client, string key, object value)
        {
            client.Configuration.Headers.SetOrReplaceHeader(key, value);

            return client;
        }

        public static IClient Auth(this IClient client, string token)
        {
            //webClient.Configuration.WebResource = null;
            //webClient.Configuration.Segment = null;
            //webClient.Configuration.WebResourcePath = string.Empty;

            //webClient.Configuration.RequestUri = uri;

            return client;
        }

        public static IClient Auth(this IClient client) // take token from configuration or use current token
        {
            //webClient.Configuration.WebResource = null;
            //webClient.Configuration.Segment = null;
            //webClient.Configuration.WebResourcePath = string.Empty;

            //webClient.Configuration.RequestUri = uri;

            return client;
        }

        public static IClient Body(this IClient client, object payload)
        {
            // request payload
            var json = JsonConvert.SerializeObject(payload);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //webClient.Configuration.HttpContent = data;

            return client;
        }

        public static IClient Body(this IClient client, object payload, Encoding encoding, string mediaType)
        {
            // request payload
            var json = JsonConvert.SerializeObject(payload);
            var data = new StringContent(json, encoding, mediaType);

            //client.Configuration.HttpContent = data;

            return client;
        }

        public static IClient Form(this IClient client, object payload, Encoding encoding, string mediaType)
        {
            // request payload
            var json = JsonConvert.SerializeObject(payload);
            var data = new StringContent(json, encoding, mediaType);

            //client.Configuration.HttpContent = data;

            return client;
        }
    }
}
