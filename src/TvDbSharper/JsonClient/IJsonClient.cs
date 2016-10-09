namespace TvDbSharper.JsonClient
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IJsonClient
    {
        AuthenticationHeaderValue AuthorizationHeader { get; set; }

        HttpClient HttpClient { get; }

        Task<TResponse> DeleteJsonAsync<TResponse>(string requestUri, CancellationToken cancellationToken);

        Task<HttpResponseHeaders> GetHeadersAsync(string requestUri, CancellationToken cancellationToken);

        Task<TResponse> GetJsonAsync<TResponse>(string requestUri, CancellationToken cancellationToken);

        Task<TResponse> PostJsonAsync<TResponse>(string requestUri, object obj, CancellationToken cancellationToken);

        Task<TResponse> PutJsonAsync<TResponse>(string requestUri, CancellationToken cancellationToken);
    }
}