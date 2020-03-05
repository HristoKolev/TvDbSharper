using System.Linq;
using System.Net.Http;

namespace TvDbSharper
{
    using System;

    using TvDbSharper.Clients;
    using TvDbSharper.Infrastructure;

    public class TvDbClient : ITvDbClient
    {
        private const string DefaultAcceptedLanguage = "en";

        private const string DefaultBaseUrl = "https://api.thetvdb.com";

        public TvDbClient()
            : this(new HttpClient())
        {
        }
        
        public TvDbClient(HttpClient httpClient)
            : this(new ApiClient(httpClient), new Parser())
        {
        }

        internal TvDbClient(IApiClient apiClient, IParser parser)
        {
            this.ApiClient = apiClient;

            if (this.AcceptedLanguage == null)
            {
                this.AcceptedLanguage = DefaultAcceptedLanguage;                
            }

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DefaultBaseUrl;
            }

            this.Authentication = new AuthenticationClient(this.ApiClient, parser);
            this.Episodes = new EpisodesClient(this.ApiClient, parser);
            this.Languages = new LanguagesClient(this.ApiClient, parser);
            this.Search = new SearchClient(this.ApiClient, parser);
            this.Series = new SeriesClient(this.ApiClient, parser);
            this.Updates = new UpdatesClient(this.ApiClient, parser);
            this.Users = new UsersClient(this.ApiClient, parser);
        }

        public string AcceptedLanguage
        {
            get => this.ApiClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.SingleOrDefault()?.ToString();

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

                this.ApiClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
                this.ApiClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd(value);
            }
        }

        /// <summary>
        /// Used for obtaining and refreshing your JWT token
        /// </summary>
        public IAuthenticationClient Authentication { get; }

        public string BaseUrl
        {
            get => this.ApiClient.HttpClient.BaseAddress?.ToString()?.TrimEnd('/');

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

        /// <summary>
        /// Used for getting information about a specific episode
        /// </summary>
        public IEpisodesClient Episodes { get; }

        /// <summary>
        /// Used for getting available languages and information about them
        /// </summary>
        public ILanguagesClient Languages { get; }

        /// <summary>
        /// Used for searching for a particular series
        /// </summary>
        public ISearchClient Search { get; }

        /// <summary>
        /// Used for getting information about a specific series
        /// </summary>
        public ISeriesClient Series { get; }

        /// <summary>
        /// Used for getting series that have been recently updated
        /// </summary>
        public IUpdatesClient Updates { get; }

        /// <summary>
        /// Used for working with the current user
        /// </summary>
        public IUsersClient Users { get; }

        private IApiClient ApiClient { get; }
    }
}