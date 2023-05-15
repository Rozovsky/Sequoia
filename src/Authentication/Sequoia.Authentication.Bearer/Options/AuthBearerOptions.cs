using Sequoia.Authentication.Options;

namespace Sequoia.Authentication.Bearer.Options
{
    public class AuthBearerOptions : AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
    }
}
