namespace TvDbSharper.Api.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.Api.Users.Json;
    using TvDbSharper.RestClient.Json;

    public interface IUsersClient
    {
        Task<TvDbResponse<UserFavoritesData>> DeleteFavoritesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatingsData[]>> DeleteRatingsAsync(RatingType itemType, int itemId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserData>> GetAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavoritesData>> GetFavoritesAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatingsData[]>> GetRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatingsData[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavoritesData>> PutFavoritesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatingsData[]>> PutRatingsAsync(
            RatingType itemType,
            int itemId,
            int rating,
            CancellationToken cancellationToken);
    }
}