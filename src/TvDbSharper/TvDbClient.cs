namespace TvDbSharper
{
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
        public TvDbClient(IJsonClient jsonClient, IErrorMessages errorMessages)
        {
            this.JsonClient = jsonClient;

            this.Authentication = new AuthenticationClient(this.JsonClient, errorMessages);
            this.Episodes = new EpisodesClient(this.JsonClient, errorMessages);
            this.Languages = new LanguagesClient(this.JsonClient, errorMessages);
            this.Search = new SearchClient(this.JsonClient, errorMessages);
            this.Series = new SeriesClient(this.JsonClient, errorMessages);
            this.Updates = new UpdatesClient(this.JsonClient, errorMessages);
            this.Users = new UsersClient(this.JsonClient, errorMessages);
        }

        public TvDbClient()
            : this(new JsonClient.JsonClient(), new ErrorMessages())
        {
        }

        public IAuthenticationClient Authentication { get; }

        public IEpisodesClient Episodes { get; }

        public ILanguagesClient Languages { get; }

        public ISearchClient Search { get; }

        public ISeriesClient Series { get; }

        public IUpdatesClient Updates { get; }

        public IUsersClient Users { get; }

        private IJsonClient JsonClient { get; }
    }
}