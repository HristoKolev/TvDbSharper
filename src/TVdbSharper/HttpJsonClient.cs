namespace TVdbSharper
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using TVdbSharper.JsonSchemas;

    public class HttpJsonClient : IHttpJsonClient
    {
        public HttpJsonClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;

            this.HttpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public AuthenticationHeaderValue AuthorizationHeader
        {
            get
            {
                return this.HttpClient.DefaultRequestHeaders.Authorization;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.HttpClient.DefaultRequestHeaders.Authorization = value;
            }
        }

        public string BaseUrl
        {
            get
            {
                return this.HttpClient.BaseAddress?.AbsoluteUri?.TrimEnd('/');
            }

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

                this.HttpClient.BaseAddress = new Uri(value);
            }
        }

        private HttpClient HttpClient { get; }

        public async Task<TJsonResponse> GetJsonAsync<TJsonResponse>(string url, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.GetAsync(url, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DataResponse<TJsonResponse>>(json).data;
            }
        }

        public async Task<TJsonResponse> PostJsonAsync<TJsonResponse>(string requestUri, object obj, CancellationToken cancellationToken)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj))
            {
                Headers = {
                    ContentType = MediaTypeHeaderValue.Parse("application/json")
                }
            };

            using (var response = await this.HttpClient.PostAsync(requestUri, content, cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TJsonResponse>(json);
            }
        }
    }
}