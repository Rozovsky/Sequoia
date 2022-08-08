using Newtonsoft.Json;

namespace Sequoia.Data.WebClient.Models
{
    public class OAuthToken
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("refresh_expires_in")]
        public int RefreshExpiresIn { get; set; }

        [JsonProperty("session_state")]
        public string SessionState { get; set; }

        // Calculated fields
        public DateTime DateOfReceipt { get; set; }
        public DateTime DateOfRefresh { get; set; }
        public DateTime DateOfExpire { get; set; }
        public DateTime DateOfRefreshExpire { get; set; }
    }
}
