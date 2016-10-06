namespace TvDbSharper.Tests
{
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.Api.Users;
    using TvDbSharper.Api.Users.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class UsersClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void DeleteFavoritesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;

            const string Route = "/user/favorites/42";

            var expectedData = new TvDbResponse<UserFavorites>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.DeleteFavoritesAsync(Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void DeleteRatingsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const RatingType Type = RatingType.Series;
            const int Id = 42;

            const string Route = "/user/ratings/series/42";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.DeleteRatingsAsync(Type, Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
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

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetRatingsByItemTypeAsync_Makes_The_Right_Request()
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

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void PutFavoritesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const int Id = 42;

            const string Route = "/user/favorites/42";

            var expectedData = new TvDbResponse<UserFavorites>();

            jsonClient.PutJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.PutFavoritesAsync(Id, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserFavorites>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void PutRatingsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const RatingType Type = RatingType.Series;
            const int Id = 42;
            const int Rating = 10; // awesome!
            const string Route = "/user/ratings/series/42/10";

            var expectedData = new TvDbResponse<UserRatings[]>();

            jsonClient.PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.PutRatingsAsync(Type, Id, Rating, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserRatings[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}