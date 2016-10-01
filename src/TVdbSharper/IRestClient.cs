namespace TvDbSharper
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonSchemas;

    public interface IRestClient
    {
        Task Authenticate(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken);

        Task<SeriesResponse> GetSeriesAsync(int seriesId, CancellationToken cancellationToken);

        Task RefreshToken(CancellationToken cancellationToken);

        Task<SearchResponse[]> SearchSeriesAsync(string name, CancellationToken cancellationToken);
    }
}