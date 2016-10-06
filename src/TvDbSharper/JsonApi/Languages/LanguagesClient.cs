namespace TvDbSharper.JsonApi.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Languages.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class LanguagesClient : BaseClient, ILanguagesClient
    {
        public LanguagesClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/languages";

            return await this.GetAsync<Language[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken)
        {
            string requestUri = $"/languages/{languageId}";

            return await this.GetAsync<Language>(requestUri, cancellationToken);
        }
    }
}