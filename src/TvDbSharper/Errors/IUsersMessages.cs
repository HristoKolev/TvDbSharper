namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IUsersMessages
    {
        IReadOnlyDictionary<int, string> AddToFavoritesAsync { get; }

        IReadOnlyDictionary<int, string> GetAsync { get; }

        IReadOnlyDictionary<int, string> GetFavoritesAsync { get; }

        IReadOnlyDictionary<int, string> GetRatingsAsync { get; }

        IReadOnlyDictionary<int, string> RateAsync { get; }

        IReadOnlyDictionary<int, string> RemoveFromFavoritesAsync { get; }
    }
}