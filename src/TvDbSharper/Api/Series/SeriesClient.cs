namespace TvDbSharper.Api.Series
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Series.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class SeriesClient : ISeriesClient
    {
        public SeriesClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task<TvDbResponse<ActorModel[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/actors";

            return await this.GetDataAsync<ActorModel[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesModel>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/filter?keys={UrlHelpers.Parametrify(filter)}";

            return await this.GetDataAsync<SeriesModel>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesModel>> GetAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}";

            return await this.GetDataAsync<SeriesModel>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<EpisodeModel[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes?page={Math.Max(page, 1)}";

            return await this.GetDataAsync<EpisodeModel[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<EpisodeModel[]>> GetEpisodesAsync(
            int seriesId,
            int page,
            EpisodeQuery query,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{UrlHelpers.Querify(query)}";

            return await this.GetDataAsync<EpisodeModel[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes/summary";

            return await this.GetDataAsync<EpisodesSummary>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<ImagesSummary>> GetImagesAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/images";

            return await this.GetDataAsync<ImagesSummary>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<ImageModel[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/images/query?{UrlHelpers.Querify(query)}";

            return await this.GetDataAsync<ImageModel[]>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}