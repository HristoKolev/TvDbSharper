namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface ISearchMessages
    {
        IDictionary<int, string> SearchSeriesAsync { get; }
    }
}