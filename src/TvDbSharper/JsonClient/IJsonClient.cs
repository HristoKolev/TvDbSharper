namespace TvDbSharper.JsonClient
{
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IJsonClient
    {
        AuthenticationHeaderValue AuthorizationHeader { get; set; }

        string BaseUrl { get; set; }

        Task<TResponse> DeleteJsonAsync<TResponse>(string url, CancellationToken cancellationToken);

        Task<TResponse> GetJsonAsync<TResponse>(string url, CancellationToken cancellationToken);

        Task<TResponse> PostJsonAsync<TResponse>(string requestUri, object obj, CancellationToken cancellationToken);

        Task<TResponse> PutJsonAsync<TResponse>(string url, CancellationToken cancellationToken);
    }
}