namespace Sequoia.Client.Http.Configuration
{
    public class ClientConfiguration
    {
        public Auth Auth { get; set; }
        public Body Body { get; set; }
        public Path Path { get; set; }
        public Query Query { get; set; }
        public Headers Headers { get; set; }

        public ClientConfiguration()
        {
            Auth = new Auth();
            Body = new Body();
            Path = new Path();
            Query = new Query();
            Headers = new Headers();
        }
    }
}
