namespace TvDbSharper.Api.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Episodes.Json;
    using TvDbSharper.RestClient.Json;

    public interface IEpisodesClient
    {
        Task<TvDbResponse<EpisodeRecordData>> GetAsync(int episodeId, CancellationToken cancellationToken);
    }
}