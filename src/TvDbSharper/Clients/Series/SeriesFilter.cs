namespace TvDbSharper.Clients.Series
{
    using System;

    [Flags]
    public enum SeriesFilter
    {
        Banner = 1,

        Status = 2,

        Genre = 4,

        Rating = 8,

        NetworkId = 16,

        Overview = 32,

        ImdbId = 64,

        Zap2itId = 128,

        Added = 256,

        AirsDayOfWeek = 512,

        AirsTime = 1024,

        SiteRating = 2048,

        Aliases = 4096,

        SeriesId = 8192,

        FirstAired = 16384,

        Runtime = 32768,

        LastUpdated = 65536,

        SiteRatingCount = 131072,

        Id = 262144,

        SeriesName = 524288,

        Network = 1048576,

        AddedBy = 2097152
    }
}