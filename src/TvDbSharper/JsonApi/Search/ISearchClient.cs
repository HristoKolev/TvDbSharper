namespace TvDbSharper.JsonApi.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Search.Json;
    using TvDbSharper.RestClient.Json;

    public interface ISearchClient
    {
        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesAsync(
            string value,
            SearchParameter parameter,
            CancellationToken cancellationToken);
    }
}