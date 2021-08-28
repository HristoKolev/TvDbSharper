namespace TvDbSharper
{
    using Newtonsoft.Json;

    public class AliasDto
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ArtworkBaseRecordDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class ArtworkExtendedRecordDto
    {
        [JsonProperty("episodeId")]
        public int EpisodeId { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("movieId")]
        public int MovieId { get; set; }

        [JsonProperty("networkId")]
        public int NetworkId { get; set; }

        [JsonProperty("peopleId")]
        public int PeopleId { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("seasonId")]
        public int SeasonId { get; set; }

        [JsonProperty("seriesId")]
        public int SeriesId { get; set; }

        [JsonProperty("seriesPeopleId")]
        public int SeriesPeopleId { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("thumbnailHeight")]
        public long ThumbnailHeight { get; set; }

        [JsonProperty("thumbnailWidth")]
        public long ThumbnailWidth { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public class ArtworkStatusDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ArtworkTypeDto
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("imageFormat")]
        public string ImageFormat { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recordType")]
        public string RecordType { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("thumbHeight")]
        public long ThumbHeight { get; set; }

        [JsonProperty("thumbWidth")]
        public long ThumbWidth { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public class AwardBaseRecordDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AwardCategoryBaseRecordDto
    {
        [JsonProperty("allowCoNominees")]
        public bool AllowCoNominees { get; set; }

        [JsonProperty("award")]
        public AwardBaseRecordDto Award { get; set; }

        [JsonProperty("forMovies")]
        public bool ForMovies { get; set; }

        [JsonProperty("forSeries")]
        public bool ForSeries { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class AwardCategoryExtendedRecordDto
    {
        [JsonProperty("allowCoNominees")]
        public bool AllowCoNominees { get; set; }

        [JsonProperty("award")]
        public AwardBaseRecordDto Award { get; set; }

        [JsonProperty("forMovies")]
        public bool ForMovies { get; set; }

        [JsonProperty("forSeries")]
        public bool ForSeries { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nominees")]
        public AwardNomineeBaseRecordDto[] Nominees { get; set; }
    }

    public class AwardExtendedRecordDto
    {
        [JsonProperty("categories")]
        public AwardCategoryBaseRecordDto[] Categories { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }
    }

    public class AwardNomineeBaseRecordDto
    {
        [JsonProperty("character")]
        public CharacterDto Character { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("episode")]
        public EpisodeBaseRecordDto Episode { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isWinner")]
        public bool IsWinner { get; set; }

        [JsonProperty("movie")]
        public MovieBaseRecordDto Movie { get; set; }

        [JsonProperty("series")]
        public SeriesBaseRecordDto Series { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class BiographyDto
    {
        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class CharacterDto
    {
        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("episodeId")]
        public int EpisodeId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonProperty("movieId")]
        public int MovieId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("peopleId")]
        public int PeopleId { get; set; }

        [JsonProperty("seriesId")]
        public int SeriesId { get; set; }

        [JsonProperty("sort")]
        public long Sort { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("personName")]
        public string PersonName { get; set; }
    }

    public class CompanyDto
    {
        [JsonProperty("activeDate")]
        public string ActiveDate { get; set; }

        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("inactiveDate")]
        public string InactiveDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("primaryCompanyType")]
        public long PrimaryCompanyType { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class CompanyTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ContentRatingDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }

    public class CountryDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortCode")]
        public string ShortCode { get; set; }
    }

    public class EntityDto
    {
        [JsonProperty("movieId")]
        public int MovieId { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("seriesId")]
        public int SeriesId { get; set; }
    }

    public class EntityTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("seriesId")]
        public int SeriesId { get; set; }
    }

    public class EntityUpdateDto
    {
        [JsonProperty("entityType")]
        public string EntityType { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("recordId")]
        public long RecordId { get; set; }

        [JsonProperty("timeStamp")]
        public long TimeStamp { get; set; }
    }

    public class EpisodeBaseRecordDto
    {
        [JsonProperty("aired")]
        public string Aired { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("imageType")]
        public int ImageType { get; set; }

        [JsonProperty("isMovie")]
        public long IsMovie { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonProperty("seasons")]
        public SeasonBaseRecordDto[] Seasons { get; set; }

        [JsonProperty("seriesId")]
        public long SeriesId { get; set; }
    }

    public class EpisodeExtendedRecordDto
    {
        [JsonProperty("aired")]
        public string Aired { get; set; }

        [JsonProperty("airsAfterSeason")]
        public int AirsAfterSeason { get; set; }

        [JsonProperty("airsBeforeEpisode")]
        public int AirsBeforeEpisode { get; set; }

        [JsonProperty("airsBeforeSeason")]
        public int AirsBeforeSeason { get; set; }

        [JsonProperty("awards")]
        public AwardBaseRecordDto[] Awards { get; set; }

        [JsonProperty("characters")]
        public CharacterDto[] Characters { get; set; }

        [JsonProperty("contentRatings")]
        public ContentRatingDto[] ContentRatings { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("imageType")]
        public int ImageType { get; set; }

        [JsonProperty("isMovie")]
        public long IsMovie { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("network")]
        public NetworkBaseRecordDto Network { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("productionCode")]
        public string ProductionCode { get; set; }

        [JsonProperty("remoteIds")]
        public RemoteIDDto[] RemoteIds { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonProperty("seasons")]
        public SeasonBaseRecordDto[] Seasons { get; set; }

        [JsonProperty("seriesId")]
        public long SeriesId { get; set; }

        [JsonProperty("tagOptions")]
        public TagOptionDto[] TagOptions { get; set; }

        [JsonProperty("trailers")]
        public TrailerDto[] Trailers { get; set; }
    }

    public class GenderDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class GenreBaseRecordDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class LanguageDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nativeName")]
        public string NativeName { get; set; }

        [JsonProperty("shortCode")]
        public string ShortCode { get; set; }
    }

    public class ListBaseRecordDto
    {
        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isOfficial")]
        public bool IsOfficial { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ListExtendedRecordDto
    {
        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("entities")]
        public EntityDto[] Entities { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isOfficial")]
        public bool IsOfficial { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class MovieBaseRecordDto
    {
        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public StatusDto Status { get; set; }
    }

    public class MovieExtendedRecordDto
    {
        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("artworks")]
        public ArtworkBaseRecordDto[] Artworks { get; set; }

        [JsonProperty("audioLanguages")]
        public string[] AudioLanguages { get; set; }

        [JsonProperty("awards")]
        public AwardBaseRecordDto[] Awards { get; set; }

        [JsonProperty("boxOffice")]
        public string BoxOffice { get; set; }

        [JsonProperty("budget")]
        public string Budget { get; set; }

        [JsonProperty("characters")]
        public CharacterDto[] Characters { get; set; }

        [JsonProperty("lists")]
        public ListBaseRecordDto[] Lists { get; set; }

        [JsonProperty("genres")]
        public GenreBaseRecordDto[] Genres { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("originalCountry")]
        public string OriginalCountry { get; set; }

        [JsonProperty("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("releases")]
        public ReleaseDto[] Releases { get; set; }

        [JsonProperty("remoteIds")]
        public RemoteIDDto[] RemoteIds { get; set; }

        [JsonProperty("contentRatings")]
        public ContentRatingDto[] ContentRatings { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public StatusDto Status { get; set; }

        [JsonProperty("studios")]
        public StudioBaseRecordDto[] Studios { get; set; }

        [JsonProperty("subtitleLanguages")]
        public string[] SubtitleLanguages { get; set; }

        [JsonProperty("tagOptions")]
        public TagOptionDto[] TagOptions { get; set; }

        [JsonProperty("trailers")]
        public TrailerDto[] Trailers { get; set; }

        [JsonProperty("inspirations")]
        public InspirationDto[] Inspirations { get; set; }

        [JsonProperty("productionCountries")]
        public ProductionCountryDto[] ProductionCountries { get; set; }

        [JsonProperty("spokenLanguages")]
        public string[] SpokenLanguages { get; set; }

        [JsonProperty("firstRelease")]
        public ReleaseDto FirstRelease { get; set; }

        [JsonProperty("companies")]
        public CompaniesDto Companies { get; set; }
    }

    public class NetworkBaseRecordDto
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class PeopleBaseRecordDto
    {
        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }
    }

    public class PeopleExtendedRecordDto
    {
        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("awards")]
        public AwardBaseRecordDto[] Awards { get; set; }

        [JsonProperty("biographies")]
        public BiographyDto[] Biographies { get; set; }

        [JsonProperty("birth")]
        public string Birth { get; set; }

        [JsonProperty("birthPlace")]
        public string BirthPlace { get; set; }

        [JsonProperty("characters")]
        public CharacterDto[] Characters { get; set; }

        [JsonProperty("death")]
        public string Death { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("races")]
        public RaceDto[] Races { get; set; }

        [JsonProperty("remoteIds")]
        public RemoteIDDto[] RemoteIds { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("tagOptions")]
        public TagOptionDto[] TagOptions { get; set; }
    }

    public class PeopleTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class RaceDto
    {
    }

    public class ReleaseDto
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

    public class RemoteIDDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class SearchResultDto
    {
        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }

        [JsonProperty("companies")]
        public string[] Companies { get; set; }

        [JsonProperty("companyType")]
        public string CompanyType { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("extendedTitle")]
        public string ExtendedTitle { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslated")]
        public string NameTranslated { get; set; }

        [JsonProperty("officialList")]
        public string OfficialList { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("overview_translated")]
        public string[] Overview_translated { get; set; }

        [JsonProperty("posters")]
        public string[] Posters { get; set; }

        [JsonProperty("primaryLanguage")]
        public string PrimaryLanguage { get; set; }

        [JsonProperty("primaryType")]
        public string PrimaryType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("translationsWithLang")]
        public string[] TranslationsWithLang { get; set; }

        [JsonProperty("tvdb_id")]
        public string Tvdb_id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }
    }

    public class SeasonBaseRecordDto
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("imageType")]
        public int ImageType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("seriesId")]
        public long SeriesId { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("type")]
        public SeasonTypeDto Type { get; set; }
    }

    public class SeasonExtendedRecordDto
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("artwork")]
        public ArtworkBaseRecordDto[] Artwork { get; set; }

        [JsonProperty("episodes")]
        public EpisodeBaseRecordDto[] Episodes { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("imageType")]
        public int ImageType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("seriesId")]
        public long SeriesId { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("trailers")]
        public TrailerDto[] Trailers { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("companies")]
        public CompaniesDto Companies { get; set; }

        [JsonProperty("tagOptions")]
        public TagOptionDto[] TagOptions { get; set; }
    }

    public class SeasonTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class SeriesAirsDaysDto
    {
        [JsonProperty("friday")]
        public bool Friday { get; set; }

        [JsonProperty("monday")]
        public bool Monday { get; set; }

        [JsonProperty("saturday")]
        public bool Saturday { get; set; }

        [JsonProperty("sunday")]
        public bool Sunday { get; set; }

        [JsonProperty("thursday")]
        public bool Thursday { get; set; }

        [JsonProperty("tuesday")]
        public bool Tuesday { get; set; }

        [JsonProperty("wednesday")]
        public bool Wednesday { get; set; }
    }

    public class SeriesBaseRecordDto
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("defaultSeasonType")]
        public long DefaultSeasonType { get; set; }

        [JsonProperty("firstAired")]
        public string FirstAired { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("isOrderRandomized")]
        public bool IsOrderRandomized { get; set; }

        [JsonProperty("lastAired")]
        public string LastAired { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("nextAired")]
        public string NextAired { get; set; }

        [JsonProperty("originalCountry")]
        public string OriginalCountry { get; set; }

        [JsonProperty("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public StatusDto Status { get; set; }
    }

    public class SeriesExtendedRecordDto
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("airsDays")]
        public SeriesAirsDaysDto AirsDays { get; set; }

        [JsonProperty("airsTime")]
        public string AirsTime { get; set; }

        [JsonProperty("aliases")]
        public AliasDto[] Aliases { get; set; }

        [JsonProperty("artworks")]
        public ArtworkBaseRecordDto[] Artworks { get; set; }

        [JsonProperty("characters")]
        public CharacterDto[] Characters { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("defaultSeasonType")]
        public long DefaultSeasonType { get; set; }

        [JsonProperty("firstAired")]
        public string FirstAired { get; set; }

        [JsonProperty("lists")]
        public ListBaseRecordDto[] Lists { get; set; }

        [JsonProperty("genres")]
        public GenreBaseRecordDto[] Genres { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("isOrderRandomized")]
        public bool IsOrderRandomized { get; set; }

        [JsonProperty("lastAired")]
        public string LastAired { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("companies")]
        public CompanyDto[] Companies { get; set; }

        [JsonProperty("nextAired")]
        public string NextAired { get; set; }

        [JsonProperty("originalCountry")]
        public string OriginalCountry { get; set; }

        [JsonProperty("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("remoteIds")]
        public RemoteIDDto[] RemoteIds { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("seasons")]
        public SeasonBaseRecordDto[] Seasons { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public StatusDto Status { get; set; }

        [JsonProperty("trailers")]
        public TrailerDto[] Trailers { get; set; }
    }

    public class SourceTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("postfix")]
        public string Postfix { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("sort")]
        public long Sort { get; set; }
    }

    public class StatusDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("keepUpdated")]
        public bool KeepUpdated { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recordType")]
        public string RecordType { get; set; }
    }

    public class StudioBaseRecordDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentStudio")]
        public int ParentStudio { get; set; }
    }

    public class TagDto
    {
        [JsonProperty("allowsMultiple")]
        public bool AllowsMultiple { get; set; }

        [JsonProperty("helpText")]
        public string HelpText { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public TagOptionDto[] Options { get; set; }
    }

    public class TagOptionDto
    {
        [JsonProperty("helpText")]
        public string HelpText { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public long Tag { get; set; }

        [JsonProperty("tagName")]
        public string TagName { get; set; }
    }

    public class TrailerDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class TranslationDto
    {
        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }

        [JsonProperty("isAlias")]
        public bool IsAlias { get; set; }

        [JsonProperty("isPrimary")]
        public bool IsPrimary { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }
    }

    public class TagOptionEntityDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tagName")]
        public string TagName { get; set; }

        [JsonProperty("tagId")]
        public int TagId { get; set; }
    }

    public class InspirationDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("typeName")]
        public string TypeName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ProductionCountryDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CompaniesDto
    {
        [JsonProperty("studio")]
        public CompanyDto Studio { get; set; }

        [JsonProperty("network")]
        public CompanyDto Network { get; set; }

        [JsonProperty("production")]
        public CompanyDto Production { get; set; }

        [JsonProperty("distributor")]
        public CompanyDto Distributor { get; set; }

        [JsonProperty("specialEffects")]
        public CompanyDto SpecialEffects { get; set; }
    }
}
