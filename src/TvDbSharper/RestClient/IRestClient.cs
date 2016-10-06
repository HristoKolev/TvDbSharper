namespace TvDbSharper.RestClient
{
    using TvDbSharper.JsonApi.Authentication;
    using TvDbSharper.JsonApi.Episodes;
    using TvDbSharper.JsonApi.Languages;
    using TvDbSharper.JsonApi.Search;
    using TvDbSharper.JsonApi.Series;
    using TvDbSharper.JsonApi.Updates;
    using TvDbSharper.JsonApi.Users;

    public interface IRestClient
    {
        IAuthenticationClient Authentication { get; }

        IEpisodesClient Episodes { get; }

        ILanguagesClient Languages { get; }

        ISearchClient Search { get; }

        ISeriesClient Series { get; }

        IUpdatesClient Updates { get; }

        IUsersClient Users { get; }
    }
}