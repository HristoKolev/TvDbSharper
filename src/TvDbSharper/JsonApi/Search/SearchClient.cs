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
    }
}