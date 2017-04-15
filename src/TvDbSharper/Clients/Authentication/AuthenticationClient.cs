namespace TvDbSharper.Clients.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Clients.Authentication.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class AuthenticationClient : IAuthenticationClient
    {
        internal AuthenticationClient(IJsonClient jsonClient, IErrorMessages errorMessages)
        {
            this.JsonClient = jsonClient;
            this.ErrorMessages = errorMessages;
        }

        public string Token
        {
            get => this.JsonClient.AuthorizationHeader?.Parameter;

            set => this.JsonClient.AuthorizationHeader = new AuthenticationHeaderValue("Bearer", value);
        }

        private IErrorMessages ErrorMessages { get; }

        private IJsonClient JsonClient { get; }

        public async Task AuthenticateAsync(AuthenticationData authenticationData, CancellationToken cancellationToken)
        {
            if (authenticationData == null)
            {
                throw new ArgumentNullException(nameof(authenticationData));
            }

            try
            {
                var response = await this.JsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationData, cancellationToken)
                                         .ConfigureAwait(false);

                this.UpdateAuthenticationHeader(response.Token);
            }
            catch (TvDbServerException ex)
            {
                string message = GetMessage(ex.StatusCode, this.ErrorMessages.Authentication.AuthenticateAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task AuthenticateAsync(string apiKey, string username, string userKey, CancellationToken cancellationToken)
        {
            return this.AuthenticateAsync(new AuthenticationData(apiKey, username, userKey), cancellationToken);
        }

        public Task AuthenticateAsync(string apiKey, string username, string userKey)
        {
            return this.AuthenticateAsync(apiKey, username, userKey, CancellationToken.None);
        }

        public Task AuthenticateAsync(AuthenticationData authenticationData)
        {
            return this.AuthenticateAsync(authenticationData, CancellationToken.None);
        }

        public Task AuthenticateAsync(string apiKey, CancellationToken cancellationToken)
        {
            return this.AuthenticateAsync(new AuthenticationData(apiKey), cancellationToken);
        }

        public Task AuthenticateAsync(string apiKey)
        {
            return this.AuthenticateAsync(apiKey, CancellationToken.None);
        }

        public async Task RefreshTokenAsync(CancellationToken cancellationToken)
        {
            try
            {
                var response = await this.JsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", cancellationToken)
                                         .ConfigureAwait(false);

                this.UpdateAuthenticationHeader(response.Token);
            }
            catch (TvDbServerException ex)
            {
                string message = GetMessage(ex.StatusCode, this.ErrorMessages.Authentication.RefreshTokenAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task RefreshTokenAsync()
        {
            return this.RefreshTokenAsync(CancellationToken.None);
        }

        private static string GetMessage(HttpStatusCode statusCode, IReadOnlyDictionary<int, string> messagesDictionary)
        {
            if (messagesDictionary.ContainsKey((int)statusCode))
            {
                return messagesDictionary[(int)statusCode];
            }

            return null;
        }

        private void UpdateAuthenticationHeader(string token)
        {
            this.JsonClient.AuthorizationHeader = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}