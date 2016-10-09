namespace TvDbSharper.Clients.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Users.Json;

    public interface IUsersClient
    {
        Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, int rating);

        Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, int rating);

        Task<TvDbResponse<UserRatings[]>> AddRatingAsync(RatingType itemType, int itemId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> AddRatingAsync(RatingType itemType, int itemId, int rating);

        Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, int rating, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, int rating);

        Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId);

        Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<User>> GetAsync();

        Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync();

        Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> GetFavoritesAsync();

        Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync();

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync();

        Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type);

        Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync(CancellationToken cancellationToken);

        Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync();

        Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken);

        Task RemoveEpisodeRatingAsync(int episodeId);

        Task<TvDbResponse<UserFavorites>> RemoveFavoriteAsync(int seriesId, CancellationToken cancellationToken);

        Task<TvDbResponse<UserFavorites>> RemoveFavoriteAsync(int seriesId);

        Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken);

        Task RemoveImageRatingAsync(int imageId);

        Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken);

        Task RemoveRatingAsync(RatingType itemType, int itemId);

        Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken);

        Task RemoveSeriesRatingAsync(int seriesId);
    }
}