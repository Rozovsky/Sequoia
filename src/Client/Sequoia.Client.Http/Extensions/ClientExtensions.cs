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

        public static IClient Body(this IClient client, object bodyContent)
        {
            client.Configuration.Body.SetBody(bodyContent);

            return client;
        }

        public static IClient Auth(this IClient client, string token)
        {
            client.Configuration.Auth.SetToken(token);

            return client;
        }
    }
}
