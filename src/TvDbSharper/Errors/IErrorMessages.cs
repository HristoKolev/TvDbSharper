namespace TvDbSharper.Errors
{
    public interface IErrorMessages
    {
        IAuthenticationMessages Authentication { get; }

        IEpisodesMessages Episodes { get; }

        ILanguagesMessages Languages { get; }

        ISearchMessages Search { get; }

        ISeriesMessages Series { get; }

        IUpdatesMessages Updates { get; }

        IUsersMessages Users { get; }
    }
}