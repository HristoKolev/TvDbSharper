namespace TvDbSharper.Clients.Series
{
    public class BasicEpisode
    {
        public int? AbsoluteNumber { get; set; }

        public int? AiredEpisodeNumber { get; set; }

        public int? AiredSeason { get; set; }

        public decimal? DvdEpisodeNumber { get; set; }

        public int? DvdSeason { get; set; }

        public string EpisodeName { get; set; }

        public string FirstAired { get; set; }

        public int Id { get; set; }

        public long LastUpdated { get; set; }

        public string Overview { get; set; }
    }
}