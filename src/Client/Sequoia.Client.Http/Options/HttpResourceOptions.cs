namespace Sequoia.Client.Http.Options
{
    public class HttpResourceOptions
    {
        public string Name { get; set; }
        public HttpAuthenticationOptions Auth { get; set; }
        public List<HttpSegmentOptions> Segments { get; set; }
    }
}
