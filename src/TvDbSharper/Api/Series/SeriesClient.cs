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

        public async Task<TvDbResponse<SeriesModel>> FilterAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken)
        {
            return await this.GetDataAsync<SeriesModel>($"/series/{seriesId}/filter?keys={UrlHelpers.Parametrify(filter)}", cancellationToken);
        }

        public async Task<TvDbResponse<ActorModel[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken)
        {
            return await this.GetDataAsync<ActorModel[]>($"/series/{seriesId}/actors", cancellationToken);
        }

        public async Task<TvDbResponse<SeriesModel>> GetAsync(int seriesId, CancellationToken cancellationToken)
        {
            return await this.GetDataAsync<SeriesModel>($"/series/{seriesId}", cancellationToken);
        }

        public async Task<TvDbResponse<EpisodeModel[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken)
        {
            return await this.GetDataAsync<EpisodeModel[]>($"/series/{seriesId}/episodes?page={Math.Max(page, 1)}", cancellationToken);
        }

        public async Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken)
        {
            return await this.GetDataAsync<EpisodesSummary>($"/series/{seriesId}/episodes/summary", cancellationToken);
        }

        public async Task<TvDbResponse<ImagesSummary>> GetImagesAsync(int seriesId, CancellationToken cancellationToken)
        {
            return await this.GetDataAsync<ImagesSummary>($"/series/{seriesId}/images", cancellationToken);
        }

        public async Task<TvDbResponse<ImageModel[]>> GetImagesQueryAsync(
            int seriesId,
            ImagesQuery query,
            CancellationToken cancellationToken)
        {
            return await this.GetDataAsync<ImageModel[]>($"/series/{seriesId}/images/query?{UrlHelpers.Querify(query)}", cancellationToken);
        }

        public async Task<TvDbResponse<EpisodeModel[]>> SearchEpisodesAsync(
            int seriesId,
            EpisodeQuery query,
            int page,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{UrlHelpers.Querify(query)}";

            return await this.GetDataAsync<EpisodeModel[]>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}