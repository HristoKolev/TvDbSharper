namespace TvDbSharper.Clients.Search
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Search.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class SearchClient : BaseClient, ISearchClient
    {
        public SearchClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
        {
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesAsync(
            string value,
            SearchParameter parameter,
            CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/search/series?{this.UrlHelpers.PascalCase(parameter.ToString())}={value}";

                return await this.GetAsync<SeriesSearchResult[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Search.SearchSeriesAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesAsync(string parameterValue, SearchParameter parameterKey)
        {
            return await this.SearchSeriesAsync(parameterValue, parameterKey, CancellationToken.None);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId, CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(imdbId, SearchParameter.ImdbId, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByImdbIdAsync(string imdbId)
        {
            return await this.SearchSeriesByImdbIdAsync(imdbId, CancellationToken.None);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(name, SearchParameter.Name, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByNameAsync(string name)
        {
            return await this.SearchSeriesByNameAsync(name, CancellationToken.None);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(
            string zap2ItId,
            CancellationToken cancellationToken)
        {
            return await this.SearchSeriesAsync(zap2ItId, SearchParameter.Zap2itId, cancellationToken);
        }

        public async Task<TvDbResponse<SeriesSearchResult[]>> SearchSeriesByZap2ItIdAsync(string zap2ItId)
        {
            return await this.SearchSeriesByZap2ItIdAsync(zap2ItId, CancellationToken.None);
        }
    }
}