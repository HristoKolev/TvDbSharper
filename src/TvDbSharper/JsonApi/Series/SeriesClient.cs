namespace TvDbSharper.JsonApi.Series
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Series.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class SeriesClient : BaseClient, ISeriesClient
    {
        public SeriesClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/actors";

            return await this.GetAsync<Actor[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/filter?keys={UrlHelpers.Parametrify(filter)}";

            return await this.GetAsync<Series>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}";

            return await this.GetAsync<Series>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes?page={Math.Max(page, 1)}";

            return await this.GetAsync<BasicEpisode[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(
            int seriesId,
            int page,
            EpisodeQuery query,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{UrlHelpers.Querify(query)}";

            return await this.GetAsync<BasicEpisode[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes/summary";

            return await this.GetAsync<EpisodesSummary>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<ImagesSummary>> GetImagesAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/images";

            return await this.GetAsync<ImagesSummary>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/images/query?{UrlHelpers.Querify(query)}";

            return await this.GetAsync<Image[]>(requestUri, cancellationToken);
        }
    }
}