namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface ILanguagesMessages
    {
        IDictionary<int, string> GetAllAsync { get; }

        IDictionary<int, string> GetAsync { get; }
    }
}