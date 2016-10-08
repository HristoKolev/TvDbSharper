namespace TvDbSharper.Errors
{
    using System.Collections.Generic;

    public interface ISeriesMessages
    {
        IDictionary<int, string> GetAsync { get; }

        IDictionary<int, string> GetImagesAsync { get; }
    }
}