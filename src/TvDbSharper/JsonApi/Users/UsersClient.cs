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

        public async Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, int rating, CancellationToken cancellationToken)
        {
            return await this.AddRatingAsync(RatingType.Episode, episodeId, rating, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, int rating, CancellationToken cancellationToken)
        {
            return await this.AddRatingAsync(RatingType.Image, imageId, rating, cancellationToken);
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

        public async Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, int rating, CancellationToken cancellationToken)
        {
            return await this.AddRatingAsync(RatingType.Series, seriesId, rating, cancellationToken);
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

        public async Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetRatingsAsync(RatingType.Episode, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            string requestUri = "/user/favorites";

            return await this.GetAsync<UserFavorites>(requestUri, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetRatingsAsync(RatingType.Image, cancellationToken);
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

        public async Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetRatingsAsync(RatingType.Series, cancellationToken);
        }

        public async Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken)
        {
            await this.RemoveRatingAsync(RatingType.Episode, episodeId, cancellationToken);
        }

        public async Task<TvDbResponse<UserFavorites>> RemoveFavoriteAsync(int seriesId, CancellationToken cancellationToken)
        {
            return await this.DeleteAsync<UserFavorites>($"/user/favorites/{seriesId}", cancellationToken);
        }

        public async Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken)
        {
            await this.RemoveRatingAsync(RatingType.Image, imageId, cancellationToken);
        }

        public async Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken)
        {
            string requestUri = $"/user/ratings/{UrlHelpers.QuerifyEnum(itemType)}/{itemId}";

            await this.DeleteAsync<UserRatings[]>(requestUri, cancellationToken);
        }

        public async Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken)
        {
            await this.RemoveRatingAsync(RatingType.Series, seriesId, cancellationToken);
        }
    }
}