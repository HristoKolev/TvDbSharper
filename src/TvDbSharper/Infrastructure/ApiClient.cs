namespace TvDbSharper.Infrastructure
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using TvDbSharper.Dto;

    internal class ApiRequest
    {
        public ApiRequest()
        {
        }

        public ApiRequest(string method, string url)
        {
            this.Method = method;
            this.Url = url;
        }

        public ApiRequest(string method, string url, string body)
        {
            this.Method = method;
            this.Url = url;
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

        public HttpStatusCode StatusCode { get; set; }
    }

    internal interface IApiClient
    {
        Uri BaseAddress { get; set; }

        IDictionary<string, string> DefaultRequestHeaders { get; set; }

        Task<ApiResponse> SendRequestAsync(ApiRequest request, CancellationToken cancellationToken);
    }

    internal class ApiClient : IApiClient
    {
        private static HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            this.DefaultRequestHeaders = new ConcurrentDictionary<string, string>();
        }

        public Uri BaseAddress
        {
            get => _httpClient.BaseAddress;
            set => _httpClient.BaseAddress = value;
        }

        public IDictionary<string, string> DefaultRequestHeaders { get; set; }

        public async Task<ApiResponse> SendRequestAsync(ApiRequest request, CancellationToken cancellationToken)
            => await GetResponseAsync(this.CreateRequest(request), cancellationToken).ConfigureAwait(false);

        private static void ApplyHeaders(HttpRequestMessage request, IDictionary<string, string> headers)
        {
            foreach (var pair in headers)
            {
                switch (pair.Key)
                {
                    case "Content-Type" :
                    {
                        break;
                    }

                    default :
                    {
                        request.Headers.Add(pair.Key, pair.Value);
                        break;
                    }
                }
            }
        }

        private static IDictionary<string, string> CombineHeaders(params IDictionary<string, string>[] headerCollections)
        {
            var result = new Dictionary<string, string>();

            for (var i = 0; i < headerCollections.Length; i++)
            {
                var headerCollection = headerCollections[i];

                if (headerCollection != null)
                {
                    foreach (var pair in headerCollection)
                    {
                        result[pair.Key] = pair.Value;
                    }
                }
            }

            return result;
        }

        private static async Task<ApiResponse> GetResponseAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken)
        {
            var httpResponse = await _httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            string body = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var headers = ParseHeaders(httpResponse.Headers);

            return new ApiResponse
            {
                Body = body,
                StatusCode = httpResponse.StatusCode,
                Headers = headers
            };
        }

        private static IDictionary<string, string> ParseHeaders(HttpHeaders headers)
        {
            var dict = new Dictionary<string, string>();

            foreach (var pair in headers)
            {
                dict[pair.Key] = string.Join(";", pair.Value);
            }

            return dict;
        }

        private HttpRequestMessage CreateRequest(ApiRequest request)
        {
            var httpRequest = new HttpRequestMessage(new HttpMethod(request.Method), request.Url);

            var combinedHeaders = CombineHeaders(this.DefaultRequestHeaders, request.Headers);
            ApplyHeaders(httpRequest, combinedHeaders);

            if (request.Body != null)
            {
                combinedHeaders.TryGetValue("Content-Type", out string contentType);
                httpRequest.Content = new StringContent(request.Body, null, contentType);
            }

            return httpRequest;
        }
    }

    internal interface IParser
    {
        T Parse<T>(ApiResponse response, IReadOnlyDictionary<int, string> errorMap);
    }

    internal class Parser : IParser
    {
        private const string UnknownErrorMessage = "The REST API returned an unkown error.";

        public T Parse<T>(ApiResponse response, IReadOnlyDictionary<int, string> errorMap)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(response.Body);
            }

            throw CreateException(response, errorMap);
        }

        private static TvDbServerException CreateException(ApiResponse response, IReadOnlyDictionary<int, string> errorMap)
        {
            var messages = new List<string>();

            if (errorMap.TryGetValue((int)response.StatusCode, out string msg))
            {
                messages.Add(msg);
            }

            string bodyMessage = ReadErrorMessage(response.Body);

            if (bodyMessage != null)
            {
                messages.Add(bodyMessage);
            }

            bool unknownError = !messages.Any();

            if (unknownError)
            {
                messages.Add(UnknownErrorMessage);
            }

            string message = string.Join("; ", messages);

            var exception = new TvDbServerException(message, (int)response.StatusCode)
            {
                UnknownError = unknownError
            };

            return exception;
        }

        private static string ReadErrorMessage(string body)
        {
            try
            {
                return JsonConvert.DeserializeObject<ErrorResponse>(body).Error;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
