namespace TvDbSharper.Clients
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public abstract class BaseClient
    {
        internal BaseClient(IJsonClient jsonClient, IErrorMessages errorMessages)
        {
            this.JsonClient = jsonClient;
            this.ErrorMessages = errorMessages;

            this.UrlHelpers = new UrlHelpers();
        }

        internal IJsonClient JsonClient { get; }

        protected IErrorMessages ErrorMessages { get; }

        protected IUrlHelpers UrlHelpers { get; }

        protected Task<TvDbResponse<T>> DeleteAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return this.JsonClient.DeleteJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }

        protected Task<TvDbResponse<T>> GetAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }

        protected string GetMessage(HttpStatusCode statusCode, IReadOnlyDictionary<int, string> messagesDictionary)
        {
            if (messagesDictionary.ContainsKey((int)statusCode))
            {
                return messagesDictionary[(int)statusCode];
            }

            return null;
        }

        protected Task<TvDbResponse<T>> PutAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return this.JsonClient.PutJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}