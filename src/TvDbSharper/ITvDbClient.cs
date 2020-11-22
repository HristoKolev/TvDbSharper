namespace TvDbSharper
{
    public interface ITvDbClient
    {
        string AcceptedLanguage { get; set; }

        /// <summary>
        /// Used for obtaining and refreshing your JWT token
        /// </summary>
        IAuthenticationClient Authentication { get; }

        string BaseUrl { get; set; }
    }
}
