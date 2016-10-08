namespace TvDbSharper
{
    using System.Collections.Generic;

    public static class ErrorMessages
    {
        static ErrorMessages()
        {
            Authentication = new AuthenticationMessages();
            Episodes = new EpisodesMessages();
            Languages = new LanguagesMessages();
            Search = new SearchMessages();
            Updates = new UpdatesMessages();
            Series = new SeriesMessages();
        }

        public static AuthenticationMessages Authentication { get; }

        public static EpisodesMessages Episodes { get; }

        public static LanguagesMessages Languages { get; }

        public static SearchMessages Search { get; }

        public static SeriesMessages Series { get; }

        public static UpdatesMessages Updates { get; }
    }

    public class AuthenticationMessages
    {
        public IDictionary<int, string> AuthenticateAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Invalid credentials" }
        };

        public IDictionary<int, string> RefreshTokenAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" }
        };
    }

    public class EpisodesMessages
    {
        public IDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "The given episode ID does not exist" }
        };
    }

    public class LanguagesMessages
    {
        public IDictionary<int, string> GetAllAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" }
        };

        public IDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "The given language ID does not exist" }
        };
    }

    public class SearchMessages
    {
        public IDictionary<int, string> SearchSeriesAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No records are found that match your query" }
        };
    }

    public class UpdatesMessages
    {
        public IDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No records exist for the given timespan" }
        };
    }

    public class SeriesMessages
    {
        public IDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "The given series ID does not exist" }
        };

        // ReSharper disable once InconsistentNaming
        public IDictionary<int, string> GetImagesAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "The given series ID does not exist or the query returns no results" }
        };
    }
}