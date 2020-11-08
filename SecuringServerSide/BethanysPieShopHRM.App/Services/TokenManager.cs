using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace BethanysPieShopHRM.App.Services
{
    public class TokenManager
    {
        private readonly TokenProvider _tokenProvider;
        private readonly IHttpClientFactory _httpClientFactory;

        public TokenManager(
            TokenProvider tokenProvider,
            IHttpClientFactory httpClientFactory)
        {
            _tokenProvider = tokenProvider ??
                throw new ArgumentNullException(nameof(tokenProvider));
            _httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<String> RetrieveAccessTokenAsync()
        {
            if ((_tokenProvider.ExpiresAt.AddSeconds(-60)).ToUniversalTime() > DateTime.UtcNow)
                return _tokenProvider.AccessToken;

            var idpClient = _httpClientFactory.CreateClient();
            var discoResponse = await idpClient.GetDiscoveryDocumentAsync("https://localhost:44333");

            var refreshResponse = await idpClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    Address = discoResponse.TokenEndpoint,
                    ClientId = "bethanyspieshophr",
                    ClientSecret = "108B7B4F-BEFC-4DD2-82E1-7F025F0F75D0",
                    RefreshToken = _tokenProvider.RefreshToken
                });

            _tokenProvider.AccessToken = refreshResponse.AccessToken;
            _tokenProvider.RefreshToken = refreshResponse.RefreshToken;
            _tokenProvider.ExpiresAt = DateTime.UtcNow.AddSeconds(refreshResponse.ExpiresIn);

            return _tokenProvider.AccessToken;
        }
    }
}
