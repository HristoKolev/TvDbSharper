namespace TvDbSharper.RestClient
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.RestClient.JsonSchemas;
    using TvDbSharper.RestClient.Models;

    public interface IRestClient
    {
        Task AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken);

        Task<TvDbResponse<ActorModel[]>> GetSeriesActorsAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesModel>> GetSeriesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodeModel[]>> GetSeriesEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken);

        Task RefreshTokenAsync(CancellationToken cancellationToken);

        // Task<SearchResponse[]> SearchSeriesAsync(string name, CancellationToken cancellationToken);
    }
}