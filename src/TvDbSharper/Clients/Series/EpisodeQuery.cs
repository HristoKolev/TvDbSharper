namespace TvDbSharper.Clients.Series
{
    public class EpisodeQuery
    {
        public int? AbsoluteNumber { get; set; }

        public int? AiredEpisode { get; set; }

        public int? AiredSeason { get; set; }

        public int? DvdEpisode { get; set; }

        public int? DvdSeason { get; set; }

        public string FirstAired { get; set; }

        public string ImdbId { get; set; }
    }
}