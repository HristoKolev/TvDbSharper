namespace TvDbSharper.Api.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Search.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class SearchClient : ISearchClient
    {
        public SearchClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task<TvDbResponse<SeriesSearchData[]>> GetSeriesAsync(string value, SearchParameter parameter, CancellationToken cancellationToken)
        {
            string requestUri = $"/search/series?{UrlHelpers.PascalCase(parameter.ToString())}={value}";

            return await this.GetDataAsync<SeriesSearchData[]>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}