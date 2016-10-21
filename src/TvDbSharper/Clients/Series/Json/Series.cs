namespace TvDbSharper.Clients.Series.Json
{
    public class Series
    {
        public string Added { get; set; }

        public string AirsDayOfWeek { get; set; }

        public string AirsTime { get; set; }

        public string[] Aliases { get; set; }

        public string Banner { get; set; }

        public string FirstAired { get; set; }

        public string[] Genre { get; set; }

        public int Id { get; set; }

        public string ImdbId { get; set; }

        public long LastUpdated { get; set; }

        public string Network { get; set; }

        public string NetworkId { get; set; }

        public string Overview { get; set; }

        public string Rating { get; set; }

        public string Runtime { get; set; }

        /// <summary>
        /// <para>TV.com ID</para>
        /// <para>Don't confuse with the Id property.</para>
        /// <para>Usually it is an integer, but there is nothing stopping users of http://thetvdb.com from changing it into any value. 
        /// This has happend before.</para>
        /// </summary>
        public string SeriesId { get; set; }

        public string SeriesName { get; set; }

        public decimal? SiteRating { get; set; }

        public int? SiteRatingCount { get; set; }

        public string Status { get; set; }

        public string Zap2itId { get; set; }
    }
}