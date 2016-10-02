namespace TvDbSharper
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonSchemas;

    public interface IRestClient
    {
        Task AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken);

        Task<ActorResponse[]> GetSeriesActorsAsync(int seriesId, CancellationToken cancellationToken);

        Task<SeriesResponse> GetSeriesAsync(int seriesId, CancellationToken cancellationToken);

        Task<EpisodeResponse[]> GetSeriesEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken);

        Task RefreshTokenAsync(CancellationToken cancellationToken);

        // Task<SearchResponse[]> SearchSeriesAsync(string name, CancellationToken cancellationToken);
    }
}