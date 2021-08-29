namespace TvDbSharper.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    internal class ApiRequest
    {
        public ApiRequest()
        {
            this.Headers = new Dictionary<string, string>();
        }

        public ApiRequest(string method, string url) : this()
        {
            this.Method = method;
            this.Url = url;
        }

        public ApiRequest(string method, string url, string body) : this(method, url)
        {
            this.Body = body;
        }

        public string Body { get; set; }

        public IDictionary<string, string> Headers { get; set; }

        public string Method { get; set; }

        public string Url { get; set; }
    }

    internal class ApiResponse
    {
        public string Body { get; set; }

        public IDictionary<string, string> Headers { get; set; }

        public int StatusCode { get; set; }
    }

    internal interface IApiClient
    {
        HttpClient HttpClient { get; }

        Task<ApiResponse> SendRequestAsync(ApiRequest request, CancellationToken cancellationToken);
    }

    internal class ApiClient : IApiClient
    {
        public ApiClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<ApiResponse> SendRequestAsync(ApiRequest request, CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(request.Url, UriKind.Relative),
                Method = new HttpMethod(request.Method),
            };

            if (request.Body != null)
            {
                httpRequestMessage.Content = new StringContent(request.Body, Encoding.UTF8, "application/json");
            }

            foreach (var pair in request.Headers)
            {
                if (!httpRequestMessage.Headers.TryAddWithoutValidation(pair.Key, pair.Value))
                {
                    throw new Exception($"Couldn't add header '{pair.Key}'.");
                }
            }

            var httpResponseMessage = await this.HttpClient.SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var headers = httpResponseMessage.Headers.ToDictionary(x => x.Key, x => string.Join(", ", x.Value));

            return new ApiResponse
            {
                Body = responseBody,
                StatusCode = (int)httpResponseMessage.StatusCode,
                Headers = headers,
            };
        }
    }

    internal interface IParser
    {
        TvDbApiResponse<T> Parse<T>(ApiResponse response);
    }

    internal class Parser : IParser
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
#if DEBUG
            MissingMemberHandling = MissingMemberHandling.Error,
#endif
        };

        public TvDbApiResponse<T> Parse<T>(ApiResponse response)
        {
            if (response.StatusCode == 200)
            {
                var tvDbApiResponse = JsonConvert.DeserializeObject<TvDbApiResponse<T>>(response.Body, JsonSettings);

                if (tvDbApiResponse?.Status != "success")
                {
                    throw new TvDbServerException("Response.Status wasn't 'success'.", response.StatusCode)
                    {
                        UnknownError = true,
                    };
                }

                return tvDbApiResponse;
            }

            UnauthorizedData body;

            if (response.StatusCode == 401)
            {
                body = JsonConvert.DeserializeObject<UnauthorizedData>(response.Body, JsonSettings);

                throw new TvDbServerException(body?.Message, response.StatusCode);
            }

            body = JsonConvert.DeserializeObject<UnauthorizedData>(response.Body, JsonSettings);

            throw new TvDbServerException(body?.Message ?? "Unknown error", response.StatusCode)
            {
                UnknownError = true,
            };
        }

        private class UnauthorizedData
        {
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }

    public class TvDbApiResponse<TData>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}
