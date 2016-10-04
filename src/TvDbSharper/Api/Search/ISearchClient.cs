namespace TvDbSharper.Api.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Search.Json;
    using TvDbSharper.RestClient.Json;

    public interface ISearchClient
    {
        Task<TvDbResponse<SeriesSearchData[]>> GetSeriesAsync(string value, SearchParameter parameter, CancellationToken cancellationToken);
    }
}