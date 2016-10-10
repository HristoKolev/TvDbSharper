namespace TvDbSharper.Clients.Series
{
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Series.Json;

    /// <summary>
    /// Used for geting information about a specific series
    /// </summary>
    public interface ISeriesClient
    {
        Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId);

        Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken);

        Task<TvDbResponse<Series>> GetAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<Series>> GetAsync(int seriesId);

        Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter);

        Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken);

        Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query, CancellationToken cancellationToken);

        Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page);

        Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query);

        Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId);

        Task<HttpResponseHeaders> GetHeadersAsync(int seriesId, CancellationToken cancellationToken);

        Task<HttpResponseHeaders> GetHeadersAsync(int seriesId);

        Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken);

        Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query);

        Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId);
    }
}