namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class UpdatesMessages : IUpdatesMessages
    {
        public IReadOnlyDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No records exist for the given timespan" }
        };
    }
}