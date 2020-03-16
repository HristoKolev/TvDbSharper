# 3.1.1

* Fixed a potential async issue.

# 3.1.0

* Added property `Image` (string) to the `SeriesSearchResult` model.

* Added an overload to the `TvDbClient` that accepts an HttpClient instance.

* Moved baseUrl state to the HttpClient instance.

* Moved language and auth token state to the HttpClient instance as default headers (AcceptLanguage and Authorization).


# 3.0.1

* Changed the type of property Series.Season from `int` to `int?`.    

# 3.0.0

* Removed property `Director` from the ` EpisodeRecord` model.
* Added property `ContentRating` (string) to the `EpisodeRecord` model.
* Added property `IsMovie` (int) to the `EpisodeRecord` model.
* Renamed property `Previous` to `Prev` in the `Links` model.
* Added property `FanArt` (string) to the `SeriesSearchResult` model.
* Added property `Poster` (string) to the `SeriesSearchResult` model.
* Added property `Poster` (string) to the `Series` model.
* Added property `Season` (int) to the `Series` model.
* Added property `FanArt` (string) to the `Series` model.
* Added property `Language` (string) to the `Series` model.

* Added method `SearchSeriesBySlugAsync` to the search client.
* Added method overload `SearchSeriesAsync` that accepts string type parameter to the search client.

* Added method overload `GetImagesAsync` with alternative query model that allows strings to be used for query type.

* Moved to `HttpClient` for http requests. 


# 2.0.0

* Removed the property `Seasonwide` from the `ImagesSummary` model.

* Changed the type of the `Id` property of the `Image` model from `int?` to `int`.
* Added `AddedBy` (int?) property to the `Series` model.

* Added `Slug ` (string) property to the `Series` model.
* Added `Slug ` (string) property to the `SeriesSearchResult` model.

* Removed the `BasicEpisode` model in favor of `EpisodeRecord`.
* Changed the type of the `LastUpdatedBy` property of the `EpisodeRecord` model from `string` to `int?`.
* Changed the type of the `SeriesId` property of the `EpisodeRecord` model from `string` to `int`.
* Changed the type of the `Id` property of the `Language` model from `int?` to `int`.
* Added `Language` property to the `EpisodeRecord` model that is of the new type `Epi
* Added `AiredSeasonID` (int?) property to the `EpisodeRecord` model.sodeLanguage`:

```csharp

public class EpisodeLanguage
{
	public string EpisodeName { get; set; }

	public string Overview { get; set; }
}

```

* Updated the `Json.NET` package from version `10.0.3` to `11.0.2`.

* Updated the `TvDbSharper.Tests` project to newer framework and library versions.

# 1.0.1
* Fixed a bug where the HttpWebRequest throws for some content type values in .NET Full Framework

# 1.0.0 - Breaking changes
* Changed namespaces.
* Replaced any references to `http` or the `HttpClient`.
* No change of client semantics.
* No change of method names and parameters.
* Increased encapsulation.
* No change in Dto classes.

# 0.6.3
* Fixed a bug where the value passed to `SearchClient` methods was not properly encoded.

# 0.6.2
* Added `Token` property to the `Authentication` client in order to provide access to the JWT

# 0.6.1
* Added new fields(`long LastUpdated` and `string FirstAired`) to the `BasicEpisode` model

# 0.6.0
* `JsonClient` class is not internal
* Every await now has `ConfigureAwait(false)`

# 0.5.9
* Removed async/await form methods that don't need it so that the compiler doesn't needlessly generate state machines 

# 0.5.8
* Removed the `async` keyword from methods that don't need it, to improve performance.

# 0.5.7
* Added `ToDateTime()` extension method to the `long` type to mirror the one on the `long?`

# 0.5.6
* Changed the type of `Id` property from `int?` to `int` in the `SeriesSearchResult` model

# 0.5.5
* Changed the type of `Id` property from `int?` to `int` in the `Actor` model

# 0.5.4
* Changed the type of `Id` property from `int?` to `int` in the `Series`, `BasicEpisode`, `EpisodeRecord` and `Update` models
* Changed the type of `LastUpdated` property from `long?` to `long` in the `Series`, `EpisodeRecord` and `Update` models

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
