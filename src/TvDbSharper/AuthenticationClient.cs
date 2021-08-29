namespace TvDbSharper
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

    /// <summary>
    /// Used for obtaining and refreshing your JWT token
    /// </summary>
    public interface IAuthenticationClient
    {
        /// <summary>
        /// <para>Gets or sets the authentication token that gets stored after calling <see cref="AuthenticateAsync(AuthenticationData, CancellationToken)" /></para>
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// <para>[POST /login]</para>
        /// <para>Authenticates the user given an authentication data and retrieves a session token.</para>
        /// <para>Call once before calling any other method.</para>
        /// </summary>
        /// <param name="authenticationData">The data required for authentication</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task AuthenticateAsync(AuthenticationData authenticationData, CancellationToken cancellationToken);

        /// <summary>
        /// <para>[POST /login]</para>
        /// <para>Authenticates the user given an authentication data and retrieves a session token.</para>
        /// <para>Call once before calling any other method.</para>
        /// </summary>
        /// <param name="authenticationData">The data required for authentication</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task" />.The task object representing the asynchronous operation.</returns>
        Task AuthenticateAsync(AuthenticationData authenticationData);
    }

    public class AuthenticationData
    {
        [JsonProperty("apikey")]
        public string ApiKey { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }
    }

    internal class AuthenticationResponseData
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
