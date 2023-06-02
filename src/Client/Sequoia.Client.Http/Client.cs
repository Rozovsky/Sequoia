using Newtonsoft.Json;
using Sequoia.Client.Http.Configuration;
using Sequoia.Client.Http.Exceptions;
using Sequoia.Client.Http.Extensions;
using Sequoia.Client.Http.Models;

namespace Sequoia.Client.Http
{
    public class Client : IClient
    {
        public ClientConfiguration Configuration { get; protected set; }
        public HttpClient HttpClient { get; protected set; }

        public Client(
            ClientConfiguration configuration, 
            IHttpClientFactory httpClientFactory)
        {
            HttpClient = httpClientFactory.CreateClient();
            Configuration = configuration;
        }

        #region Get

        public async Task<T> Get<T>(string path, CancellationToken cancellationToken) where T : class
        {
            var response = await HttpClient
                .ApplyConfiguration(Configuration)
                .GetAsync(Configuration.GetUri(path), cancellationToken);

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

        #endregion

        #region Post

        public async Task<T> Post<T>(string path, CancellationToken cancellationToken) where T : class
        {
            var response = await HttpClient
                .ApplyConfiguration(Configuration)
                .PostAsync(Configuration.GetUri(path), Configuration.Body.HttpContent, cancellationToken);

            var responseData = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new HttpClientException(response.StatusCode, responseData);

            if (typeof(T) == typeof(Empty))
                return null;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> Post<T>(CancellationToken cancellationToken) where T : class
        {
            return await Post<T>(null, cancellationToken);
        }

        public async Task Post(string path, CancellationToken cancellationToken)
        {
            await Post<Empty>(path, cancellationToken);
        }

        public async Task Post(CancellationToken cancellationToken)
        {
            await Post<Empty>(null, cancellationToken);
        }

        #endregion

        #region Put

        public async Task<T> Put<T>(string path, CancellationToken cancellationToken) where T : class
        {
            var response = await HttpClient
               .ApplyConfiguration(Configuration)
               .PutAsync(Configuration.GetUri(path), Configuration.Body.HttpContent, cancellationToken);

            var responseData = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new HttpClientException(response.StatusCode, responseData);

            if (typeof(T) == typeof(Empty))
                return null;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> Put<T>(CancellationToken cancellationToken) where T : class
        {
            return await Put<T>(null, cancellationToken);
        }

        public async Task Put(string path, CancellationToken cancellationToken)
        {
            await Put<Empty>(path, cancellationToken);
        }

        public async Task Put(CancellationToken cancellationToken)
        {
            await Put<Empty>(null, cancellationToken);
        }

        #endregion

        #region Delete

        public async Task<T> Delete<T>(string path, CancellationToken cancellationToken) where T : class
        {
            var response = await HttpClient
                .ApplyConfiguration(Configuration)
                .GetAsync(Configuration.GetUri(path), cancellationToken);

            var responseData = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new HttpClientException(response.StatusCode, responseData);

            if (typeof(T) == typeof(Empty))
                return null;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> Delete<T>(CancellationToken cancellationToken) where T : class
        {
            return await Delete<T>(null, cancellationToken);
        }

        public async Task Delete(string path, CancellationToken cancellationToken)
        {
            await Delete<Empty>(path, cancellationToken);
        }

        public async Task Delete(CancellationToken cancellationToken)
        {
            await Delete<Empty>(null, cancellationToken);
        }

        #endregion

        #region Patch

        public async Task<T> Patch<T>(string path, CancellationToken cancellationToken) where T : class
        {
            var response = await HttpClient
              .ApplyConfiguration(Configuration)
              .PatchAsync(Configuration.GetUri(path), Configuration.Body.HttpContent, cancellationToken);

            var responseData = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new HttpClientException(response.StatusCode, responseData);

            if (typeof(T) == typeof(Empty))
                return null;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task<T> Patch<T>(CancellationToken cancellationToken) where T : class
        {
            return await Patch<T>(null, cancellationToken);
        }

        public async Task Patch(string path, CancellationToken cancellationToken)
        {
            await Patch<Empty>(path, cancellationToken);
        }

        public async Task Patch(CancellationToken cancellationToken)
        {
            await Patch<Empty>(null, cancellationToken);
        }

        #endregion
    }
}
