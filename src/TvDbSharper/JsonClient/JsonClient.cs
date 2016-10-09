namespace TvDbSharper.JsonClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient.JsonSchemas;

    public class JsonClient : IJsonClient
    {
        private const string DefaultBaseUrl = "https://api.thetvdb.com";

        public JsonClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DefaultBaseUrl;
            }

            this.HttpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }

        public JsonClient()
            : this(new HttpClient())
        {
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

        public async Task<TResponse> DeleteJsonAsync<TResponse>(string url, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.DeleteAsync(url, cancellationToken))
            {
                return await this.ProcessResponse<TResponse>(response);
            }
        }

        public async Task<HttpResponseHeaders> GetHeadersAsync(string requestUri, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, requestUri), cancellationToken))
            {
                response.EnsureSuccessStatusCode();

                return response.Headers;
            }
        }

        public async Task<TResponse> GetJsonAsync<TResponse>(string url, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.GetAsync(url, cancellationToken))
            {
                return await this.ProcessResponse<TResponse>(response);
            }
        }

        public async Task<TResponse> PostJsonAsync<TResponse>(string requestUri, object obj, CancellationToken cancellationToken)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            using (var response = await this.HttpClient.PostAsync(requestUri, content, cancellationToken))
            {
                return await this.ProcessResponse<TResponse>(response);
            }
        }

        public async Task<TResponse> PutJsonAsync<TResponse>(string url, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.PutAsync(url, null, cancellationToken))
            {
                return await this.ProcessResponse<TResponse>(response);
            }
        }

        private async Task<TResponse> ProcessResponse<TResponse>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                string errorMessage = JsonConvert.DeserializeObject<ErrorResponse>(json).Error;

                if (errorMessage == null)
                {
                    throw;
                }

                throw new TvDbServerException(errorMessage, response.StatusCode, ex);
            }

            return JsonConvert.DeserializeObject<TResponse>(json);
        }
    }
}