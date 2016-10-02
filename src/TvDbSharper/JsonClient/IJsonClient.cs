namespace TvDbSharper.JsonClient
{
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IJsonClient
    {
        AuthenticationHeaderValue AuthorizationHeader { get; set; }

        string BaseUrl { get; set; }

        Task<TJsonResponse> GetJsonAsync<TJsonResponse>(string url, CancellationToken cancellationToken);

        Task<TJsonResponse> PostJsonAsync<TJsonResponse>(string requestUri, object obj, CancellationToken cancellationToken);
    }
}