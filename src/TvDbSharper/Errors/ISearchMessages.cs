namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface ISearchMessages
    {
        IReadOnlyDictionary<int, string> SearchSeriesAsync { get; }
    }
}