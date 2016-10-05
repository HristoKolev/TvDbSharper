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

            var expectedData = new TvDbResponse<UserFavoritesData>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserFavoritesData>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.DeleteFavoritesAsync(Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserFavoritesData>>(Route, CancellationToken.None);

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

            var expectedData = new TvDbResponse<UserRatingsData[]>();

            jsonClient.DeleteJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.DeleteRatingsAsync(Type, Id, CancellationToken.None);

            await jsonClient.Received().DeleteJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user";

            var expectedData = new TvDbResponse<UserData>();

            jsonClient.GetJsonAsync<TvDbResponse<UserData>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserData>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetFavoritesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user/favorites";

            var expectedData = new TvDbResponse<UserFavoritesData>();

            jsonClient.GetJsonAsync<TvDbResponse<UserFavoritesData>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetFavoritesAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserFavoritesData>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetRatingsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UsersClient(jsonClient);

            const string Route = "/user/ratings";

            var expectedData = new TvDbResponse<UserRatingsData[]>();

            jsonClient.GetJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetRatingsAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None);

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

            var expectedData = new TvDbResponse<UserRatingsData[]>();

            jsonClient.GetJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetRatingsAsync(Type, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None);

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

            var expectedData = new TvDbResponse<UserFavoritesData>();

            jsonClient.PutJsonAsync<TvDbResponse<UserFavoritesData>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.PutFavoritesAsync(Id, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserFavoritesData>>(Route, CancellationToken.None);

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

            var expectedData = new TvDbResponse<UserRatingsData[]>();

            jsonClient.PutJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.PutRatingsAsync(Type, Id, Rating, CancellationToken.None);

            await jsonClient.Received().PutJsonAsync<TvDbResponse<UserRatingsData[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}