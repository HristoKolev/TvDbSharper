namespace TvDbSharper.JsonSchemas
{
    public class SeriesResponse
    {
        public string added { get; set; }

        public object addedBy { get; set; }

        public string airsDayOfWeek { get; set; }

        public string airsTime { get; set; }

        public string[] aliases { get; set; }

        public string banner { get; set; }

        public string firstAired { get; set; }

        public string[] genre { get; set; }

        public int id { get; set; }

        public string imdbId { get; set; }

        public int lastUpdated { get; set; }

        public string network { get; set; }

        public string networkId { get; set; }

        public string overview { get; set; }

        public string rating { get; set; }

        public string runtime { get; set; }

        public string seriesId { get; set; }

        public string seriesName { get; set; }

        public double siteRating { get; set; }

        public int siteRatingCount { get; set; }

        public string status { get; set; }

        public string zap2itId { get; set; }
    }
}