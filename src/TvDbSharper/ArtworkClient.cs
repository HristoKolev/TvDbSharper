namespace TvDbSharper
{
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure;

    internal class ArtworkClient : IArtworkClient
    {
        private readonly IApiClient apiClient;
        private readonly IParser parser;

        public ArtworkClient(IApiClient apiClient, IParser parser)
        {
            this.apiClient = apiClient;
            this.parser = parser;
        }

        public async Task<ArtworkStatusDto[]> GetArtStatuses(CancellationToken cancellationToken)
        {
            var request = new ApiRequest("GET", "artwork/statuses");
            var response = await this.apiClient.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            return this.parser.Parse<ArtworkStatusDto[]>(response).Data;
        }

        public Task<ArtworkStatusDto[]> GetArtStatuses()
        {
            return this.GetArtStatuses(CancellationToken.None);
        }
    }

    public interface IArtworkClient
    {
        Task<ArtworkStatusDto[]> GetArtStatuses(CancellationToken cancellationToken);

        Task<ArtworkStatusDto[]> GetArtStatuses();
    }
}
