namespace Sequoia.Logging.Options
{
    public class ElasticsearchOptions
    {
        public bool WriteToElasticsearch { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool AutoRegisterTemplate { get; set; }
    }
}
