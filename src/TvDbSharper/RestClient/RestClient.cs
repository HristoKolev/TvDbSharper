namespace TvDbSharper.RestClient
{
    using TvDbSharper.Api.Authentication;
    using TvDbSharper.Api.Episodes;
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
        }

        public IAuthenticationClient Authentication { get; }

        public IEpisodesClient Episodes { get; }

        public ISearchClient Search { get; }

        public ISeriesClient Series { get; }

        private IJsonClient JsonClient { get; }

        // }
        // return await this.GetDataAsync<SearchResponse[]>($"/search/series?name={Uri.EscapeDataString(name)}", cancellationToken);
        // {

        // public async Task<SearchResponse[]> SearchSeriesAsync(string name, CancellationToken cancellationToken)
    }
}