namespace TvDbSharper.RestClient
{
    using TvDbSharper.Api.Authentication;
    using TvDbSharper.Api.Episodes;
    using TvDbSharper.Api.Languages;
    using TvDbSharper.Api.Search;
    using TvDbSharper.Api.Series;
    using TvDbSharper.JsonClient;

    public class RestClient
    {
        public RestClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;

            this.Authentication = new AuthenticationClient(this.JsonClient);
            this.Series = new SeriesClient(this.JsonClient);
            this.Search = new SearchClient(this.JsonClient);
            this.Episodes = new EpisodesClient(this.JsonClient);
            this.Languages = new LanguagesClient(this.JsonClient);
        }

        public IAuthenticationClient Authentication { get; }

        public IEpisodesClient Episodes { get; }

        public ILanguagesClient Languages { get; }

        public ISearchClient Search { get; }

        public ISeriesClient Series { get; }

        private IJsonClient JsonClient { get; }
    }
}