namespace TvDbSharper.JsonApi.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.JsonApi.Users.Json;
    using TvDbSharper.RestClient.Json;

    public interface IUsersClient
    {
        Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> AddRatingAsync(RatingType itemType, int itemId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync(CancellationToken cancellationToken);

        Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> RemoveFavoriteAsync(int seriesId, CancellationToken cancellationToken);

        Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken);

        Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken);

        Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken);
    }
}