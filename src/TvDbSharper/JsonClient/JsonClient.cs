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

    internal class JsonClient : IJsonClient
    {
        public JsonClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;

            this.HttpClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");

            this.PostSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
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

        private HttpClient HttpClient { get; }

        private JsonSerializerSettings PostSerializerSettings { get; }

        public async Task<TResponse> DeleteJsonAsync<TResponse>(string requestUri, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false))
            {
                return await ProcessResponseAsync<TResponse>(response).ConfigureAwait(false);
            }
        }

        public async Task<HttpResponseHeaders> GetHeadersAsync(string requestUri, CancellationToken cancellationToken)
        {
            var message = new HttpRequestMessage(HttpMethod.Head, requestUri);

            using (var response = await this.HttpClient.SendAsync(message, cancellationToken).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();

                return response.Headers;
            }
        }

        public async Task<TResponse> GetJsonAsync<TResponse>(string requestUri, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false))
            {
                return await ProcessResponseAsync<TResponse>(response).ConfigureAwait(false);
            }
        }

        public async Task<TResponse> PostJsonAsync<TResponse>(string requestUri, object obj, CancellationToken cancellationToken)
        {
            string json = JsonConvert.SerializeObject(obj, this.PostSerializerSettings);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await this.HttpClient.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false))
            {
                return await ProcessResponseAsync<TResponse>(response).ConfigureAwait(false);
            }
        }

        public async Task<TResponse> PutJsonAsync<TResponse>(string requestUri, CancellationToken cancellationToken)
        {
            using (var response = await this.HttpClient.PutAsync(requestUri, null, cancellationToken).ConfigureAwait(false))
            {
                return await ProcessResponseAsync<TResponse>(response).ConfigureAwait(false);
            }
        }

        private static async Task<TResponse> ProcessResponseAsync<TResponse>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

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