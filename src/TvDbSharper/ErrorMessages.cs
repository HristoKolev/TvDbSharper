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
        }

        public static AuthenticationMessages Authentication { get; }

        public static EpisodesMessages Episodes { get; }

        public static LanguagesMessages Languages { get; }
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
}