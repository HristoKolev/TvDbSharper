namespace TvDbSharper.JsonApi.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Languages.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.JsonClient.Exceptions;
    using TvDbSharper.RestClient.Json;

    public class LanguagesClient : BaseClient, ILanguagesClient
    {
        public LanguagesClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<Language[]>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/languages";

                return await this.GetAsync<Language[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, ErrorMessages.Languages.GetAllAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<Language>> GetAsync(int languageId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/languages/{languageId}";

                return await this.GetAsync<Language>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, ErrorMessages.Languages.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }
    }
}