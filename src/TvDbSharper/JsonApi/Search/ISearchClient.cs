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

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(
            string zap2ItId,
            CancellationToken cancellationToken);
    }
}