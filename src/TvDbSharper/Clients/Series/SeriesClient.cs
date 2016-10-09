namespace TvDbSharper.Clients.Series
{
    using System;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Series.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class SeriesClient : BaseClient, ISeriesClient
    {
        public SeriesClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
        {
        }

        public async Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/actors";

                return await this.GetAsync<Actor[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId)
        {
            return await this.GetActorsAsync(seriesId, CancellationToken.None);
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/filter?keys={UrlHelpers.Parametrify(filter)}";

                return await this.GetAsync<Series>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}";

                return await this.GetAsync<Series>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId)
        {
            return await this.GetAsync(seriesId, CancellationToken.None);
        }

        public async Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter)
        {
            return await this.GetAsync(seriesId, filter, CancellationToken.None);
        }

        public async Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/episodes?page={Math.Max(page, 1)}";

                return await this.GetAsync<BasicEpisode[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(
            int seriesId,
            int page,
            EpisodeQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{UrlHelpers.Querify(query)}";

                return await this.GetAsync<BasicEpisode[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page)
        {
            return await this.GetEpisodesAsync(seriesId, page, CancellationToken.None);
        }

        public async Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query)
        {
            return await this.GetEpisodesAsync(seriesId, page, query, CancellationToken.None);
        }

        public async Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/episodes/summary";

                return await this.GetAsync<EpisodesSummary>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId)
        {
            return await this.GetEpisodesSummaryAsync(seriesId, CancellationToken.None);
        }

        public async Task<HttpResponseHeaders> GetHeadersAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}";

                return await this.JsonClient.GetHeadersAsync(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<HttpResponseHeaders> GetHeadersAsync(int seriesId)
        {
            return await this.GetHeadersAsync(seriesId, CancellationToken.None);
        }

        public async Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/images/query?{UrlHelpers.Querify(query)}";

                return await this.GetAsync<Image[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetImagesAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query)
        {
            return await this.GetImagesAsync(seriesId, query, CancellationToken.None);
        }

        public async Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/images";

                return await this.GetAsync<ImagesSummary>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Series.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId)
        {
            return await this.GetImagesSummaryAsync(seriesId, CancellationToken.None);
        }
    }
}