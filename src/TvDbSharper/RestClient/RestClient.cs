namespace TvDbSharper.RestClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.JsonSchemas;
    using TvDbSharper.RestClient.Models;

    public class RestClient : IRestClient
    {
        public RestClient(IJsonClient jsonClient)
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

        public async Task<TvDbResponse<ActorModel[]>> GetSeriesActorsAsync(int seriesId, CancellationToken cancellationToken)
            => await this.GetDataAsync<ActorModel[]>($"/series/{seriesId}/actors", cancellationToken);

        public async Task<TvDbResponse<SeriesModel>> GetSeriesAsync(int seriesId, CancellationToken cancellationToken)
            => await this.GetDataAsync<SeriesModel>($"/series/{seriesId}", cancellationToken);

        public async Task<TvDbResponse<EpisodeModel[]>> GetSeriesEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken)
            => await this.GetDataAsync<EpisodeModel[]>($"/series/{seriesId}/episodes?page={Math.Max(page, 1)}", cancellationToken);

        public async Task RefreshTokenAsync(CancellationToken cancellationToken)
        {
            var response = await this.JsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", cancellationToken);

            this.UpdateAuthenticationHeader(response.Token);
        }

        public async Task<TvDbResponse<EpisodeModel[]>> SearchSeriesEpisodesAsync(
            int seriesId,
            EpisodeQuery query,
            int page,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{Querify(query)}";

            return await this.GetDataAsync<EpisodeModel[]>(requestUri, cancellationToken);
        }

        private static string Querify<T>(T obj)
        {
            IList<string> parts = new List<string>();

            foreach (var propertyInfo in typeof(T).GetProperties().OrderBy(info => info.Name))
            {
                object value = propertyInfo.GetValue(obj);

                if (value != null)
                {
                    char[] propertyName = propertyInfo.Name.ToCharArray();

                    propertyName[0] = char.ToLower(propertyName[0]);

                    parts.Add($"{new string(propertyName)}={Uri.EscapeDataString(value.ToString())}");
                }
            }

            return string.Join("&", parts);
        }

        // public async Task<SearchResponse[]> SearchSeriesAsync(string name, CancellationToken cancellationToken)
        // {
        // return await this.GetDataAsync<SearchResponse[]>($"/search/series?name={Uri.EscapeDataString(name)}", cancellationToken);
        // }
        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }

        private void UpdateAuthenticationHeader(string token)
        {
            this.JsonClient.AuthorizationHeader = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}