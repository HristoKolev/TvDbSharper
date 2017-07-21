namespace ConsoleApp2
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient.JsonSchemas;

    public class ApiRequest
    {
        public ApiRequest()
        {
        }

        public ApiRequest(string method, string url)
        {
            this.Method = method;
            this.Url = url;
        }

        public string Body { get; set; }

        public WebHeaderCollection Headers { get; }

        public string Method { get; set; }

        public string Url { get; set; }
    }

    public class ApiResponse
    {
        public string Body { get; set; }

        public WebHeaderCollection Headers { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }

    public interface IApiClient
    {
        Task<ApiResponse> SendRequestAsync(ApiRequest request, CancellationToken cancellationToken);
    }

    public class ApiClient : IApiClient
    {
        public async Task<ApiResponse> SendRequestAsync(ApiRequest request, CancellationToken cancellationToken)
        {
            return await GetResponseAsync(await CreateRequestAsync(request).ConfigureAwait(false), cancellationToken).ConfigureAwait(false);
        }

        private static async Task<HttpWebRequest> CreateRequestAsync(ApiRequest request)
        {
            var httpRequest = WebRequest.CreateHttp(request.Url);
            httpRequest.Method = request.Method;

            if (request.Headers != null)
            {
                httpRequest.Headers = request.Headers;
            }

            if (request.Body != null)
            {
                var stream = await httpRequest.GetRequestStreamAsync().ConfigureAwait(false);

                byte[] buffer = Encoding.UTF8.GetBytes(request.Body);

                await stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            }

            return httpRequest;
        }

        private static async Task<ApiResponse> GetResponseAsync(WebRequest httpRequest, CancellationToken cancellationToken)
        {
            HttpWebResponse httpResponse;

            try
            {
                httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync().ConfigureAwait(false);
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }

            cancellationToken.ThrowIfCancellationRequested();

            var stream = httpResponse.GetResponseStream();

            string body;

            using (var reader = new StreamReader(stream))
            {
                body = await reader.ReadToEndAsync().ConfigureAwait(false);
            }

            cancellationToken.ThrowIfCancellationRequested();

            return new ApiResponse
            {
                Body = body,
                StatusCode = httpResponse.StatusCode
            };
        }
    }

    public interface IParser
    {
        T Parse<T>(ApiResponse response, IReadOnlyDictionary<HttpStatusCode, string> errorMap);
    }

    public class Parser : IParser
    {
        private const string UnknownErrorMessage = "The REST API returned an unkown error.";

        public T Parse<T>(ApiResponse response, IReadOnlyDictionary<HttpStatusCode, string> errorMap)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(response.Body);
            }

            throw CreateException(response, errorMap);
        }

        private static TvDbServerException CreateException(ApiResponse response, IReadOnlyDictionary<HttpStatusCode, string> errorMap)
        {
            string message = null;

            if (errorMap.ContainsKey(response.StatusCode))
            {
                message = errorMap[response.StatusCode];
            }

            if (message == null)
            {
                message = JsonConvert.DeserializeObject<ErrorResponse>(response.Body).Error;
            }

            bool unknownError = false;

            if (message == null)
            {
                message = UnknownErrorMessage;

                unknownError = true;
            }

            var exception = new TvDbServerException(message, response.StatusCode)
            {
                UnknownError = unknownError
            };

            return exception;
        }
    }
}