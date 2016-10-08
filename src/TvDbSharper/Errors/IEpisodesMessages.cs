namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IEpisodesMessages
    {
        IDictionary<int, string> GetAsync { get; }
    }
}