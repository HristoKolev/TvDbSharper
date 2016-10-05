namespace TvDbSharper.Api.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Languages.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class LanguagesClient : ILanguagesClient
    {
        public LanguagesClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task<TvDbResponse<LanguageData[]>> GetAllAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/languages";

            return await this.GetDataAsync<LanguageData[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<LanguageData>> GetAsync(int languageId, CancellationToken cancellationToken)
        {
            string requestUri = $"/languages/{languageId}";

            return await this.GetDataAsync<LanguageData>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}