namespace TvDbSharper.Clients.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Episodes.Json;

    public interface IEpisodesClient
    {
        Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId);
    }
}