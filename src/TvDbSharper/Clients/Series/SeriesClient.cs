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
        internal SeriesClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
        {
        }

        public Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/actors";

                return this.GetAsync<Actor[]>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<Actor[]>> GetActorsAsync(int seriesId)
        {
            return this.GetActorsAsync(seriesId, CancellationToken.None);
        }

        public Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/filter?keys={this.UrlHelpers.Parametrify(filter)}";

                return this.GetAsync<Series>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<Series>> GetAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}";

                return this.GetAsync<Series>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<Series>> GetAsync(int seriesId)
        {
            return this.GetAsync(seriesId, CancellationToken.None);
        }

        public Task<TvDbResponse<Series>> GetAsync(int seriesId, SeriesFilter filter)
        {
            return this.GetAsync(seriesId, filter, CancellationToken.None);
        }

        public Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/episodes?page={Math.Max(page, 1)}";

                return this.GetAsync<BasicEpisode[]>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(
            int seriesId,
            int page,
            EpisodeQuery query,
            CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/episodes/query?page={Math.Max(page, 1)}&{this.UrlHelpers.Querify(query)}";

                return this.GetAsync<BasicEpisode[]>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page)
        {
            return this.GetEpisodesAsync(seriesId, page, CancellationToken.None);
        }

        public Task<TvDbResponse<BasicEpisode[]>> GetEpisodesAsync(int seriesId, int page, EpisodeQuery query)
        {
            return this.GetEpisodesAsync(seriesId, page, query, CancellationToken.None);
        }

        public Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/episodes/summary";

                return this.GetAsync<EpisodesSummary>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<EpisodesSummary>> GetEpisodesSummaryAsync(int seriesId)
        {
            return this.GetEpisodesSummaryAsync(seriesId, CancellationToken.None);
        }

        public Task<HttpResponseHeaders> GetHeadersAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}";

                return this.JsonClient.GetHeadersAsync(requestUri, cancellationToken);
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

        public Task<HttpResponseHeaders> GetHeadersAsync(int seriesId)
        {
            return this.GetHeadersAsync(seriesId, CancellationToken.None);
        }

        public Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/images/query?{this.UrlHelpers.Querify(query)}";

                return this.GetAsync<Image[]>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<Image[]>> GetImagesAsync(int seriesId, ImagesQuery query)
        {
            return this.GetImagesAsync(seriesId, query, CancellationToken.None);
        }

        public Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/series/{seriesId}/images";

                return this.GetAsync<ImagesSummary>(requestUri, cancellationToken);
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

        public Task<TvDbResponse<ImagesSummary>> GetImagesSummaryAsync(int seriesId)
        {
            return this.GetImagesSummaryAsync(seriesId, CancellationToken.None);
        }
    }
}