namespace TvDbSharper.Errors
{
    using System.Collections.Generic;
    using System.Net;

    internal class ErrorMessages
    {
        static ErrorMessages()
        {
            Authentication = new AuthenticationMessages();
            Episodes = new EpisodesMessages();
            Languages = new LanguagesMessages();
            Search = new SearchMessages();
            Updates = new UpdatesMessages();
            Series = new SeriesMessages();
            Users = new UsersMessages();
        }

        public static AuthenticationMessages Authentication { get; }

        public static EpisodesMessages Episodes { get; }

        public static LanguagesMessages Languages { get; }

        public static SearchMessages Search { get; }

        public static SeriesMessages Series { get; }

        public static UpdatesMessages Updates { get; }

        public static UsersMessages Users { get; }
    }

    public class AuthenticationMessages
    {
        public IReadOnlyDictionary<HttpStatusCode, string> AuthenticateAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Invalid credentials" }
        };

        public IReadOnlyDictionary<HttpStatusCode, string> RefreshTokenAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" }
        };
    }

    public class EpisodesMessages
    {
        public IReadOnlyDictionary<HttpStatusCode, string> GetAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "The given episode ID does not exist" }
        };
    }

    public class LanguagesMessages
    {
        public IReadOnlyDictionary<HttpStatusCode, string> GetAllAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" }
        };

        public IReadOnlyDictionary<HttpStatusCode, string> GetAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "The given language ID does not exist" }
        };
    }

    public class SeriesMessages
    {
        public IReadOnlyDictionary<HttpStatusCode, string> GetAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "The given series ID does not exist" }
        };

        // ReSharper disable once InconsistentNaming
        public IReadOnlyDictionary<HttpStatusCode, string> GetImagesAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "The given series ID does not exist or the query returns no results" }
        };
    }

    public class SearchMessages
    {
        public IReadOnlyDictionary<HttpStatusCode, string> SearchSeriesAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No records are found that match your query" }
        };
    }

    public class UpdatesMessages
    {
        public IReadOnlyDictionary<HttpStatusCode, string> GetAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No records exist for the given timespan" }
        };
    }

    public class UsersMessages
    {
        public IReadOnlyDictionary<HttpStatusCode, string> AddToFavoritesAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No information exists for the current user" },
            { (HttpStatusCode)409, "Requested record could not be updated" }
        };

        public IReadOnlyDictionary<HttpStatusCode, string> GetAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No information exists for the current user" }
        };

        public IReadOnlyDictionary<HttpStatusCode, string> GetFavoritesAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No information exists for the current user" }
        };

        public IReadOnlyDictionary<HttpStatusCode, string> GetRatingsAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No information exists for the current user" }
        };

        public IReadOnlyDictionary<HttpStatusCode, string> RateAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No rating is found that matches your given parameters" }
        };

        public IReadOnlyDictionary<HttpStatusCode, string> RemoveFromFavoritesAsync { get; } = new Dictionary<HttpStatusCode, string>
        {
            { (HttpStatusCode)401, "Your JWT token is missing or expired" },
            { (HttpStatusCode)404, "No information exists for the current user" },
            { (HttpStatusCode)409, "Requested record could not be deleted" }
        };
    }
}