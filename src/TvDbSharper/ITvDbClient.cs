namespace TvDbSharper
{
    public interface ITvDbClient
    {
        /// <summary>
        /// Used for obtaining and refreshing your JWT token
        /// </summary>
        IAuthenticationClient Authentication { get; }

        string BaseUrl { get; set; }
    }
}
