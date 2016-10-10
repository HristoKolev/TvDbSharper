namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class SearchMessages : ISearchMessages
    {
        public IReadOnlyDictionary<int, string> SearchSeriesAsync { get; } = new Dictionary<int, string>
        {
            { 401, "Your JWT token is missing or expired" },
            { 404, "No records are found that match your query" }
        };
    }
}