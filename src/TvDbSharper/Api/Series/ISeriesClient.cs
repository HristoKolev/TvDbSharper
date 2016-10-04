namespace TvDbSharper.Api.Series
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Series.Json;
    using TvDbSharper.RestClient.Json;

    public interface ISeriesClient
    {
        Task<TvDbResponse<ActorModel[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesModel>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken);

        Task<TvDbResponse<SeriesModel>> GetAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodeModel[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodeModel[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query, CancellationToken cancellationToken);

        Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<ImagesSummary>> GetImagesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<ImageModel[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken);
    }
}