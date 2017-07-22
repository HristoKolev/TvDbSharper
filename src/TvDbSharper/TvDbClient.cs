namespace TvDbSharper
{
    using System;

    using TvDbSharper.Clients.Authentication;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Clients.Languages;
    using TvDbSharper.Clients.Search;
    using TvDbSharper.Clients.Series;
    using TvDbSharper.Clients.Updates;
    using TvDbSharper.Clients.Users;

    public class TvDbClient : ITvDbClient
    {
        private const string DefaultAcceptedLanguage = "en";

        private const string DefaultBaseUrl = "https://api.thetvdb.com";

        private const string AcceptLanguage = "Accept-Language";

        public TvDbClient()
            : this(new ApiClient(), new Parser())
        {
        }

        public TvDbClient(IApiClient apiClient, IParser parser)
        {
            this.ApiClient = apiClient;

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DefaultBaseUrl;
            }

            this.Authentication = new AuthenticationClient(apiClient, parser);
            this.Episodes = new EpisodesClient(apiClient, parser);
            this.Languages = new LanguagesClient(apiClient, parser);
            this.Search = new SearchClient(apiClient, parser);
            this.Series = new SeriesClient(apiClient, parser);
            this.Updates = new UpdatesClient(apiClient, parser);
            this.Users = new UsersClient(apiClient, parser);
        }

        public string AcceptedLanguage
        {
            get => this.ApiClient.DefaultRequestHeaders[AcceptLanguage] ?? DefaultAcceptedLanguage;

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

                this.ApiClient.DefaultRequestHeaders[AcceptLanguage] = value;
            }
        }

        /// <summary>
        /// Used for obtaining and refreshing your JWT token
        /// </summary>
        public IAuthenticationClient Authentication { get; }

        public string BaseUrl
        {
            get => this.ApiClient.BaseAddress;

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

                this.ApiClient.BaseAddress = value;
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