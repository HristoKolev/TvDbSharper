namespace TvDbSharper.Clients
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class BaseClient
    {
        protected BaseClient(IJsonClient jsonClient, IErrorMessages errorMessages)
        {
            this.JsonClient = jsonClient;
            this.ErrorMessages = errorMessages;

            this.UrlHelpers = new UrlHelpers();
        }

        protected IErrorMessages ErrorMessages { get; }

        protected IJsonClient JsonClient { get; }

        protected IUrlHelpers UrlHelpers { get; }

        protected async Task<TvDbResponse<T>> DeleteAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.DeleteJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }

        protected async Task<TvDbResponse<T>> GetAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }

        protected string GetMessage(HttpStatusCode statusCode, IDictionary<int, string> messagesDictionary)
        {
            if (messagesDictionary.ContainsKey((int)statusCode))
            {
                return messagesDictionary[(int)statusCode];
            }

            return null;
        }

        protected async Task<T> PostAsync<T>(string requestUri, object obj, CancellationToken cancellationToken)
        {
            return await this.JsonClient.PostJsonAsync<T>(requestUri, obj, cancellationToken);
        }

        protected async Task<TvDbResponse<T>> PutAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.PutJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}