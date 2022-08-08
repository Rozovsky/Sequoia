using Sequoia.Data.WebClient.Models;

namespace Sequoia.Data.WebClient.Interfaces
{
    public interface IOAuthRepository
    {
        Task<OAuthToken> GetOAuthToken();
    }
}
