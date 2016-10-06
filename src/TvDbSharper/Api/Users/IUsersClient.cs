namespace TvDbSharper.Api.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Users.Json;
    using TvDbSharper.RestClient.Json;

    public interface IUsersClient
    {
        Task<TvDbResponse<UserFavorites>> DeleteFavoritesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> DeleteRatingsAsync(RatingType itemType, int itemId, CancellationToken cancellationToken);

        Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> PutFavoritesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> PutRatingsAsync(
            RatingType itemType,
            int itemId,
            int rating,
            CancellationToken cancellationToken);
    }
}