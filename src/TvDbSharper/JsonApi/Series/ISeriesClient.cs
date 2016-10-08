namespace TvDbSharper.JsonApi.Series
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Series.Json;
    using TvDbSharper.RestClient.Json;

    public interface ISeriesClient
    {
        Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken);

        Task<TvDbResponse<Series>> GetAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken);

        Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken);
    }
}