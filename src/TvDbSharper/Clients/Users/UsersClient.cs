namespace TvDbSharper.Clients.Users
{
    using System.Threading;
    using System.Threading.Tasks;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Users.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    public class UsersClient : BaseClient, IUsersClient
    {
        internal UsersClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
        {
        }

        public Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, decimal rating, CancellationToken cancellationToken)
        {
            return this.AddRatingAsync(RatingType.Episode, episodeId, rating, cancellationToken);
        }

        public Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, decimal rating)
        {
            return this.AddEpisodeRatingAsync(episodeId, rating, CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, decimal rating, CancellationToken cancellationToken)
        {
            return this.AddRatingAsync(RatingType.Image, imageId, rating, cancellationToken);
        }

        public Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, decimal rating)
        {
            return this.AddImageRatingAsync(imageId, rating, CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> AddRatingAsync(
            RatingType itemType,
            int itemId,
            decimal rating,
            CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/ratings/{this.UrlHelpers.QuerifyEnum(itemType)}/{itemId}/{rating}";

                return this.PutAsync<UserRatings[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.RateAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<UserRatings[]>> AddRatingAsync(RatingType itemType, int itemId, decimal rating)
        {
            return this.AddRatingAsync(itemType, itemId, rating, CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, decimal rating, CancellationToken cancellationToken)
        {
            return this.AddRatingAsync(RatingType.Series, seriesId, rating, cancellationToken);
        }

        public Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, decimal rating)
        {
            return this.AddSeriesRatingAsync(seriesId, rating, CancellationToken.None);
        }

        public Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/favorites/{seriesId}";

                return this.PutAsync<UserFavorites>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.AddToFavoritesAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId)
        {
            return this.AddToFavoritesAsync(seriesId, CancellationToken.None);
        }

        public Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/user";

                return this.GetAsync<User>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.GetAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<User>> GetAsync()
        {
            return this.GetAsync(CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync(CancellationToken cancellationToken)
        {
            return this.GetRatingsAsync(RatingType.Episode, cancellationToken);
        }

        public Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync()
        {
            return this.GetEpisodesRatingsAsync(CancellationToken.None);
        }

        public Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/user/favorites";

                return this.GetAsync<UserFavorites>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.GetFavoritesAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<UserFavorites>> GetFavoritesAsync()
        {
            return this.GetFavoritesAsync(CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync(CancellationToken cancellationToken)
        {
            return this.GetRatingsAsync(RatingType.Image, cancellationToken);
        }

        public Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync()
        {
            return this.GetImagesRatingsAsync(CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/user/ratings";

                return this.GetAsync<UserRatings[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.GetRatingsAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/ratings/query?itemType={this.UrlHelpers.QuerifyEnum(type)}";

                return this.GetAsync<UserRatings[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.GetRatingsAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<UserRatings[]>> GetRatingsAsync()
        {
            return this.GetRatingsAsync(CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type)
        {
            return this.GetRatingsAsync(type, CancellationToken.None);
        }

        public Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync(CancellationToken cancellationToken)
        {
            return this.GetRatingsAsync(RatingType.Series, cancellationToken);
        }

        public Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync()
        {
            return this.GetSeriesRatingsAsync(CancellationToken.None);
        }

        public Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken)
        {
            return this.RemoveRatingAsync(RatingType.Episode, episodeId, cancellationToken);
        }

        public Task RemoveEpisodeRatingAsync(int episodeId)
        {
            return this.RemoveEpisodeRatingAsync(episodeId, CancellationToken.None);
        }

        public Task<TvDbResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/favorites/{seriesId}";

                return this.DeleteAsync<UserFavorites>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.RemoveFromFavoritesAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task<TvDbResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId)
        {
            return this.RemoveFromFavoritesAsync(seriesId, CancellationToken.None);
        }

        public Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken)
        {
            return this.RemoveRatingAsync(RatingType.Image, imageId, cancellationToken);
        }

        public Task RemoveImageRatingAsync(int imageId)
        {
            return this.RemoveImageRatingAsync(imageId, CancellationToken.None);
        }

        public Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/ratings/{this.UrlHelpers.QuerifyEnum(itemType)}/{itemId}";

                return this.DeleteAsync<UserRatings[]>(requestUri, cancellationToken);
            }
            catch (TvDbServerException ex)
            {
                string message = this.GetMessage(ex.StatusCode, this.ErrorMessages.Users.RateAsync);

                if (message == null)
                {
                    throw;
                }

                throw new TvDbServerException(message, ex.StatusCode, ex);
            }
        }

        public Task RemoveRatingAsync(RatingType itemType, int itemId)
        {
            return this.RemoveRatingAsync(itemType, itemId, CancellationToken.None);
        }

        public Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken)
        {
            return this.RemoveRatingAsync(RatingType.Series, seriesId, cancellationToken);
        }

        public Task RemoveSeriesRatingAsync(int seriesId)
        {
            return this.RemoveSeriesRatingAsync(seriesId, CancellationToken.None);
        }
    }
}