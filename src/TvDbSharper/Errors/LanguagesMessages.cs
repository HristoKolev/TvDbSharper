namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class LanguagesMessages : ILanguagesMessages
    {
        public IReadOnlyDictionary<int, string> GetAllAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" }
        };

        public IReadOnlyDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "The given language ID does not exist" }
        };
    }
}