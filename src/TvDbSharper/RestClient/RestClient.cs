namespace TvDbSharper.RestClient
{
    using TvDbSharper.JsonApi.Authentication;
    using TvDbSharper.JsonApi.Episodes;
    using TvDbSharper.JsonApi.Languages;
    using TvDbSharper.JsonApi.Search;
    using TvDbSharper.JsonApi.Series;
    using TvDbSharper.JsonApi.Updates;
    using TvDbSharper.JsonApi.Users;
    using TvDbSharper.JsonClient;

    public class RestClient : IRestClient
    {
        public RestClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;

            this.Authentication = new AuthenticationClient(this.JsonClient);
            this.Episodes = new EpisodesClient(this.JsonClient);
            this.Languages = new LanguagesClient(this.JsonClient);
            this.Search = new SearchClient(this.JsonClient);
            this.Series = new SeriesClient(this.JsonClient);
            this.Updates = new UpdatesClient(this.JsonClient);
            this.Users = new UsersClient(this.JsonClient);
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