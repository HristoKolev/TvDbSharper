// ReSharper disable HeapView.BoxingAllocation
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantStringInterpolation

namespace TvDbSharper
{
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public partial class TvDbClient
    {
        public Task<TvDbApiResponse<ArtworkBaseRecordDto>> Artwork(int id, CancellationToken cancellationToken)
        {
            return this.Get<ArtworkBaseRecordDto>($"artwork/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ArtworkBaseRecordDto>> Artwork(int id)
        {
            return this.Artwork(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<ArtworkExtendedRecordDto>> ArtworkExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<ArtworkExtendedRecordDto>($"artwork/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ArtworkExtendedRecordDto>> ArtworkExtended(int id)
        {
            return this.ArtworkExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<ArtworkStatusDto[]>> ArtworkStatuses(CancellationToken cancellationToken)
        {
            return this.Get<ArtworkStatusDto[]>($"artwork/statuses", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ArtworkStatusDto[]>> ArtworkStatuses()
        {
            return this.ArtworkStatuses(CancellationToken.None);
        }

        public Task<TvDbApiResponse<ArtworkTypeDto[]>> ArtworkTypes(CancellationToken cancellationToken)
        {
            return this.Get<ArtworkTypeDto[]>($"artwork/types", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ArtworkTypeDto[]>> ArtworkTypes()
        {
            return this.ArtworkTypes(CancellationToken.None);
        }

        public Task<TvDbApiResponse<AwardBaseRecordDto[]>> Awards(CancellationToken cancellationToken)
        {
            return this.Get<AwardBaseRecordDto[]>($"awards", null, cancellationToken);
        }

        public Task<TvDbApiResponse<AwardBaseRecordDto[]>> Awards()
        {
            return this.Awards(CancellationToken.None);
        }

        public Task<TvDbApiResponse<AwardBaseRecordDto>> Award(int id, CancellationToken cancellationToken)
        {
            return this.Get<AwardBaseRecordDto>($"awards/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<AwardBaseRecordDto>> Award(int id)
        {
            return this.Award(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<AwardExtendedRecordDto>> AwardExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<AwardExtendedRecordDto>($"awards/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<AwardExtendedRecordDto>> AwardExtended(int id)
        {
            return this.AwardExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<AwardCategoryBaseRecordDto>> AwardCategory(int id, CancellationToken cancellationToken)
        {
            return this.Get<AwardCategoryBaseRecordDto>($"awards/categories/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<AwardCategoryBaseRecordDto>> AwardCategory(int id)
        {
            return this.AwardCategory(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<AwardCategoryExtendedRecordDto>> AwardCategoryExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<AwardCategoryExtendedRecordDto>($"awards/categories/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<AwardCategoryExtendedRecordDto>> AwardCategoryExtended(int id)
        {
            return this.AwardCategoryExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<CharacterDto>> Character(int id, CancellationToken cancellationToken)
        {
            return this.Get<CharacterDto>($"characters/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<CharacterDto>> Character(int id)
        {
            return this.Character(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<CompanyDto[]>> Companies(CancellationToken cancellationToken)
        {
            return this.Get<CompanyDto[]>($"companies", null, cancellationToken);
        }

        public Task<TvDbApiResponse<CompanyDto[]>> Companies()
        {
            return this.Companies(CancellationToken.None);
        }

        public Task<TvDbApiResponse<CompanyDto[]>> Companies(CompaniesOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<CompanyDto[]>($"companies", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<CompanyDto[]>> Companies(CompaniesOptionalParams optionalParameters)
        {
            return this.Companies(optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<CompanyTypeDto[]>> CompanyTypes(CancellationToken cancellationToken)
        {
            return this.Get<CompanyTypeDto[]>($"companies/types", null, cancellationToken);
        }

        public Task<TvDbApiResponse<CompanyTypeDto[]>> CompanyTypes()
        {
            return this.CompanyTypes(CancellationToken.None);
        }

        public Task<TvDbApiResponse<CompanyDto>> Company(int id, CancellationToken cancellationToken)
        {
            return this.Get<CompanyDto>($"companies/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<CompanyDto>> Company(int id)
        {
            return this.Company(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<ContentRatingDto[]>> ContentRatings(CancellationToken cancellationToken)
        {
            return this.Get<ContentRatingDto[]>($"content/ratings", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ContentRatingDto[]>> ContentRatings()
        {
            return this.ContentRatings(CancellationToken.None);
        }

        public Task<TvDbApiResponse<CountryDto[]>> Countries(CancellationToken cancellationToken)
        {
            return this.Get<CountryDto[]>($"countries", null, cancellationToken);
        }

        public Task<TvDbApiResponse<CountryDto[]>> Countries()
        {
            return this.Countries(CancellationToken.None);
        }

        public Task<TvDbApiResponse<EntityTypeDto[]>> EntityTypes(CancellationToken cancellationToken)
        {
            return this.Get<EntityTypeDto[]>($"entities/types", null, cancellationToken);
        }

        public Task<TvDbApiResponse<EntityTypeDto[]>> EntityTypes()
        {
            return this.EntityTypes(CancellationToken.None);
        }

        public Task<TvDbApiResponse<EpisodeBaseRecordDto>> Episode(int id, CancellationToken cancellationToken)
        {
            return this.Get<EpisodeBaseRecordDto>($"episodes/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<EpisodeBaseRecordDto>> Episode(int id)
        {
            return this.Episode(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<EpisodeExtendedRecordDto>> EpisodeExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<EpisodeExtendedRecordDto>($"episodes/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<EpisodeExtendedRecordDto>> EpisodeExtended(int id)
        {
            return this.EpisodeExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<EpisodeExtendedRecordDto>> EpisodeExtended(int id, EpisodeExtendedOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<EpisodeExtendedRecordDto>($"episodes/{id}/extended", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<EpisodeExtendedRecordDto>> EpisodeExtended(int id, EpisodeExtendedOptionalParams optionalParameters)
        {
            return this.EpisodeExtended(id, optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<TranslationDto>> EpisodeTranslation(int id, string language, CancellationToken cancellationToken)
        {
            return this.Get<TranslationDto>($"episodes/{id}/translations/{language}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<TranslationDto>> EpisodeTranslation(int id, string language)
        {
            return this.EpisodeTranslation(id, language, CancellationToken.None);
        }

        public Task<TvDbApiResponse<GenderDto[]>> Genders(CancellationToken cancellationToken)
        {
            return this.Get<GenderDto[]>($"genders", null, cancellationToken);
        }

        public Task<TvDbApiResponse<GenderDto[]>> Genders()
        {
            return this.Genders(CancellationToken.None);
        }

        public Task<TvDbApiResponse<GenreBaseRecordDto[]>> Genres(CancellationToken cancellationToken)
        {
            return this.Get<GenreBaseRecordDto[]>($"genres", null, cancellationToken);
        }

        public Task<TvDbApiResponse<GenreBaseRecordDto[]>> Genres()
        {
            return this.Genres(CancellationToken.None);
        }

        public Task<TvDbApiResponse<GenreBaseRecordDto>> Genre(int id, CancellationToken cancellationToken)
        {
            return this.Get<GenreBaseRecordDto>($"genres/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<GenreBaseRecordDto>> Genre(int id)
        {
            return this.Genre(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<InspirationTypeDto[]>> InspirationTypes(CancellationToken cancellationToken)
        {
            return this.Get<InspirationTypeDto[]>($"inspiration/types", null, cancellationToken);
        }

        public Task<TvDbApiResponse<InspirationTypeDto[]>> InspirationTypes()
        {
            return this.InspirationTypes(CancellationToken.None);
        }

        public Task<TvDbApiResponse<LanguageDto[]>> Languages(CancellationToken cancellationToken)
        {
            return this.Get<LanguageDto[]>($"languages", null, cancellationToken);
        }

        public Task<TvDbApiResponse<LanguageDto[]>> Languages()
        {
            return this.Languages(CancellationToken.None);
        }

        public Task<TvDbApiResponse<ListBaseRecordDto[]>> Lists(CancellationToken cancellationToken)
        {
            return this.Get<ListBaseRecordDto[]>($"lists", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ListBaseRecordDto[]>> Lists()
        {
            return this.Lists(CancellationToken.None);
        }

        public Task<TvDbApiResponse<ListBaseRecordDto[]>> Lists(ListsOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<ListBaseRecordDto[]>($"lists", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<ListBaseRecordDto[]>> Lists(ListsOptionalParams optionalParameters)
        {
            return this.Lists(optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<ListBaseRecordDto>> List(int id, CancellationToken cancellationToken)
        {
            return this.Get<ListBaseRecordDto>($"lists/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ListBaseRecordDto>> List(int id)
        {
            return this.List(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<ListExtendedRecordDto>> ListExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<ListExtendedRecordDto>($"lists/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<ListExtendedRecordDto>> ListExtended(int id)
        {
            return this.ListExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<TranslationDto[]>> ListTranslation(int id, string language, CancellationToken cancellationToken)
        {
            return this.Get<TranslationDto[]>($"lists/{id}/translations/{language}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<TranslationDto[]>> ListTranslation(int id, string language)
        {
            return this.ListTranslation(id, language, CancellationToken.None);
        }

        public Task<TvDbApiResponse<MovieBaseRecordDto[]>> Movies(CancellationToken cancellationToken)
        {
            return this.Get<MovieBaseRecordDto[]>($"movies", null, cancellationToken);
        }

        public Task<TvDbApiResponse<MovieBaseRecordDto[]>> Movies()
        {
            return this.Movies(CancellationToken.None);
        }

        public Task<TvDbApiResponse<MovieBaseRecordDto[]>> Movies(MoviesOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<MovieBaseRecordDto[]>($"movies", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<MovieBaseRecordDto[]>> Movies(MoviesOptionalParams optionalParameters)
        {
            return this.Movies(optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<MovieBaseRecordDto>> Movie(int id, CancellationToken cancellationToken)
        {
            return this.Get<MovieBaseRecordDto>($"movies/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<MovieBaseRecordDto>> Movie(int id)
        {
            return this.Movie(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<MovieExtendedRecordDto>> MovieExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<MovieExtendedRecordDto>($"movies/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<MovieExtendedRecordDto>> MovieExtended(int id)
        {
            return this.MovieExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<MovieExtendedRecordDto>> MovieExtended(int id, MovieExtendedOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<MovieExtendedRecordDto>($"movies/{id}/extended", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<MovieExtendedRecordDto>> MovieExtended(int id, MovieExtendedOptionalParams optionalParameters)
        {
            return this.MovieExtended(id, optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<TranslationDto>> MovieTranslation(int id, string language, CancellationToken cancellationToken)
        {
            return this.Get<TranslationDto>($"movies/{id}/translations/{language}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<TranslationDto>> MovieTranslation(int id, string language)
        {
            return this.MovieTranslation(id, language, CancellationToken.None);
        }

        public Task<TvDbApiResponse<StatusDto[]>> MovieStatuses(CancellationToken cancellationToken)
        {
            return this.Get<StatusDto[]>($"movies/statuses", null, cancellationToken);
        }

        public Task<TvDbApiResponse<StatusDto[]>> MovieStatuses()
        {
            return this.MovieStatuses(CancellationToken.None);
        }

        public Task<TvDbApiResponse<PeopleBaseRecordDto>> People(int id, CancellationToken cancellationToken)
        {
            return this.Get<PeopleBaseRecordDto>($"people/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<PeopleBaseRecordDto>> People(int id)
        {
            return this.People(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<PeopleExtendedRecordDto>> PeopleExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<PeopleExtendedRecordDto>($"people/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<PeopleExtendedRecordDto>> PeopleExtended(int id)
        {
            return this.PeopleExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<PeopleExtendedRecordDto>> PeopleExtended(int id, PeopleExtendedOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<PeopleExtendedRecordDto>($"people/{id}/extended", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<PeopleExtendedRecordDto>> PeopleExtended(int id, PeopleExtendedOptionalParams optionalParameters)
        {
            return this.PeopleExtended(id, optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<TranslationDto>> PeopleTranslation(int id, string language, CancellationToken cancellationToken)
        {
            return this.Get<TranslationDto>($"people/{id}/translations/{language}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<TranslationDto>> PeopleTranslation(int id, string language)
        {
            return this.PeopleTranslation(id, language, CancellationToken.None);
        }

        public Task<TvDbApiResponse<PeopleTypeDto[]>> PeopleTypes(CancellationToken cancellationToken)
        {
            return this.Get<PeopleTypeDto[]>($"people/types", null, cancellationToken);
        }

        public Task<TvDbApiResponse<PeopleTypeDto[]>> PeopleTypes()
        {
            return this.PeopleTypes(CancellationToken.None);
        }

        public Task<TvDbApiResponse<SearchResultDto[]>> Search(CancellationToken cancellationToken)
        {
            return this.Get<SearchResultDto[]>($"search", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SearchResultDto[]>> Search()
        {
            return this.Search(CancellationToken.None);
        }

        public Task<TvDbApiResponse<SearchResultDto[]>> Search(SearchOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<SearchResultDto[]>($"search", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<SearchResultDto[]>> Search(SearchOptionalParams optionalParameters)
        {
            return this.Search(optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeasonBaseRecordDto[]>> Seasons(CancellationToken cancellationToken)
        {
            return this.Get<SeasonBaseRecordDto[]>($"seasons", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeasonBaseRecordDto[]>> Seasons()
        {
            return this.Seasons(CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeasonBaseRecordDto[]>> Seasons(SeasonsOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<SeasonBaseRecordDto[]>($"seasons", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<SeasonBaseRecordDto[]>> Seasons(SeasonsOptionalParams optionalParameters)
        {
            return this.Seasons(optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeasonBaseRecordDto>> Season(int id, CancellationToken cancellationToken)
        {
            return this.Get<SeasonBaseRecordDto>($"seasons/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeasonBaseRecordDto>> Season(int id)
        {
            return this.Season(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeasonExtendedRecordDto>> SeasonExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<SeasonExtendedRecordDto>($"seasons/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeasonExtendedRecordDto>> SeasonExtended(int id)
        {
            return this.SeasonExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeasonTypeDto[]>> SeasonTypes(CancellationToken cancellationToken)
        {
            return this.Get<SeasonTypeDto[]>($"seasons/types", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeasonTypeDto[]>> SeasonTypes()
        {
            return this.SeasonTypes(CancellationToken.None);
        }

        public Task<TvDbApiResponse<TranslationDto>> SeasonTranslation(int id, string language, CancellationToken cancellationToken)
        {
            return this.Get<TranslationDto>($"seasons/{id}/translations/{language}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<TranslationDto>> SeasonTranslation(int id, string language)
        {
            return this.SeasonTranslation(id, language, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeriesBaseRecordDto[]>> AllSeries(CancellationToken cancellationToken)
        {
            return this.Get<SeriesBaseRecordDto[]>($"series", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeriesBaseRecordDto[]>> AllSeries()
        {
            return this.AllSeries(CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeriesBaseRecordDto[]>> AllSeries(AllSeriesOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<SeriesBaseRecordDto[]>($"series", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<SeriesBaseRecordDto[]>> AllSeries(AllSeriesOptionalParams optionalParameters)
        {
            return this.AllSeries(optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeriesBaseRecordDto>> Series(int id, CancellationToken cancellationToken)
        {
            return this.Get<SeriesBaseRecordDto>($"series/{id}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeriesBaseRecordDto>> Series(int id)
        {
            return this.Series(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesExtended(int id, CancellationToken cancellationToken)
        {
            return this.Get<SeriesExtendedRecordDto>($"series/{id}/extended", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesExtended(int id)
        {
            return this.SeriesExtended(id, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesExtended(int id, SeriesExtendedOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<SeriesExtendedRecordDto>($"series/{id}/extended", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesExtended(int id, SeriesExtendedOptionalParams optionalParameters)
        {
            return this.SeriesExtended(id, optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<GetSeriesEpisodesResponseData>> SeriesEpisodes(int id, string seasonType, CancellationToken cancellationToken)
        {
            return this.Get<GetSeriesEpisodesResponseData>($"series/{id}/episodes/{seasonType}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<GetSeriesEpisodesResponseData>> SeriesEpisodes(int id, string seasonType)
        {
            return this.SeriesEpisodes(id, seasonType, CancellationToken.None);
        }

        public Task<TvDbApiResponse<GetSeriesEpisodesResponseData>> SeriesEpisodes(int id, string seasonType, SeriesEpisodesOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<GetSeriesEpisodesResponseData>($"series/{id}/episodes/{seasonType}", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<GetSeriesEpisodesResponseData>> SeriesEpisodes(int id, string seasonType, SeriesEpisodesOptionalParams optionalParameters)
        {
            return this.SeriesEpisodes(id, seasonType, optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesSeasonEpisodesTranslated(int id, string seasonType, string lang, CancellationToken cancellationToken)
        {
            return this.Get<SeriesExtendedRecordDto>($"series/{id}/episodes/{seasonType}/{lang}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesSeasonEpisodesTranslated(int id, string seasonType, string lang)
        {
            return this.SeriesSeasonEpisodesTranslated(id, seasonType, lang, CancellationToken.None);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesSeasonEpisodesTranslated(int id, string seasonType, string lang, SeriesSeasonEpisodesTranslatedOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<SeriesExtendedRecordDto>($"series/{id}/episodes/{seasonType}/{lang}", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<SeriesExtendedRecordDto>> SeriesSeasonEpisodesTranslated(int id, string seasonType, string lang, SeriesSeasonEpisodesTranslatedOptionalParams optionalParameters)
        {
            return this.SeriesSeasonEpisodesTranslated(id, seasonType, lang, optionalParameters, CancellationToken.None);
        }

        public Task<TvDbApiResponse<TranslationDto>> SeriesTranslation(int id, string language, CancellationToken cancellationToken)
        {
            return this.Get<TranslationDto>($"series/{id}/translations/{language}", null, cancellationToken);
        }

        public Task<TvDbApiResponse<TranslationDto>> SeriesTranslation(int id, string language)
        {
            return this.SeriesTranslation(id, language, CancellationToken.None);
        }

        public Task<TvDbApiResponse<StatusDto[]>> SeriesStatuses(CancellationToken cancellationToken)
        {
            return this.Get<StatusDto[]>($"series/statuses", null, cancellationToken);
        }

        public Task<TvDbApiResponse<StatusDto[]>> SeriesStatuses()
        {
            return this.SeriesStatuses(CancellationToken.None);
        }

        public Task<TvDbApiResponse<SourceTypeDto[]>> SourceTypes(CancellationToken cancellationToken)
        {
            return this.Get<SourceTypeDto[]>($"sources/types", null, cancellationToken);
        }

        public Task<TvDbApiResponse<SourceTypeDto[]>> SourceTypes()
        {
            return this.SourceTypes(CancellationToken.None);
        }

        public Task<TvDbApiResponse<EntityUpdateDto[]>> Updates(CancellationToken cancellationToken)
        {
            return this.Get<EntityUpdateDto[]>($"updates", null, cancellationToken);
        }

        public Task<TvDbApiResponse<EntityUpdateDto[]>> Updates()
        {
            return this.Updates(CancellationToken.None);
        }

        public Task<TvDbApiResponse<EntityUpdateDto[]>> Updates(UpdatesOptionalParams optionalParameters, CancellationToken cancellationToken)
        {
            return this.Get<EntityUpdateDto[]>($"updates", optionalParameters, cancellationToken);
        }

        public Task<TvDbApiResponse<EntityUpdateDto[]>> Updates(UpdatesOptionalParams optionalParameters)
        {
            return this.Updates(optionalParameters, CancellationToken.None);
        }
    }

    public class CompaniesOptionalParams
    {
        [QueryParameter("page")]
        public int? Page { get; set; }
    }

    public class EpisodeExtendedOptionalParams
    {
        [QueryParameter("meta")]
        public string Meta { get; set; }
    }

    public class ListsOptionalParams
    {
        [QueryParameter("page")]
        public int? Page { get; set; }
    }

    public class MoviesOptionalParams
    {
        [QueryParameter("page")]
        public int? Page { get; set; }
    }

    public class MovieExtendedOptionalParams
    {
        [QueryParameter("meta")]
        public string Meta { get; set; }
    }

    public class PeopleExtendedOptionalParams
    {
        [QueryParameter("meta")]
        public string Meta { get; set; }
    }

    public class SearchOptionalParams
    {
        [QueryParameter("q")]
        public string Q { get; set; }

        [QueryParameter("query")]
        public string Query { get; set; }

        [QueryParameter("type")]
        public string Type { get; set; }

        [QueryParameter("remote_id")]
        public string Remote_id { get; set; }

        [QueryParameter("year")]
        public int? Year { get; set; }

        [QueryParameter("offset")]
        public int? Offset { get; set; }

        [QueryParameter("limit")]
        public int? Limit { get; set; }
    }

    public class SeasonsOptionalParams
    {
        [QueryParameter("page")]
        public int? Page { get; set; }
    }

    public class AllSeriesOptionalParams
    {
        [QueryParameter("page")]
        public int? Page { get; set; }
    }

    public class SeriesExtendedOptionalParams
    {
        [QueryParameter("meta")]
        public string Meta { get; set; }
    }

    public class SeriesEpisodesOptionalParams
    {
        [QueryParameter("page")]
        public int? Page { get; set; }

        [QueryParameter("season")]
        public int? Season { get; set; }
    }

    public class SeriesSeasonEpisodesTranslatedOptionalParams
    {
        [QueryParameter("page")]
        public int? Page { get; set; }
    }

    public class UpdatesOptionalParams
    {
        [QueryParameter("since")]
        public int? Since { get; set; }

        [QueryParameter("type")]
        public string Type { get; set; }

        [QueryParameter("action")]
        public string Action { get; set; }

        [QueryParameter("page")]
        public int? Page { get; set; }
    }

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
        public int? EpisodeId { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("movieId")]
        public int? MovieId { get; set; }

        [JsonProperty("networkId")]
        public int? NetworkId { get; set; }

        [JsonProperty("peopleId")]
        public int? PeopleId { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("seasonId")]
        public int? SeasonId { get; set; }

        [JsonProperty("seriesId")]
        public int? SeriesId { get; set; }

        [JsonProperty("seriesPeopleId")]
        public int? SeriesPeopleId { get; set; }

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

        [JsonIgnore]
        public object Status { get; set; }

        [JsonIgnore]
        public object TagOptions { get; set; }
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
        public int? EpisodeId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonProperty("movieId")]
        public int? MovieId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonProperty("peopleId")]
        public int PeopleId { get; set; }

        [JsonProperty("seriesId")]
        public int? SeriesId { get; set; }

        [JsonProperty("sort")]
        public long Sort { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("personName")]
        public string PersonName { get; set; }

        [JsonProperty("peopleType")]
        public string PeopleType { get; set; }
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

        [JsonProperty("companyType")]
        public CompanyTypeDto CompanyType { get; set; }
    }

    public class CompanyTypeDto
    {
        [JsonProperty("companyTypeId")]
        public long CompanyTypeId { get; set; }

        [JsonProperty("companyTypeName")]
        public string CompanyTypeName { get; set; }
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

        [JsonProperty("description")]
        public string Description { get; set; }
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
        public int? SeriesId { get; set; }
    }

    public class EntityTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("seriesId")]
        public int SeriesId { get; set; }

        [JsonProperty("hasSpecials")]
        public bool HasSpecials { get; set; }
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
        public int? ImageType { get; set; }

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

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty("finaleType")]
        public string FinaleType { get; set; }
    }

    public class EpisodeExtendedRecordDto
    {
        [JsonProperty("aired")]
        public string Aired { get; set; }

        [JsonProperty("airsAfterSeason")]
        public int? AirsAfterSeason { get; set; }

        [JsonProperty("airsBeforeEpisode")]
        public int? AirsBeforeEpisode { get; set; }

        [JsonProperty("airsBeforeSeason")]
        public int? AirsBeforeSeason { get; set; }

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
        public int? ImageType { get; set; }

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

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty("finaleType")]
        public string FinaleType { get; set; }

        [JsonProperty("nominations")]
        public string Nominations { get; set; }

        [JsonProperty("networks")]
        public string Networks { get; set; }

        [JsonProperty("studios")]
        public StudioBaseRecordDto[] Studios { get; set; }
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

        [JsonProperty("score")]
        public int Score { get; set; }
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
        public double? Score { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public StatusDto Status { get; set; }

        [JsonProperty("runtime")]
        public int? Runtime { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }
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
        public double? Score { get; set; }

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

        [JsonProperty("production_countries")]
        public ProductionCountryDto[] ProductionCountries { get; set; }

        [JsonProperty("spoken_languages")]
        public string[] SpokenLanguages { get; set; }

        [JsonProperty("first_release")]
        public ReleaseDto FirstRelease { get; set; }

        [JsonProperty("companies")]
        public CompaniesDto Companies { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }
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

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }
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

        [JsonProperty("nameTranslations")]
        public string[] NameTranslations { get; set; }

        [JsonProperty("overviewTranslations")]
        public string[] OverviewTranslations { get; set; }

        [JsonIgnore]
        public object Translations { get; set; }
    }

    public class PeopleTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class RaceDto { }

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

        [JsonProperty("sourceName")]
        public string SourceName { get; set; }
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

        [JsonProperty("extended_title")]
        public string ExtendedTitle { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_translated")]
        public string NameTranslated { get; set; }

        [JsonProperty("officialList")]
        public string OfficialList { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("overview_translated")]
        public string[] OverviewTranslated { get; set; }

        [JsonProperty("posters")]
        public string[] Posters { get; set; }

        [JsonProperty("primary_language")]
        public string PrimaryLanguage { get; set; }

        [JsonProperty("primaryType")]
        public string PrimaryType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("translationsWithLang")]
        public string[] TranslationsWithLang { get; set; }

        [JsonProperty("tvdb_id")]
        public string TvdbId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("poster")]
        public string Poster { get; set; }

        [JsonProperty("translations")]
        public Dictionary<string, string> Translations { get; set; }

        [JsonProperty("is_official")]
        public bool IsOfficial { get; set; }

        [JsonProperty("remote_ids")]
        public RemoteIDDto[] RemoteIds { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overviews")]
        public Dictionary<string, string> Overviews { get; set; }

        [JsonProperty("objectID")]
        public string ObjectID { get; set; }

        [JsonProperty("studios")]
        public string[] Studios { get; set; }

        [JsonProperty("first_air_time")]
        public string FirstAirTime { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
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
        public int? ImageType { get; set; }

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

        [JsonProperty("companies")]
        public CompaniesDto Companies { get; set; }
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
        public int? ImageType { get; set; }

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
        public SeasonTypeDto Type { get; set; }

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
        public string Type { get; set; }
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

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty("averageRuntime")]
        public int? AverageRuntime { get; set; }
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
        public ArtworkExtendedRecordDto[] Artworks { get; set; }

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

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty("averageRuntime")]
        public int? AverageRuntime { get; set; }

        [JsonProperty("airsTimeUTC")]
        public string AirsTimeUTC { get; set; }

        [JsonIgnore]
        public object Translations { get; set; }

        [JsonProperty("episodes")]
        public EpisodeBaseRecordDto[] Episodes { get; set; }
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
        public long? Id { get; set; }

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

        [JsonProperty("tagline")]
        public string Tagline { get; set; }
    }

    public class TranslationSimpleDto
    {
        [JsonProperty("language")]
        public string Language { get; set; }
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

    public class InspirationTypeDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reference_name")]
        public string ReferenceName { get; set; }

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
        public CompanyDto[] Studio { get; set; }

        [JsonProperty("network")]
        public CompanyDto[] Network { get; set; }

        [JsonProperty("production")]
        public CompanyDto[] Production { get; set; }

        [JsonProperty("distributor")]
        public CompanyDto[] Distributor { get; set; }

        [JsonProperty("special_effects")]
        public CompanyDto[] SpecialEffects { get; set; }
    }

    public class LinksDto
    {
        [JsonProperty("prev")]
        public string Prev { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }

    public class GetSeriesEpisodesResponseData
    {
        [JsonProperty("series")]
        public SeriesExtendedRecordDto Series { get; set; }

        [JsonProperty("episodes")]
        public EpisodeBaseRecordDto[] Episodes { get; set; }
    }

    public class GetSeriesSeasonEpisodesTranslatedResponseData
    {
        [JsonProperty("series")]
        public SeriesExtendedRecordDto Series { get; set; }

        [JsonProperty("episodes")]
        public EpisodeBaseRecordDto[] Episodes { get; set; }
    }
}
