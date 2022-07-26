using Sequoia.Logging.Enums;

namespace Sequoia.Logging.Options
{
    public class LogLevelOptions
    {
        public LoggingLevel Default { get; set; }
        public LoggingLevel Microsoft { get; set; }
        public LoggingLevel System { get; set; }
    }
}
