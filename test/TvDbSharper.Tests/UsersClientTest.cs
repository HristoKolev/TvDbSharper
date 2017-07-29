namespace TvDbSharper.Tests
{
    using System.Threading.Tasks;

    using TvDbSharper.Clients;
    using TvDbSharper.Dto;
    using TvDbSharper.Infrastructure;
    using TvDbSharper.Tests.Data;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class UsersClientTest
    {
        private UrlHelpers UrlHelpers { get; } = new UrlHelpers();

        [Theory]
        [CompositeData(typeof(EnumData<RatingType>), typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddRatingAsync_Makes_The_Right_Request(RatingType itemType, int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddRatingAsync(itemType, itemId, rating, token))
                .ShouldRequest("PUT", $"/user/ratings/{this.UrlHelpers.QuerifyEnum(itemType)}/{itemId}/{rating}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(EnumData<RatingType>), typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddRatingAsync_Without_CT_Makes_The_Right_Request(RatingType itemType, int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddRatingAsync(itemType, itemId, rating))
                .WithNoCancellationToken()
                .ShouldRequest("PUT", $"/user/ratings/{this.UrlHelpers.QuerifyEnum(itemType)}/{itemId}/{rating}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddEpisodeRatingAsync_Makes_The_Right_Request(int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddEpisodeRatingAsync(itemId, rating, token))
                .ShouldRequest("PUT", $"/user/ratings/episode/{itemId}/{rating}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddEpisodeRatingAsync_Without_CT_Makes_The_Right_Request(int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddEpisodeRatingAsync(itemId, rating))
                .ShouldRequest("PUT", $"/user/ratings/episode/{itemId}/{rating}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddImageRatingAsync_Makes_The_Right_Request(int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddImageRatingAsync(itemId, rating, token))
                .ShouldRequest("PUT", $"/user/ratings/image/{itemId}/{rating}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddImageRatingAsync_Without_CT_Makes_The_Right_Request(int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddImageRatingAsync(itemId, rating))
                .ShouldRequest("PUT", $"/user/ratings/image/{itemId}/{rating}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddSeriesRatingAsync_Makes_The_Right_Request(int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddSeriesRatingAsync(itemId, rating, token))
                .ShouldRequest("PUT", $"/user/ratings/series/{itemId}/{rating}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData), typeof(DecimalData))]

        // ReSharper disable once InconsistentNaming
        public Task AddSeriesRatingAsync_Without_CT_Makes_The_Right_Request(int itemId, decimal rating)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RateAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.AddSeriesRatingAsync(itemId, rating))
                .ShouldRequest("PUT", $"/user/ratings/series/{itemId}/{rating}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(EnumData<RatingType>))]

        // ReSharper disable once InconsistentNaming
        public Task GetRatingsAsync_Makes_The_Right_Request(RatingType type)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetRatingsAsync(type, token))
                .ShouldRequest("GET", $"/user/ratings/query?itemType={this.UrlHelpers.QuerifyEnum(type)}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(EnumData<RatingType>))]

        // ReSharper disable once InconsistentNaming
        public Task GetRatingsAsync_Without_CT_Makes_The_Right_Request(RatingType type)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetRatingsAsync(type))
                .ShouldRequest("GET", $"/user/ratings/query?itemType={this.UrlHelpers.QuerifyEnum(type)}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesRatingsAsync_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesRatingsAsync(token))
                .ShouldRequest("GET", "/user/ratings/query?itemType=image")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetImagesRatingsAsync_Without_CT_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetImagesRatingsAsync())
                .ShouldRequest("GET", "/user/ratings/query?itemType=image")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetSeriesRatingsAsync_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetSeriesRatingsAsync(token))
                .ShouldRequest("GET", "/user/ratings/query?itemType=series")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetSeriesRatingsAsync_Without_CT_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetSeriesRatingsAsync())
                .ShouldRequest("GET", "/user/ratings/query?itemType=series")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesRatingsAsync_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesRatingsAsync(token))
                .ShouldRequest("GET", "/user/ratings/query?itemType=episode")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetEpisodesRatingsAsync_Without_CT_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetEpisodesRatingsAsync())
                .ShouldRequest("GET", "/user/ratings/query?itemType=episode")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetAsync)
                .SetResultObject(new TvDbResponse<User>())
                .WhenCallingAMethod((impl, token) => impl.GetAsync(token))
                .ShouldRequest("GET", "/user")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetAsync_Without_CT_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetAsync)
                .SetResultObject(new TvDbResponse<User>())
                .WhenCallingAMethod((impl, token) => impl.GetAsync())
                .ShouldRequest("GET", "/user")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task AddToFavoritesAsync_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.AddToFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserFavorites>())
                .WhenCallingAMethod((impl, token) => impl.AddToFavoritesAsync(seriesId, token))
                .ShouldRequest("PUT", $"/user/favorites/{seriesId}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task AddToFavoritesAsync_Without_CT_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.AddToFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserFavorites>())
                .WhenCallingAMethod((impl, token) => impl.AddToFavoritesAsync(seriesId))
                .ShouldRequest("PUT", $"/user/favorites/{seriesId}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetFavoritesAsync_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserFavorites>())
                .WhenCallingAMethod((impl, token) => impl.GetFavoritesAsync(token))
                .ShouldRequest("GET", "/user/favorites")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetFavoritesAsync_Without_CT_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserFavorites>())
                .WhenCallingAMethod((impl, token) => impl.GetFavoritesAsync())
                .ShouldRequest("GET", "/user/favorites")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetRatingsAsync__Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetRatingsAsync(token))
                .ShouldRequest("GET", "/user/ratings")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task GetRatingsAsync__Without_CT_Makes_The_Right_Request()
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.GetRatingsAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.GetRatingsAsync())
                .ShouldRequest("GET", "/user/ratings")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveFromFavoritesAsync_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserFavorites>())
                .WhenCallingAMethod((impl, token) => impl.RemoveFromFavoritesAsync(seriesId, token))
                .ShouldRequest("DELETE", $"/user/favorites/{seriesId}")
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveFromFavoritesAsync_Without_CT_Makes_The_Right_Request(int seriesId)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserFavorites>())
                .WhenCallingAMethod((impl, token) => impl.RemoveFromFavoritesAsync(seriesId))
                .ShouldRequest("DELETE", $"/user/favorites/{seriesId}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(EnumData<RatingType>), typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveRatingAsync_Makes_The_Right_Request(RatingType type, int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveRatingAsync(type, id, token))
                .ShouldRequest("DELETE", $"/user/ratings/{this.UrlHelpers.QuerifyEnum(type)}/{id}")
                .ShouldIgnoreParserResult()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(EnumData<RatingType>), typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveRatingAsync_Without_CT_Makes_The_Right_Request(RatingType type, int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveRatingAsync(type, id))
                .ShouldRequest("DELETE", $"/user/ratings/{this.UrlHelpers.QuerifyEnum(type)}/{id}")
                .ShouldIgnoreParserResult()
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveEpisodeRatingAsync_Makes_The_Right_Request(int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveEpisodeRatingAsync(id, token))
                .ShouldRequest("DELETE", $"/user/ratings/episode/{id}")
                .ShouldIgnoreParserResult()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveEpisodeRatingAsync_Without_CT_Makes_The_Right_Request(int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveEpisodeRatingAsync(id))
                .ShouldRequest("DELETE", $"/user/ratings/episode/{id}")
                .ShouldIgnoreParserResult()
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveImageRatingAsync_Makes_The_Right_Request(int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveImageRatingAsync(id, token))
                .ShouldRequest("DELETE", $"/user/ratings/image/{id}")
                .ShouldIgnoreParserResult()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveImageRatingAsync_Without_CT_Makes_The_Right_Request(int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveImageRatingAsync(id))
                .ShouldRequest("DELETE", $"/user/ratings/image/{id}")
                .ShouldIgnoreParserResult()
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveSeriesRatingAsync_Makes_The_Right_Request(int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveSeriesRatingAsync(id, token))
                .ShouldRequest("DELETE", $"/user/ratings/series/{id}")
                .ShouldIgnoreParserResult()
                .RunAsync();
        }

        [Theory]
        [CompositeData(typeof(IntegerData))]

        // ReSharper disable once InconsistentNaming
        public Task RemoveSeriesRatingAsync_Without_CT_Makes_The_Right_Request(int id)
        {
            return CreateClient()
                .WithErrorMap(ErrorMessages.Users.RemoveFromFavoritesAsync)
                .SetResultObject(new TvDbResponse<UserRatings[]>())
                .WhenCallingAMethod((impl, token) => impl.RemoveSeriesRatingAsync(id))
                .ShouldRequest("DELETE", $"/user/ratings/series/{id}")
                .ShouldIgnoreParserResult()
                .WithNoCancellationToken()
                .RunAsync();
        }

        private static ApiTest<UsersClient> CreateClient()
        {
            return new ApiTest<UsersClient>()
                .WithConstructor((client, parser) => new UsersClient(client, parser))
                .SetApiResponse(new ApiResponse());
        }
    }
}