namespace TvDbSharper.JsonApi.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Search.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class SearchClient : BaseClient, ISearchClient
    {
        public SearchClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesAsync(
            string value,
            SearchParameter parameter,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/search/series?{UrlHelpers.PascalCase(parameter.ToString())}={value}";

            return await this.GetAsync<SeriesSearchResult[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(imdbId, SearchParameter.ImdbId, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(name, SearchParameter.Name, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(
            string zap2ItId,
            CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(zap2ItId, SearchParameter.Zap2itId, cancellationToken);
        }
    }
}