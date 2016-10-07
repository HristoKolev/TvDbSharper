namespace TvDbSharper.JsonApi.Authentication
{
    using System;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Authentication.Json;
    using TvDbSharper.JsonClient;

    public class AuthenticationClient : IAuthenticationClient
    {
        public AuthenticationClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken)
        {
            if (authenticationRequest == null)
            {
                throw new ArgumentNullException(nameof(authenticationRequest));
            }

            var response = await this.JsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, cancellationToken);

            this.UpdateAuthenticationHeader(response.Token);
        }

        public async Task AuthenticateAsync(string apiKey, string username, string userKey, CancellationToken cancellationToken)
        {
            if (apiKey == null)
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("The ApiKey cannot be an empty string or white space.");
            }

            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("The Username cannot be an empty string or white space.");
            }

            if (userKey == null)
            {
                throw new ArgumentNullException(nameof(userKey));
            }

            if (string.IsNullOrWhiteSpace(userKey))
            {
                throw new ArgumentException("The UserKey cannot be an empty string or white space.");
            }

            await this.AuthenticateAsync(new AuthenticationRequest(apiKey, username, userKey), cancellationToken);
        }

        public async Task RefreshTokenAsync(CancellationToken cancellationToken)
        {
            var response = await this.JsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", cancellationToken);

            this.UpdateAuthenticationHeader(response.Token);
        }

        private void UpdateAuthenticationHeader(string token)
        {
            this.JsonClient.AuthorizationHeader = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}