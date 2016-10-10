namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface ILanguagesMessages
    {
        IReadOnlyDictionary<int, string> GetAllAsync { get; }

        IReadOnlyDictionary<int, string> GetAsync { get; }
    }
}