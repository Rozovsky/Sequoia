using Microsoft.AspNetCore.Http;
using Sequoia.Data.WebClient.Enums;
using Sequoia.Data.WebClient.Interfaces;
using Sequoia.Data.WebClient.Options;

namespace Sequoia.Data.WebClient.Models
{
    public class WebClientConfiguration : IWebClientConfiguration
    {
        public string WebResourcePath { get; set; }
        public ErrorHandlingMode ErrorHandlingMode { get; set; }
        public bool IgnoreSslErrors { get; set; }
        public AuthenticationType AuthenticationType { get; set; }

        public WebResource WebResource { get; set; }
        public Segment Segment { get; set; }

        public string RequestUri { get; set; }
        public string QueryString { get; set; }

        public HttpContent HttpContent { get; set; }

        public HttpContext HttpContext { get; set; }
    }
}
