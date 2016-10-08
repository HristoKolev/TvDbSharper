namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class EpisodesMessages : IEpisodesMessages
    {
        public IDictionary<int, string> GetAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "The given episode ID does not exist" }
        };
    }
}