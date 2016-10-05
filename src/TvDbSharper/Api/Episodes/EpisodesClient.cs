namespace TvDbSharper.Api.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Episodes.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class EpisodesClient : IEpisodesClient
    {
        public EpisodesClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task<TvDbResponse<EpisodeRecordData>> GetAsync(int episodeId, CancellationToken cancellationToken)
        {
            string requestUri = $"/episodes/{episodeId}";

            return await this.GetDataAsync<EpisodeRecordData>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}