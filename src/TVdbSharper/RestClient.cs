namespace TVdbSharper
{
    using System;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using TVdbSharper.JsonSchemas;

    public class RestClient
    {
        private const string DefaultBaseUrl = "https://api.thetvdb.com";

        public RestClient(IHttpJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;

            if (this.JsonClient.BaseUrl == null)
            {
                this.JsonClient.BaseUrl = DefaultBaseUrl;
            }
        }

        private IHttpJsonClient JsonClient { get; }

        public async Task Authenticate(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken)
        {
            if (authenticationRequest == null)
            {
                throw new ArgumentNullException(nameof(authenticationRequest));
            }

            var response = await this.JsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, cancellationToken);

            this.JsonClient.AuthorizationHeader = new AuthenticationHeaderValue("Bearer", response.token);
        }

        public async Task<SeriesResponse> GetSeriesAsync(int seriesId, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<SeriesResponse>($"/series/{seriesId}", cancellationToken);
        }

        public async Task<SearchResponse[]> SearchSeriesAsync(string name, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<SearchResponse[]>($"/search/series?name={Uri.EscapeDataString(name)}", cancellationToken);
        }
    }
}