namespace TvDbSharper.Tests
{
    using System.Net;
    using System.Threading;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using TvDbSharper.JsonApi.Users;
    using TvDbSharper.JsonApi.Users.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.JsonClient.Exceptions;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class UsersClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void AddEpisodeRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;
            const int Rating = 10; // awesome!
            const string Route = "/user/ratings/episode/42/10";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.AddEpisodeRatingAsync(Id, Rating, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void AddEpisodeRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(async () => await client.AddEpisodeRatingAsync(42, 10, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void AddImageRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;
            const int Rating = 10; // awesome!
            const string Route = "/user/ratings/image/42/10";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.AddImageRatingAsync(Id, Rating, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void AddImageRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.AddImageRatingAsync(42, 10, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void AddRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const RatingType Type = RatingType.Series;
            const int Id = 42;
            const int Rating = 10; // awesome!
            const string Route = "/user/ratings/series/42/10";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.AddRatingAsync(Type, Id, Rating, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void AddRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(
                        async () => await client.AddRatingAsync(RatingType.Series, 42, 10, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void AddSeriesRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;
            const int Rating = 10; // awesome!
            const string Route = "/user/ratings/series/42/10";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.AddSeriesRatingAsync(Id, Rating, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void AddSeriesRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.AddSeriesRatingAsync(42, 10, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void AddToFavoritesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;

            const string Route = "/user/favorites/42";

            var expectedData = new TvDbResponse<UserFavorites>();

            jsonClient.PutJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.AddToFavoritesAsync(Id, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]
        [InlineData(409)]

        // ReSharper disable once InconsistentNaming
        public async void AddToFavoritesAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.PutJsonAsync<TvDbResponse<UserFavorites>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.AddToFavoritesAsync(42, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.AddToFavoritesAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user";

            var expectedData = new TvDbResponse<User>();

            jsonClient.GetJsonAsync<TvDbResponse<User>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<User>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<User>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesRatingsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user/ratings/query?itemType=episode";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetEpisodesRatingsAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesRatingsAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetEpisodesRatingsAsync(CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.GetRatingsAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetFavoritesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user/favorites";

            var expectedData = new TvDbResponse<UserFavorites>();

            jsonClient.GetJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetFavoritesAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetFavoritesAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<UserFavorites>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetFavoritesAsync(CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.GetFavoritesAsync[statusCode], ex.Message);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesRatingsAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetImagesRatingsAsync(CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.GetRatingsAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesRatingsAsync_With_Type_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user/ratings/query?itemType=image";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetImagesRatingsAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetRatingsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user/ratings";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetRatingsAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetRatingsAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetRatingsAsync(CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.GetRatingsAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetRatingsAsync_With_Type_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const RatingType Type = RatingType.Series;

            const string Route = "/user/ratings/query?itemType=series";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetRatingsAsync(Type, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetRatingsAsync_With_Type_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(
                        async () => await client.GetRatingsAsync(RatingType.Series, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.GetRatingsAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesRatingsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user/ratings/query?itemType=series";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetSeriesRatingsAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesRatingsAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetSeriesRatingsAsync(CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.GetRatingsAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RemoveEpisodeRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;

            const string Route = "/user/ratings/episode/42";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            await client.RemoveEpisodeRatingAsync(Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void RemoveEpisodeRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.RemoveEpisodeRatingAsync(42, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RemoveFavoriteAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;

            const string Route = "/user/favorites/42";

            var expectedData = new TvDbResponse<UserFavorites>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.RemoveFavoriteAsync(Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]
        [InlineData(409)]

        // ReSharper disable once InconsistentNaming
        public async void RemoveFavoriteAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.DeleteJsonAsync<TvDbResponse<UserFavorites>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.RemoveFavoriteAsync(42, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RemoveFromFavoritesAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RemoveImageRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;

            const string Route = "/user/ratings/image/42";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            await client.RemoveImageRatingAsync(Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void RemoveImageRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.RemoveImageRatingAsync(42, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RemoveRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const RatingType Type = RatingType.Series;
            const int Id = 42;

            const string Route = "/user/ratings/series/42";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            await client.RemoveRatingAsync(Type, Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void RemoveRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            const RatingType Type = RatingType.Series;
            const int Id = 42;

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.RemoveRatingAsync(Type, Id, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RemoveSeriesRatingAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;

            const string Route = "/user/ratings/series/42";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            await client.RemoveSeriesRatingAsync(Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void RemoveSeriesRatingAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.RemoveSeriesRatingAsync(42, CancellationToken.None));

            Assert.Equal(ErrorMessages.Users.RateAsync[statusCode], ex.Message);
        }
    }
}