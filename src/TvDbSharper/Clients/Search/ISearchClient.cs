namespace TvDbSharper.Clients.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Search.Json;

    public interface ISearchClient
    {
        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesAsync(
            string value,
            SearchParameter parameter,
            CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesAsync(string parameterValue, SearchParameter parameterKey);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(string zap2ItId, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(string zap2ItId);
    }
}