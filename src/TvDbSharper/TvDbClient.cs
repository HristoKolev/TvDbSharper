namespace TvDbSharper
{
    using System;
    using System.Linq;

    using TvDbSharper.Clients.Authentication;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Clients.Languages;
    using TvDbSharper.Clients.Search;
    using TvDbSharper.Clients.Series;
    using TvDbSharper.Clients.Updates;
    using TvDbSharper.Clients.Users;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class TvDbClient : ITvDbClient
    {
        private const string DefaultAcceptedLanguage = "en";

        private const string DefaultBaseUrl = "https://api.thetvdb.com";

        public TvDbClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;

            if (this.BaseUrl == null)
            {
                this.BaseUrl = DefaultBaseUrl;
            }

            var errorMessages = new ErrorMessages();

            this.Authentication = new AuthenticationClient(this.JsonClient, errorMessages);
            this.Episodes = new EpisodesClient(this.JsonClient, errorMessages);
            this.Languages = new LanguagesClient(this.JsonClient, errorMessages);
            this.Search = new SearchClient(this.JsonClient, errorMessages);
            this.Series = new SeriesClient(this.JsonClient, errorMessages);
            this.Updates = new UpdatesClient(this.JsonClient, errorMessages);
            this.Users = new UsersClient(this.JsonClient, errorMessages);
        }

        public TvDbClient()
            : this(new JsonClient.JsonClient())
        {
        }

        public string AcceptedLanguage
        {
            get
            {
                return this.JsonClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.FirstOrDefault()?.Value ?? DefaultAcceptedLanguage;
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

                this.JsonClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
                this.JsonClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd(value);
            }
        }

        public IAuthenticationClient Authentication { get; }

        public string BaseUrl
        {
            get
            {
                return this.JsonClient.HttpClient.BaseAddress?.AbsoluteUri?.TrimEnd('/');
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

                this.JsonClient.HttpClient.BaseAddress = new Uri(value);
            }
        }

        public IEpisodesClient Episodes { get; }

        public ILanguagesClient Languages { get; }

        public ISearchClient Search { get; }

        public ISeriesClient Series { get; }

        public IUpdatesClient Updates { get; }

        public IUsersClient Users { get; }

        private IJsonClient JsonClient { get; }
    }
}