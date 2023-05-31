using Sequoia.Client.Extensions;
using Sequoia.Client.Options;

namespace Sequoia.Client.Http.Configuration
{
    public class Auth
    {
        public string Token { get; set; }
        private List<Resource> Resources { get; set; }

        public Auth(List<Resource> resources)
        {
            Resources = resources;
        }

        protected internal void SetToken(string pattern)
        {
            if (pattern.Contains("Bearer") || pattern.Contains("Basic"))
            {
                Token = pattern;
            }
            else
            {
                var segment = Resources
                    .FindResource(pattern)
                    .FindSegment(pattern);

                Token = segment.Token;
            }
        }
    }
}
