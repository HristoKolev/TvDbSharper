namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface IUpdatesMessages
    {
        IDictionary<int, string> GetAsync { get; }
    }
}