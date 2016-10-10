namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class UsersMessages : IUsersMessages
    {
        public IReadOnlyDictionary<int, string> AddToFavoritesAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No information exists for the current user" },
            { 409, "Requested record could not be updated" }
        };

        public IReadOnlyDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No information exists for the current user" }
        };

        public IReadOnlyDictionary<int, string> GetFavoritesAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No information exists for the current user" }
        };

        public IReadOnlyDictionary<int, string> GetRatingsAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No information exists for the current user" }
        };

        public IReadOnlyDictionary<int, string> RateAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No rating is found that matches your given parameters" }
        };

        public IReadOnlyDictionary<int, string> RemoveFromFavoritesAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No information exists for the current user" },
            { 409, "Requested record could not be deleted" }
        };
    }
}