using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sequoia.Data.WebClient.Enums;
using Sequoia.Data.WebClient.Helpers;
using Sequoia.Data.WebClient.Interfaces;
using Sequoia.Data.WebClient.Models;
using Sequoia.Data.WebClient.Options;
using Sequoia.Exceptions;

namespace Sequoia.Data.WebClient.Services
{
    public class WebClientEngine : IWebClient, IWebClientEngine
    {
        private readonly WebResourcesOptions _webResourcesOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public WebClientConfiguration Configuration { get; private set; }
        public HttpClient HttpClient { get; protected set; }

        public WebClientEngine(
            IOptions<WebResourcesOptions> webResourcesOptions,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _webResourcesOptions = webResourcesOptions.Value;
            _httpClientFactory = httpClientFactory;

            Configuration = new WebClientConfiguration
            {
                ErrorHandlingMode = ErrorHandlingMode.Ignore,
                IgnoreSslErrors = true,
                HttpContext = httpContextAccessor.HttpContext
            };

            HttpClient = _httpClientFactory.CreateClient();
        }

        public void SetWebResource(string webResourcePath)
        {
            var webResourcePathSplitted = webResourcePath.Split('/');

            if (webResourcePathSplitted.Length != 2)
                throw new Exception("WebResourcePath is invalid");

            // get resource settings
            Configuration.WebResource = _webResourcesOptions.Resources.FirstOrDefault(c => c.Name == webResourcePathSplitted[0]);
            if (Configuration.WebResource == null)
                throw new NotFoundException($"Resource {webResourcePathSplitted[0]} not found in resources collection");

            // get segment settings
            Configuration.Segment = Configuration.WebResource.Segments.FirstOrDefault(c => c.Name == webResourcePathSplitted[1]);
            if (Configuration.Segment == null)
                throw new NotFoundException($"Segment {webResourcePathSplitted[1]} not found in resource {Configuration.WebResource.Name} segments collection");

            Configuration.RequestUri = Configuration.WebResource.Host + Configuration.Segment.Url;
        }

        public void SetNoSslValidation()
        {
            HttpClient = _httpClientFactory.CreateClient("no-ssl-validation");
        }

        public async Task<HttpResponseMessage> HttpRequest(HttpRequestType type, string endpoint, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            // get response
            var url = Configuration.RequestUri + endpoint + Configuration.QueryString;

            switch (type)
            {
                case HttpRequestType.Get:
                    response = await HttpClient.GetAsync(url, cancellationToken);
                    break;

                case HttpRequestType.Post:
                    response = await HttpClient.PostAsync(url, Configuration.HttpContent, cancellationToken);
                    break;

                case HttpRequestType.Put:
                    response = await HttpClient.PutAsync(url, Configuration.HttpContent, cancellationToken);
                    break;

                case HttpRequestType.Delete:
                    response = await HttpClient.DeleteAsync(url, cancellationToken);
                    break;
            }

            // process response
            if (!response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync(cancellationToken);
                return ErrorHandlerHelper.HandleError(response, responseData, Configuration.ErrorHandlingMode) as HttpResponseMessage;
            }

            return response;
        }

        #region Get

        /// <summary>
        /// GET as T result
        /// </summary>
        public async Task<T> Get<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            var requestResult = await this.HttpRequest(HttpRequestType.Get, endpoint, cancellationToken);

            if (typeof(T) == typeof(Stream))
            {
                return await requestResult.Content.ReadAsStreamAsync(cancellationToken) as T;
            }
            else
            {
                var responseData = await requestResult.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<T>(responseData);
            }
        }

        /// <summary>
        /// GET with empty result
        /// </summary>
        public async Task Get(string endpoint, CancellationToken cancellationToken)
        {
            await this.HttpRequest(HttpRequestType.Get, endpoint, cancellationToken);
        }

        #endregion

        #region Post

        /// <summary>
        /// POST with T as result 
        /// </summary>
        public async Task<T> Post<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            var requestResult = await this.HttpRequest(HttpRequestType.Post, endpoint, cancellationToken);

            if (typeof(T) == typeof(Stream))
            {
                return await requestResult.Content.ReadAsStreamAsync(cancellationToken) as T;
            }
            else
            {
                var responseData = await requestResult.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<T>(responseData);
            }
        }

        public async Task Post(string endpoint, CancellationToken cancellationToken)
        {
            await this.HttpRequest(HttpRequestType.Post, endpoint, cancellationToken);
        }

        #endregion

        #region Put

        public async Task<T> Put<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            var requestResult = await this.HttpRequest(HttpRequestType.Put, endpoint, cancellationToken);

            if (typeof(T) == typeof(Stream))
            {
                return await requestResult.Content.ReadAsStreamAsync(cancellationToken) as T;
            }
            else
            {
                var responseData = await requestResult.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<T>(responseData);
            }
        }

        public async Task Put(string endpoint, CancellationToken cancellationToken)
        {
            await this.HttpRequest(HttpRequestType.Put, endpoint, cancellationToken);
        }

        #endregion

        #region Delete

        public async Task<T> Delete<T>(string endpoint, CancellationToken cancellationToken) where T : class
        {
            // delete response
            var url = Configuration.RequestUri + endpoint + Configuration.QueryString;

            HttpResponseMessage response;
            if (Configuration.HttpContent == null)
            {
                response = await HttpClient.DeleteAsync(url, cancellationToken);
            }
            else
            {
                response = await HttpClient.SendAsync(
                    new HttpRequestMessage(HttpMethod.Delete, url)
                    {
                        Content = Configuration.HttpContent
                    },
                cancellationToken);
            }

            var responseData = await response.Content.ReadAsStringAsync(cancellationToken);

            // process response
            if (!response.IsSuccessStatusCode)
                return ErrorHandlerHelper.HandleError(response, responseData, Configuration.ErrorHandlingMode) as T;

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public async Task Delete(string endpoint, CancellationToken cancellationToken)
        {
            await this.HttpRequest(HttpRequestType.Delete, endpoint, cancellationToken);
        }

        #endregion
    }
}
