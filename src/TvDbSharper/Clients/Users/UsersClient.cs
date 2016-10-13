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
        public UsersClient(IJsonClient jsonClient, IErrorMessages errorMessages)
            : base(jsonClient, errorMessages)
        {
        }

        public async Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, decimal rating, CancellationToken cancellationToken)
        {
            return await this.AddRatingAsync(RatingType.Episode, episodeId, rating, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddEpisodeRatingAsync(int episodeId, decimal rating)
        {
            return await this.AddEpisodeRatingAsync(episodeId, rating, CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, decimal rating, CancellationToken cancellationToken)
        {
            return await this.AddRatingAsync(RatingType.Image, imageId, rating, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddImageRatingAsync(int imageId, decimal rating)
        {
            return await this.AddImageRatingAsync(imageId, rating, CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddRatingAsync(
            RatingType itemType,
            int itemId,
            decimal rating,
            CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/ratings/{this.UrlHelpers.QuerifyEnum(itemType)}/{itemId}/{rating}";

                return await this.PutAsync<UserRatings[]>(requestUri, cancellationToken);
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

        public async Task<TvDbResponse<UserRatings[]>> AddRatingAsync(RatingType itemType, int itemId, decimal rating)
        {
            return await this.AddRatingAsync(itemType, itemId, rating, CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, decimal rating, CancellationToken cancellationToken)
        {
            return await this.AddRatingAsync(RatingType.Series, seriesId, rating, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> AddSeriesRatingAsync(int seriesId, decimal rating)
        {
            return await this.AddSeriesRatingAsync(seriesId, rating, CancellationToken.None);
        }

        public async Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/favorites/{seriesId}";

                return await this.PutAsync<UserFavorites>(requestUri, cancellationToken);
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

        public async Task<TvDbResponse<UserFavorites>> AddToFavoritesAsync(int seriesId)
        {
            return await this.AddToFavoritesAsync(seriesId, CancellationToken.None);
        }

        public async Task<TvDbResponse<User>> GetAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/user";

                return await this.GetAsync<User>(requestUri, cancellationToken);
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

        public async Task<TvDbResponse<User>> GetAsync()
        {
            return await this.GetAsync(CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetRatingsAsync(RatingType.Episode, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetEpisodesRatingsAsync()
        {
            return await this.GetEpisodesRatingsAsync(CancellationToken.None);
        }

        public async Task<TvDbResponse<UserFavorites>> GetFavoritesAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/user/favorites";

                return await this.GetAsync<UserFavorites>(requestUri, cancellationToken);
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

        public async Task<TvDbResponse<UserFavorites>> GetFavoritesAsync()
        {
            return await this.GetFavoritesAsync(CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetRatingsAsync(RatingType.Image, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetImagesRatingsAsync()
        {
            return await this.GetImagesRatingsAsync(CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = "/user/ratings";

                return await this.GetAsync<UserRatings[]>(requestUri, cancellationToken);
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

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/ratings/query?itemType={this.UrlHelpers.QuerifyEnum(type)}";

                return await this.GetAsync<UserRatings[]>(requestUri, cancellationToken);
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

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync()
        {
            return await this.GetRatingsAsync(CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetRatingsAsync(RatingType type)
        {
            return await this.GetRatingsAsync(type, CancellationToken.None);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetRatingsAsync(RatingType.Series, cancellationToken);
        }

        public async Task<TvDbResponse<UserRatings[]>> GetSeriesRatingsAsync()
        {
            return await this.GetSeriesRatingsAsync(CancellationToken.None);
        }

        public async Task RemoveEpisodeRatingAsync(int episodeId, CancellationToken cancellationToken)
        {
            await this.RemoveRatingAsync(RatingType.Episode, episodeId, cancellationToken);
        }

        public async Task RemoveEpisodeRatingAsync(int episodeId)
        {
            await this.RemoveEpisodeRatingAsync(episodeId, CancellationToken.None);
        }

        public async Task<TvDbResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/favorites/{seriesId}";

                return await this.DeleteAsync<UserFavorites>(requestUri, cancellationToken);
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

        public async Task<TvDbResponse<UserFavorites>> RemoveFromFavoritesAsync(int seriesId)
        {
            return await this.RemoveFromFavoritesAsync(seriesId, CancellationToken.None);
        }

        public async Task RemoveImageRatingAsync(int imageId, CancellationToken cancellationToken)
        {
            await this.RemoveRatingAsync(RatingType.Image, imageId, cancellationToken);
        }

        public async Task RemoveImageRatingAsync(int imageId)
        {
            await this.RemoveImageRatingAsync(imageId, CancellationToken.None);
        }

        public async Task RemoveRatingAsync(RatingType itemType, int itemId, CancellationToken cancellationToken)
        {
            try
            {
                string requestUri = $"/user/ratings/{this.UrlHelpers.QuerifyEnum(itemType)}/{itemId}";

                await this.DeleteAsync<UserRatings[]>(requestUri, cancellationToken);
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

        public async Task RemoveRatingAsync(RatingType itemType, int itemId)
        {
            await this.RemoveRatingAsync(itemType, itemId, CancellationToken.None);
        }

        public async Task RemoveSeriesRatingAsync(int seriesId, CancellationToken cancellationToken)
        {
            await this.RemoveRatingAsync(RatingType.Series, seriesId, cancellationToken);
        }

        public async Task RemoveSeriesRatingAsync(int seriesId)
        {
            await this.RemoveSeriesRatingAsync(seriesId, CancellationToken.None);
        }
    }
}