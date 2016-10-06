namespace TvDbSharper.Api.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Search.Json;
    using TvDbSharper.RestClient.Json;

    public interface ISearchClient
    {
        Task<TvDbResponse<SeriesSearchResult[]>> GetSeriesAsync(string value, SearchParameter parameter, CancellationToken cancellationToken);
    }
}