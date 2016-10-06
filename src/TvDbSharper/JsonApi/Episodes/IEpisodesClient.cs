namespace TvDbSharper.JsonApi.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Episodes.Json;
    using TvDbSharper.RestClient.Json;

    public interface IEpisodesClient
    {
        Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken);
    }
}