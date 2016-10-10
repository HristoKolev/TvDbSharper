namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface ISeriesMessages
    {
        IReadOnlyDictionary<int, string> GetAsync { get; }

        IReadOnlyDictionary<int, string> GetImagesAsync { get; }
    }
}