namespace Sequoia.Data.WebClient.Options
{
    public class OAuthOptions
    {
        public string Url { get; set; }
        public bool IsRefreshableToken { get; set; }
        public Dictionary<string, string> AccessToken { get; set; }
        public Dictionary<string, string> RefreshToken { get; set; }
    }
}
