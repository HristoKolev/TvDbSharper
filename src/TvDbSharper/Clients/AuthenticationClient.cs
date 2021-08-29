namespace TvDbSharper.Clients
{
    using System;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure;
    using Newtonsoft.Json;

    internal class AuthenticationClient : IAuthenticationClient
    {
        private const string AUTHORIZATION_HEADER_NAME = "Authorization";

        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
        };

        public AuthenticationClient(IApiClient apiClient, IParser parser)
        {
            this.ApiClient = apiClient;
            this.Parser = parser;
        }

        public string Token
        {
            get
            {
                if (this.ApiClient.HttpClient.DefaultRequestHeaders.Contains(AUTHORIZATION_HEADER_NAME))
                {
                    return this.ApiClient.HttpClient.DefaultRequestHeaders.Authorization.Parameter;
                }

                return null;
            }

            set => this.ApiClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
        }

        private IApiClient ApiClient { get; }

        private IParser Parser { get; }

        public async Task AuthenticateAsync(AuthenticationData authenticationData, CancellationToken cancellationToken)
        {
            if (authenticationData == null)
            {
                throw new ArgumentNullException(nameof(authenticationData));
            }

            string body = JsonConvert.SerializeObject(authenticationData, this.serializerSettings);
            var request = new ApiRequest("POST", "login", body);
            var response = await this.ApiClient.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            var data = this.Parser.Parse<AuthenticationResponseData>(response);

            this.UpdateAuthenticationHeader(data.Data.Token);
        }

        public Task AuthenticateAsync(AuthenticationData authenticationData)
        {
            return this.AuthenticateAsync(authenticationData, CancellationToken.None);
        }

        private void UpdateAuthenticationHeader(string token)
        {
            this.ApiClient.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
