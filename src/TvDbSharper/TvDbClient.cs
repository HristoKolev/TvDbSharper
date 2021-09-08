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

        private readonly HttpClient httpClient;

        public TvDbClient() : this(new HttpClient()) { }

        public TvDbClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DEFAULT_BASE_URL;
            }
        }

        public string BaseUrl
        {
            get => this.httpClient.BaseAddress?.ToString();

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

                this.httpClient.BaseAddress = new Uri(value);
            }
        }

        public string AuthToken
        {
            get
            {
                if (this.httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    return this.httpClient.DefaultRequestHeaders.Authorization.Parameter;
                }

                return null;
            }

            set => this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
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

            var authData = new AuthRequestData { ApiKey = apiKey, Pin = pin };

            string requestJson = JsonConvert.SerializeObject(authData);

            var httpResponseMessage = await this.httpClient
                .PostAsync(new Uri("login", UriKind.Relative), new StringContent(requestJson, Encoding.UTF8, "application/json"), cancellationToken)
                .ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            string responseJson = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            var apiResponse = Parse<AuthResponseData>((int)httpResponseMessage.StatusCode, responseJson);

            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiResponse.Data.Token);
        }

        public Task Login(string apiKey, string pin)
        {
            return this.Login(apiKey, pin, CancellationToken.None);
        }

        private async Task<TvDbApiResponse<TResponse>> Get<TResponse>(string url, object queryParams, CancellationToken cancellationToken)
        {
            var httpResponseMessage = await this.httpClient.GetAsync(new Uri(url + Querify(queryParams), UriKind.Relative), cancellationToken)
                .ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            string responseJson = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            return Parse<TResponse>((int)httpResponseMessage.StatusCode, responseJson);
        }

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
#if DEBUG
            MissingMemberHandling = MissingMemberHandling.Error,
#endif
        };

        private static TvDbApiResponse<T> Parse<T>(int statusCode, string responseJson)
        {
            switch (statusCode)
            {
                case 200:
                {
                    var response = JsonConvert.DeserializeObject<TvDbApiResponse<T>>(responseJson, JsonSettings);

                    if (response?.Status != "success")
                    {
                        throw new TvDbServerException("Response.Status wasn't 'success'.", statusCode)
                        {
                            UnknownError = true,
                        };
                    }

                    return response;
                }
                case 401:
                {
                    var response = JsonConvert.DeserializeObject<UnauthorizedData>(responseJson, JsonSettings);

                    throw new TvDbServerException(response?.Message, statusCode);
                }
                default:
                {
                    var response = JsonConvert.DeserializeObject<NotFoundData>(responseJson, JsonSettings);

                    throw new TvDbServerException(response?.Message ?? "Unknown error", statusCode)
                    {
                        UnknownError = true,
                    };
                }
            }
        }

        private static readonly ConcurrentDictionary<Type, QueryParamModel[]> Cache = new ConcurrentDictionary<Type, QueryParamModel[]>();

        private static string Querify(object obj)
        {
            if (obj == null)
            {
                return "";
            }

            var models = Cache.GetOrAdd(obj.GetType(), type =>
            {
                return type.GetTypeInfo().DeclaredProperties.Select(x => new QueryParamModel
                {
                    Name = x.GetCustomAttribute<QueryParameterAttribute>().QueryParameterName,
                    Getter = x.GetValue,
                }).ToArray();
            });

            var result = new List<string>();

            foreach (var model in models)
            {
                object value = model.Getter(obj);

                if (value != null)
                {
                    result.Add($"{model.Name}={Uri.EscapeDataString(value.ToString())}");
                }
            }

            return "?" + string.Join("&", result);
        }

        private class AuthRequestData
        {
            [JsonProperty("apikey")]
            public string ApiKey { get; set; }

            [JsonProperty("pin")]
            public string Pin { get; set; }
        }

        private class AuthResponseData
        {
            [JsonProperty("token")]
            public string Token { get; set; }
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

        private class QueryParamModel
        {
            public string Name { get; set; }

            public Func<object, object> Getter { get; set; }
        }
    }

    public class TvDbApiResponse<TData>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }

        [JsonProperty("links")]
        public LinksDto Links { get; set; }
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

    internal class QueryParameterAttribute : Attribute
    {
        public string QueryParameterName { get; set; }

        public QueryParameterAttribute(string queryParameterName)
        {
            this.QueryParameterName = queryParameterName;
        }
    }
}
