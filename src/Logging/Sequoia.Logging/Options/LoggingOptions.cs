namespace Sequoia.Logging.Options;

public class LoggingOptions
{
    public bool LogMachineName { get; set; }
    public bool LogEnvironment { get; set; }
    public bool WriteToConsole { get; set; }        
    public LogLevelOptions LogLevel { get; set; }
    public ElasticsearchOptions Elasticsearch { get; set; }
    public SeqOptions Seq { get; set; }
}