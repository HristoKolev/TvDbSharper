namespace TvDbSharper.JsonApi.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Episodes.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class EpisodesClient : IEpisodesClient
    {
        public EpisodesClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken)
        {
            string requestUri = $"/episodes/{episodeId}";

            return await this.GetDataAsync<EpisodeRecord>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}