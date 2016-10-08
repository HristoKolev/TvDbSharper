namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public class SeriesMessages : ISeriesMessages
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