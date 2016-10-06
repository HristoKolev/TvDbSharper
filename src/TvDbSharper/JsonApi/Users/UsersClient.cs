namespace TvDbSharper.JsonApi.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Users.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    public class UsersClient : BaseClient, IUsersClient
    {
        public UsersClient(IJsonClient jsonClient)
            : base(jsonClient)
        {
        }

        public async Task<TvDbResponse<UserRatings[]>> AddRatingAsync(
            RatingType itemType,
            int itemId,
            int rating,
            CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/{UrlHelpers.QuerifyEnum(itemType)}/{itemId}/{rating}";

            return await this.PutAsync<UserRatings[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/favorites/{seriesId}";

            return await this.PutAsync<UserFavorites>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user";

            return await this.GetAsync<User>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user/favorites";

            return await this.GetAsync<UserFavorites>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user/ratings";

            return await this.GetAsync<UserRatings[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/query?itemType={UrlHelpers.QuerifyEnum(type)}";

            return await this.GetAsync<UserRatings[]>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> RemoveFavoriteAsync(int seriesId, CancellationToken cancellationToken)
        {
            return await this.DeleteAsync<UserFavorites>($"/user/favorites/{seriesId}", cancellationToken);
        }

        public async Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/{UrlHelpers.QuerifyEnum(itemType)}/{itemId}";

            await this.DeleteAsync<UserRatings[]>(requestUri, cancellationToken);
        }
    }
}