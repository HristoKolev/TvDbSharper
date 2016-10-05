namespace TvDbSharper.RestClient
{
    using TvDbSharper.Api.Authentication;
    using TvDbSharper.Api.Episodes;
    using TvDbSharper.Api.Languages;
    using TvDbSharper.Api.Search;
    using TvDbSharper.Api.Series;
    using TvDbSharper.Api.Updates;
    using TvDbSharper.Api.Users;

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