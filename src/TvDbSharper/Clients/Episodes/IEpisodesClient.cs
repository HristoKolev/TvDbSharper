namespace TvDbSharper.Clients.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Episodes.Json;

    /// <summary>
    /// Used for getting information about a specific episode
    /// </summary>
    public interface IEpisodesClient
    {
        Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId);
    }
}