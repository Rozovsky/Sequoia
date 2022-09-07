namespace Sequoia.Client.Http.Options
{
    public class HttpAuthenticationOptions
    {
        public HttpAuthenticationOAuthPasswordOptions OAuthPassword { get; set; }
        public HttpAuthenticationBasicOptions Basic { get; set; }
    }
}
