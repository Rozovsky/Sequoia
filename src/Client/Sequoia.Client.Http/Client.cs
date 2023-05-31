using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sequoia.Client.Http.Configuration;
using Sequoia.Client.Http.Exceptions;
using Sequoia.Client.Http.Models;
using Sequoia.Client.Http.Options;

namespace Sequoia.Client.Http
{
    public class Client : IClient
    {
        private readonly HttpClientOptions _httpClientOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientConfiguration Configuration { get; protected set; }
        public HttpClient HttpClient { get; protected set; }

        public Client(
            IOptions<HttpClientOptions> httpClientOptions, 
            IHttpClientFactory httpClientFactory)
        {
            _httpClientOptions = httpClientOptions.Value;
            _httpClientFactory = httpClientFactory;

            HttpClient = _httpClientFactory.CreateClient();

            Configuration = new ClientConfiguration(_httpClientOptions);
        }

        private string GetUri(string path)
        {
            var uri = Configuration.Path.Uri + path + Configuration.Query.QueryString;

            return uri;
        }

        public async Task<T> Get<T>(string path, CancellationToken cancellationToken) where T : class
        {
            var response = await HttpClient.GetAsync(GetUri(path), cancellationToken);
            var responseData = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new HttpClientException(response.StatusCode, responseData);

            if (typeof(T) == typeof(Empty))
                return null;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> Get<T>(CancellationToken cancellationToken) where T : class
        {
            return await Get<T>(null, cancellationToken);
        }

        public async Task Get(string path, CancellationToken cancellationToken)
        {
            await Get<Empty>(path, cancellationToken);
        }

        public async Task Get(CancellationToken cancellationToken)
        {
            await Get<Empty>(null, cancellationToken);
        }
    }
}
