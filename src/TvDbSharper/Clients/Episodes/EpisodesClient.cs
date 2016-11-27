namespace TvDbSharper.Clients.Episodes
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Episodes.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class EpisodesClient : BaseClient, IEpisodesClient
    {
        public EpisodesClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
        {
        }

        public Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/episodes/{episodeId}";

                return this.GetAsync<EpisodeRecord>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Episodes.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<EpisodeRecord>> GetAsync(int episodeId)
        {
            return this.GetAsync(episodeId, CancellationToken.None);
        }
    }
}