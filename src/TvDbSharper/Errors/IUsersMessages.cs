namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IUsersMessages
    {
        IDictionary<int, string> AddToFavoritesAsync { get; }

        IDictionary<int, string> GetAsync { get; }

        IDictionary<int, string> GetFavoritesAsync { get; }

        IDictionary<int, string> GetRatingsAsync { get; }

        IDictionary<int, string> RateAsync { get; }

        IDictionary<int, string> RemoveFromFavoritesAsync { get; }
    }
}