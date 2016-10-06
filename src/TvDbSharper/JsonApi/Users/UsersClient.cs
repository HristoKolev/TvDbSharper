namespace TvDbSharper.JsonApi.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Users.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class UsersClient : IUsersClient
    {
        public UsersClient(IJsonClient jsonClient)
        {
            this.JsonClient = jsonClient;
        }

        private IJsonClient JsonClient { get; }

        public async Task<TvDbResponse<UserFavorites>> DeleteFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/favorites/{seriesId}";

            return await this.JsonClient.DeleteJsonAsync<TvDbResponse<UserFavorites>>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> DeleteRatingsAsync(
            RatingType itemType,
            int itemId,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/{UrlHelpers.PascalCase(itemType.ToString())}/{itemId}";

            return await this.JsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user";

            return await this.GetDataAsync<User>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user/favorites";

            return await this.GetDataAsync<UserFavorites>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user/ratings";

            return await this.GetDataAsync<UserRatings[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/query?itemType={UrlHelpers.PascalCase(type.ToString())}";

            return await this.GetDataAsync<UserRatings[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> PutFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/favorites/{seriesId}";

            return await this.JsonClient.PutJsonAsync<TvDbResponse<UserFavorites>>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> PutRatingsAsync(
            RatingType itemType,
            int itemId,
            int rating,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/{UrlHelpers.PascalCase(itemType.ToString())}/{itemId}/{rating}";

            return await this.JsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(requestUri, cancellationToken);
        }

        private async Task<TvDbResponse<T>> GetDataAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            return await this.JsonClient.GetJsonAsync<TvDbResponse<T>>(requestUri, cancellationToken);
        }
    }
}