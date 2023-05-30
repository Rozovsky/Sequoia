using Sequoia.Client.Http.Exceptions;

namespace Sequoia.Client.Http.Configuration
{
    public class Path
    {
        public string Uri { get; set; }
        public string Resource { get; set; }
        public string Segment { get; set; }

        protected internal void SetUri(string pattern)
        {
            if (pattern.Contains("http://") || pattern.Contains("https://"))
            {
                Uri = pattern;
            }
            else
            {
                var webResourcePathSplitted = pattern.Split('/');

                if (webResourcePathSplitted.Length != 2)
                    throw new PathPatternException(pattern);

                Resource = webResourcePathSplitted[0];
                Segment = webResourcePathSplitted[1];
            }
        }
    }
}
