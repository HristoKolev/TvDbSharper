namespace TvDbSharper
{
    using System;
    using System.Linq;
    using System.Net.Http;

    using TvDbSharper.Clients.Authentication;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Clients.Languages;
    using TvDbSharper.Clients.Search;
    using TvDbSharper.Clients.Series;
    using TvDbSharper.Clients.Updates;
    using TvDbSharper.Clients.Users;
    using TvDbSharper.Errors;

    public class TvDbClient : ITvDbClient
    {
        private const string DefaultAcceptedLanguage = "en";

        private const string DefaultBaseUrl = "https://api.thetvdb.com";

        public TvDbClient()
            : this(new HttpClient())
        {
        }

        public TvDbClient(HttpClient httpClient)
        {
            this.HttpClient = httpClient;

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DefaultBaseUrl;
            }

            var errorMessages = new ErrorMessages();
            var jsonClient = new JsonClient.JsonClient(this.HttpClient);

            this.Authentication = new AuthenticationClient(jsonClient, errorMessages);
            this.Episodes = new EpisodesClient(jsonClient, errorMessages);
            this.Languages = new LanguagesClient(jsonClient, errorMessages);
            this.Search = new SearchClient(jsonClient, errorMessages);
            this.Series = new SeriesClient(jsonClient, errorMessages);
            this.Updates = new UpdatesClient(jsonClient, errorMessages);
            this.Users = new UsersClient(jsonClient, errorMessages);
        }

        public string AcceptedLanguage
        {
            get
            {
                return this.HttpClient.DefaultRequestHeaders.AcceptLanguage.FirstOrDefault()?.Value ?? DefaultAcceptedLanguage;
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

                this.HttpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
                this.HttpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd(value);
            }
        }

        /// <summary>
        /// Used for obtaining and refreshing your JWT token
        /// </summary>
        public IAuthenticationClient Authentication { get; }

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

        private HttpClient HttpClient { get; }
    }
}