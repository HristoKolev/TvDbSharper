namespace TvDbSharper.JsonApi.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Episodes.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class EpisodesClient : BaseClient, IEpisodesClient
    {
        public EpisodesClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken)
        {
            string requestUri = $"/episodes/{episodeId}";

            return await this.GetAsync<EpisodeRecord>(requestUri, cancellationToken);
        }
    }
}