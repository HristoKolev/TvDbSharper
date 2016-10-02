namespace TvDbSharper
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using TvDbSharper.Exceptions;
    using TvDbSharper.JsonSchemas;

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
                string json = await response.Content.ReadAsStringAsync();

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new TvDbServerException(JsonConvert.DeserializeObject<ErrorResponse>(json).Error, ex);
                }

                return JsonConvert.DeserializeObject<TJsonResponse>(json);
            }
        }

        public async Task<DataResponse<TJsonResponse>> GetJsonDataAsync<TJsonResponse>(string url, CancellationToken cancellationToken)
        {
            return await this.GetJsonAsync<DataResponse<TJsonResponse>>(url, cancellationToken);
        }

        public async Task<TJsonResponse> PostJsonAsync<TJsonResponse>(string requestUri, object obj, CancellationToken cancellationToken)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            using (var response = await this.HttpClient.PostAsync(requestUri, content, cancellationToken))
            {
                string json = await response.Content.ReadAsStringAsync();

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    throw new TvDbServerException(JsonConvert.DeserializeObject<ErrorResponse>(json).Error, ex);
                }

                return JsonConvert.DeserializeObject<TJsonResponse>(json);
            }
        }
    }
}