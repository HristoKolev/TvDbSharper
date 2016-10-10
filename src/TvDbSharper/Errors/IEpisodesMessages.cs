namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IEpisodesMessages
    {
        IReadOnlyDictionary<int, string> GetAsync { get; }
    }
}