namespace TvDbSharper.Infrastructure
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using TvDbSharper.Dto;

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
                Method = new HttpMethod(request.Method)
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
                Headers = headers
            };
        }
    }

    internal interface IParser
    {
        T Parse<T>(ApiResponse response, IReadOnlyDictionary<int, string> errorMap);
    }

    internal class Parser : IParser
    {
        private const string UnknownErrorMessage = "The REST API returned an unkown error.";

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
#if DEBUG
            MissingMemberHandling = MissingMemberHandling.Error,
#endif
        }; 

        public T Parse<T>(ApiResponse response, IReadOnlyDictionary<int, string> errorMap)
        {
            if (response.StatusCode == 200)
            {
                return JsonConvert.DeserializeObject<T>(response.Body, JsonSettings);
            }

            throw CreateException(response, errorMap);
        }

        private static TvDbServerException CreateException(ApiResponse response, IReadOnlyDictionary<int, string> errorMap)
        {
            var messages = new List<string>();

            if (errorMap.ContainsKey(response.StatusCode))
            {
                messages.Add(errorMap[response.StatusCode]);
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

            var exception = new TvDbServerException(message, response.StatusCode)
            {
                UnknownError = unknownError
            };

            return exception;
        }

        private static string ReadErrorMessage(string body)
        {
            try
            {
                return JsonConvert.DeserializeObject<ErrorResponse>(body, JsonSettings).Error;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}