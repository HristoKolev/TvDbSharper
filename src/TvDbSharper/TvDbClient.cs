namespace TvDbSharper
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public partial class TvDbClient
    {
        private const string DEFAULT_BASE_URL = "https://api4.thetvdb.com/v4/";

        private readonly IApiClient apiClient;
        private readonly IParser parser;

        public TvDbClient()
            : this(new HttpClient()) { }

        public TvDbClient(HttpClient httpClient)
            : this(new ApiClient(httpClient), new Parser()) { }

        internal TvDbClient(IApiClient apiClient, IParser parser)
        {
            this.apiClient = apiClient;
            this.parser = parser;

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DEFAULT_BASE_URL;
            }
        }

        public string BaseUrl
        {
            get => this.apiClient.HttpClient.BaseAddress?.ToString();

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The value cannot be an empty string or white space.");
                }

                this.apiClient.HttpClient.BaseAddress = new Uri(value);
            }
        }

        public string AuthToken
        {
            get
            {
                if (this.apiClient.HttpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    return this.apiClient.HttpClient.DefaultRequestHeaders.Authorization.Parameter;
                }

                return null;
            }

            set => this.apiClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
        }

        public async Task Login(string apiKey, string pin, CancellationToken cancellationToken)
        {
            if (apiKey == null)
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            if (pin == null)
            {
                throw new ArgumentNullException(nameof(pin));
            }

            var authenticationData = new AuthenticationData { ApiKey = apiKey, Pin = pin };

            string body = JsonConvert.SerializeObject(authenticationData, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            var request = new ApiRequest("POST", "login", body);

            var response = await this.apiClient.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            var data = this.parser.Parse<AuthenticationResponseData>(response);

            this.apiClient.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", data.Data.Token);
        }

        public Task Login(string apiKey, string pin)
        {
            return this.Login(apiKey, pin, CancellationToken.None);
        }

        private async Task<TResponse> GenericRequest<TResponse>(string url, object queryParams, CancellationToken cancellationToken)
        {
            var request = new ApiRequest("GET", url + UrlHelpers.Querify(queryParams));
            var response = await this.apiClient.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            return this.parser.Parse<TResponse>(response).Data;
        }
    }

    public class TvDbServerException : Exception
    {
        public TvDbServerException(string message, int statusCode)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        public int StatusCode { get; }

        public bool UnknownError { get; set; }
    }

    internal class AuthenticationData
    {
        [JsonProperty("apikey")]
        public string ApiKey { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }
    }

    internal class AuthenticationResponseData
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }

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

        // ReSharper disable once CollectionNeverUpdated.Global
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

            if (response.StatusCode == 401)
            {
                var data = JsonConvert.DeserializeObject<UnauthorizedData>(response.Body, JsonSettings);
                throw new TvDbServerException(data?.Message, response.StatusCode);
            }

            var notFoundData = JsonConvert.DeserializeObject<NotFoundData>(response.Body, JsonSettings);
            throw new TvDbServerException(notFoundData?.Message ?? "Unknown error", response.StatusCode)
            {
                UnknownError = true,
            };
        }

        private class UnauthorizedData
        {
            [JsonProperty("message")]
            public string Message { get; set; }
        }

        private class NotFoundData : TvDbApiResponse<object>
        {
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }

    internal class TvDbApiResponse<TData>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }

    internal class QueryParameterAttribute : Attribute
    {
        public string QueryParameterName { get; set; }

        public QueryParameterAttribute(string queryParameterName)
        {
            this.QueryParameterName = queryParameterName;
        }
    }

    internal static class UrlHelpers
    {
        private static readonly ConcurrentDictionary<Type, KeyValuePair<PropertyInfo, string>[]> Cache =
            new ConcurrentDictionary<Type, KeyValuePair<PropertyInfo, string>[]>();

        public static string Querify(object obj)
        {
            if (obj == null)
            {
                return "";
            }

            var properties = Cache.GetOrAdd(obj.GetType(), type =>
            {
                var items = new List<KeyValuePair<PropertyInfo, string>>();

                foreach (var propertyInfo in obj.GetType().GetTypeInfo().DeclaredProperties.OrderBy(info => info.Name))
                {
                    var queryParameterAttribute = propertyInfo.GetCustomAttribute<QueryParameterAttribute>();

                    items.Add(new KeyValuePair<PropertyInfo, string>(propertyInfo, queryParameterAttribute.QueryParameterName));
                }

                return items.ToArray();
            });

            var parts = new List<string>();

            foreach (var pair in properties)
            {
                var propertyInfo = pair.Key;
                string queryParameterName = pair.Value;

                object propertyValue = propertyInfo.GetValue(obj);

                if (propertyValue != null)
                {
                    parts.Add($"{queryParameterName}={Uri.EscapeDataString(propertyValue.ToString())}");
                }
            }

            return "?" + string.Join("&", parts);
        }
    }
}
