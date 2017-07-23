namespace TvDbSharper.Clients.Search
{
    /// <summary>
    /// An enum used for searching for series with <see cref="T:ISearchClient.SearchSeriesAsync"/>,
    /// each value represents a property by which the search is performed
    /// </summary>
    public enum SearchParameter
    {
        Name,

        ImdbId,

        // ReSharper disable once InconsistentNaming
        Zap2itId
    }
}