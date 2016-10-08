namespace TvDbSharper.Clients.Languages
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Languages.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class LanguagesClient : BaseClient, ILanguagesClient
    {
        public LanguagesClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
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
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Languages.GetAllAsync);

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
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Languages.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }
    }
}