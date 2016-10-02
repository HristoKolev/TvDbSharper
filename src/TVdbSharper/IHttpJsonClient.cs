namespace TvDbSharper
{
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonSchemas;

    public interface IHttpJsonClient
    {
        AuthenticationHeaderValue AuthorizationHeader { get; set; }

        string BaseUrl { get; set; }

        Task<DataResponse<TJsonResponse>> GetJsonDataAsync<TJsonResponse>(string url, CancellationToken cancellationToken);

        Task<TJsonResponse> GetJsonAsync<TJsonResponse>(string url, CancellationToken cancellationToken);

        Task<TJsonResponse> PostJsonAsync<TJsonResponse>(string requestUri, object obj, CancellationToken cancellationToken);
    }
}