using Microsoft.Extensions.Options;
using Sequoia.Data.WebClient.Enums;
using Sequoia.Data.WebClient.Extensions;
using Sequoia.Data.WebClient.Interfaces;
using Sequoia.Data.WebClient.Models;
using Sequoia.Data.WebClient.Options;

namespace Sequoia.Data.WebClient.Repositories
{
    public class OAuthRepository : IOAuthRepository
    {
        private readonly IWebClient _webClient;
        private readonly OAuthOptions _oauthOptions;

        private OAuthToken OAuthToken { get; set; }

        public OAuthRepository(
            IWebClient webClient,
            IOptions<WebResourcesOptions> webResourcesOptions)
        {
            _webClient = webClient;
            _oauthOptions = webResourcesOptions.Value.OAuth;

            _webClient.Configure(c =>
            {
                c.ErrorHandlingMode = ErrorHandlingMode.Debug;
                c.IgnoreSslErrors = true;
            });
        }

        public async Task<OAuthToken> GetOAuthToken()
        {
            // check token exist
            if (OAuthToken == null
                || (!_oauthOptions.IsRefreshableToken && this.OAuthToken.DateOfExpire <= DateTime.Now)
                || (_oauthOptions.IsRefreshableToken && this.OAuthToken.DateOfRefreshExpire <= DateTime.Now))
                await this.GetToken();

            // refresh token
            if (_oauthOptions.IsRefreshableToken && this.OAuthToken.DateOfRefreshExpire <= this.OAuthToken.DateOfRefresh)
                await this.RefreshToken();

            return OAuthToken;
        }

        private async Task GetToken()
        {
            // get new token
            this.OAuthToken = await _webClient
                .WithFormUrlencodedContent(_oauthOptions.AccessToken.ToArray())
                .WithUri(_oauthOptions.Url)
                .Post<OAuthToken>(null, CancellationToken.None);

            // calculate date of token expire
            this.CalculateDateOfExpire();
        }

        private async Task RefreshToken()
        {
            // update refresh_token field
            _oauthOptions.RefreshToken.Remove("refresh_token");
            _oauthOptions.RefreshToken.Add("refresh_token", this.OAuthToken.RefreshToken);

            // get fresh token
            this.OAuthToken = await _webClient
                .WithFormUrlencodedContent(_oauthOptions.RefreshToken.ToArray())
                .WithUri(_oauthOptions.Url)
                .Post<OAuthToken>(null, CancellationToken.None);

            // calculate date of token expire
            this.CalculateDateOfExpire();
        }

        private void CalculateDateOfExpire()
        {
            this.OAuthToken.DateOfReceipt = DateTime.Now;
            this.OAuthToken.DateOfExpire = DateTime.Now.AddSeconds(this.OAuthToken.ExpiresIn);
            this.OAuthToken.DateOfRefreshExpire = DateTime.Now.AddSeconds(this.OAuthToken.RefreshExpiresIn);

            this.OAuthToken.DateOfRefresh = new DateTime(
                ((this.OAuthToken.DateOfRefreshExpire.Ticks - this.OAuthToken.DateOfReceipt.Ticks) / 2) + this.OAuthToken.DateOfReceipt.Ticks);
        }
    }
}
