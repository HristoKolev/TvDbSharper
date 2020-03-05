using Newtonsoft.Json;

namespace TvDbSharper.Dto
{
    /// <summary>
    /// An enum used for searching for series with <see cref="T:ISearchClient.SearchSeriesAsync"/>,
    /// each value represents a property by which the search is performed
    /// </summary>
    public enum SearchParameter
    {
        Name,

        ImdbId,

        // ReSharper disable once InconsistentNaming
        Zap2itId,
        
        Slug,
    }

#if DEBUG
    [JsonObject(ItemRequired = Required.AllowNull)]
#endif
    public class SeriesSearchResult
    {
        public string[] Aliases { get; set; }

        public string Banner { get; set; }
        
#if DEBUG
        [JsonProperty(Required = Required.Default)]
#endif
        public string FanArt { get; set; }
      
#if DEBUG
        [JsonProperty(Required = Required.Default)]
#endif
        public string Poster { get; set; }

        public string FirstAired { get; set; }

        public int Id { get; set; }

        public string Network { get; set; }

#if DEBUG
        [JsonProperty(Required = Required.Default)]
#endif
        public string Image { get; set; }

#if DEBUG
        [JsonProperty(Required = Required.Default)]
#endif
        public string Overview { get; set; }

        public string SeriesName { get; set; }

        public string Slug { get; set; }

        public string Status { get; set; }
    }
}