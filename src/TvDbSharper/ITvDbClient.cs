namespace TvDbSharper
{
    using TvDbSharper.Clients.Authentication;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Clients.Languages;
    using TvDbSharper.Clients.Search;
    using TvDbSharper.Clients.Series;
    using TvDbSharper.Clients.Updates;
    using TvDbSharper.Clients.Users;

    public interface ITvDbClient
    {
        string AcceptedLanguage { get; set; }

        IAuthenticationClient Authentication { get; }

        string BaseUrl { get; set; }

        IEpisodesClient Episodes { get; }

        ILanguagesClient Languages { get; }

        ISearchClient Search { get; }

        ISeriesClient Series { get; }

        IUpdatesClient Updates { get; }

        IUsersClient Users { get; }
    }
}