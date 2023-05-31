using Sequoia.Client.Http.Options;

namespace Sequoia.Client.Http.Configuration
{
    public class ClientConfiguration
    {
        public Auth Auth { get; set; }
        public Body Body { get; set; }
        public Path Path { get; set; }
        public Query Query { get; set; }
        public Headers Headers { get; set; }

        public ClientConfiguration(HttpClientOptions httpClientOptions)
        {
            Auth = new Auth(httpClientOptions.Resources);
            Body = new Body();
            Path = new Path(httpClientOptions.Resources);
            Query = new Query();
            Headers = new Headers();
        }
    }
}
