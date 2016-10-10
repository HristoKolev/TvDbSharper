namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IUpdatesMessages
    {
        IReadOnlyDictionary<int, string> GetAsync { get; }
    }
}