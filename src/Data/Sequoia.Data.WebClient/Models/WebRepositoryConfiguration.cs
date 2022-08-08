using Sequoia.Data.WebClient.Interfaces;

namespace Sequoia.Data.WebClient.Models
{
    public class WebRepositoryConfiguration : IWebRepositoryConfiguration
    {
        public IWebClient WebClient { get; set; }

        public string EndpointGetAll { get; set; }
        public string EndpointGetAllPaged { get; set; }
        public string EndpointGetById { get; set; }
    }
}
