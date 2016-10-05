namespace TvDbSharper.Api.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Users.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class UsersClient
    {
        public UsersClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task<TvDbResponse<UserFavoritesData>> DeleteFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/favorites/{seriesId}";

            return await this.JsonClient.DeleteJsonAsync<TvDbResponse<UserFavoritesData>>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserData>> GetAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user";

            return await this.GetDataAsync<UserData>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavoritesData>> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user/favorites";

            return await this.GetDataAsync<UserFavoritesData>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatingsData[]>> GetRatingsAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user/ratings";

            return await this.GetDataAsync<UserRatingsData[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatingsData[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/query?itemType={UrlHelpers.PascalCase(type.ToString())}";

            return await this.GetDataAsync<UserRatingsData[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavoritesData>> PutFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/favorites/{seriesId}";

            return await this.JsonClient.PutJsonAsync<TvDbResponse<UserFavoritesData>>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}