# 0.5.3
* Changed the type of `DvdEpisodeNumber` from `int?` to `decimal?` in the `EpisodeRecord` and `BasicEpisode` models

# 0.5.2
* Changed the type of `SeriesId` property from `int?` to `string` in the `Series` model

# 0.5.1
* Chnaged the type of `LastUpdated` property form `int?` to `long?` in `EpisodeRecord`, `Series` and `Update` models

# 0.5.0
* Changed the type of `EpisodeRecord.SiteRating` from `int?` to `decimal?`
* Changed the type of `UserRatings.Rating` from `int?` to `decimal?`

# 0.4.1
* Removed redundant library `System.Reflection`

# 0.4.0
* Removed target netcoreapp1.0
* Dropped target .NET Standard Library version to 1.1, that adds support for .NET 4.5, Windows 8.0 and Windows Phone 8.1