namespace TvDbSharper
{
    using System;
    using System.Net.Http;
    using Infrastructure;

    public class TvDbClient : ITvDbClient
    {
        private const string DEFAULT_BASE_URL = "https://api4.thetvdb.com/v4/";

        public TvDbClient()
            : this(new HttpClient()) { }

        public TvDbClient(HttpClient httpClient)
            : this(new ApiClient(httpClient), new Parser()) { }

        internal TvDbClient(IApiClient apiClient, IParser parser)
        {
            this.ApiClient = apiClient;

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DEFAULT_BASE_URL;
            }

            this.Authentication = new AuthenticationClient(this.ApiClient, parser);
            this.Artwork = new ArtworkClient(this.ApiClient, parser);
        }

        /// <summary>
        /// Used for obtaining and refreshing your JWT token
        /// </summary>
        public IAuthenticationClient Authentication { get; }

        public string BaseUrl
        {
            get => this.ApiClient.HttpClient.BaseAddress?.ToString();

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

                this.ApiClient.HttpClient.BaseAddress = new Uri(value);
            }
        }

        public IArtworkClient Artwork { get; }

        private IApiClient ApiClient { get; }
    }

    public interface ITvDbClient
    {
        /// <summary>
        /// Used for obtaining and refreshing your JWT token
        /// </summary>
        IAuthenticationClient Authentication { get; }

        IArtworkClient Artwork { get; }

        string BaseUrl { get; set; }
    }
}
