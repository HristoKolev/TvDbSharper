namespace TvDbSharper.Errors
{
    public class ErrorMessages : IErrorMessages
    {
        public ErrorMessages()
        {
            this.Authentication = new AuthenticationMessages();
            this.Episodes = new EpisodesMessages();
            this.Languages = new LanguagesMessages();
            this.Search = new SearchMessages();
            this.Updates = new UpdatesMessages();
            this.Series = new SeriesMessages();
            this.Users = new UsersMessages();
        }

        public IAuthenticationMessages Authentication { get; }

        public IEpisodesMessages Episodes { get; }

        public ILanguagesMessages Languages { get; }

        public ISearchMessages Search { get; }

        public ISeriesMessages Series { get; }

        public IUpdatesMessages Updates { get; }

        public IUsersMessages Users { get; }
    }
}