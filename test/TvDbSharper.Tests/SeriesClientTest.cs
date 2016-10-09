namespace TvDbSharper.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Series;
    using TvDbSharper.Clients.Series.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    using Xunit;

    public class SeriesClientTest
    {
        public SeriesClientTest()
        {
            this.ErrorMessages = new ErrorMessages();
        }

        private IErrorMessages ErrorMessages { get; }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetActorsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const string Route = "/series/42/actors";

            var expectedData = new TvDbResponse<Actor[]>();

            jsonClient.GetJsonAsync<TvDbResponse<Actor[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetActorsAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Actor[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetActorsAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<Actor[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetActorsAsync(42, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const string Route = "/series/42";

            var expectedData = new TvDbResponse<Series>();

            jsonClient.GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<Series>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(42, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_With_Filter_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const string Route = "/series/42/filter?keys=added,id";
            const SeriesFilter Filter = SeriesFilter.Id | SeriesFilter.Added;

            var expectedData = new TvDbResponse<Series>();

            jsonClient.GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, Filter, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_With_Filter_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<Series>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            const SeriesFilter Filter = SeriesFilter.Id | SeriesFilter.Added;

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(42, Filter, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const int Page = 2;
            const string Route = "/series/42/episodes?page=2";

            var expectedData = new TvDbResponse<BasicEpisode[]>();

            jsonClient.GetJsonAsync<TvDbResponse<BasicEpisode[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetEpisodesAsync(Id, Page, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<BasicEpisode[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<BasicEpisode[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetEpisodesAsync(42, 2, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesAsync_With_Query_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const int Page = 2;
            const string Route = "/series/42/episodes/query?page=2&airedSeason=1&imdbId=tt0118480";

            var query = new EpisodeQuery
            {
                ImdbId = "tt0118480",
                AiredSeason = 1
            };

            var expectedData = new TvDbResponse<BasicEpisode[]>();

            jsonClient.GetJsonAsync<TvDbResponse<BasicEpisode[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetEpisodesAsync(Id, Page, query, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<BasicEpisode[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesAsync_With_Query_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            var query = new EpisodeQuery
            {
                ImdbId = "tt0118480",
                AiredSeason = 1
            };

            jsonClient.GetJsonAsync<TvDbResponse<BasicEpisode[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await
                    Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetEpisodesAsync(42, 2, query, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesSummaryAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const string Route = "/series/42/episodes/summary";

            var expectedData = new TvDbResponse<EpisodesSummary>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodesSummary>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetEpisodesSummaryAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodesSummary>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesSummaryAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<EpisodesSummary>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetEpisodesSummaryAsync(42, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetHeaderAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const string Route = "/series/42";

            var expectedHeaders = new HttpResponseMessage().Headers;

            jsonClient.GetHeadersAsync(Route, CancellationToken.None).Returns(expectedHeaders);

            var headers = await client.GetHeadersAsync(42, CancellationToken.None);

            await jsonClient.Received().GetHeadersAsync(Route, CancellationToken.None);

            Assert.Equal(expectedHeaders, headers);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetHeaderAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetHeadersAsync(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetHeadersAsync(42, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const string Route = "/series/42/images";

            var expectedData = new TvDbResponse<ImagesSummary>();

            jsonClient.GetJsonAsync<TvDbResponse<ImagesSummary>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetImagesSummaryAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<ImagesSummary>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<ImagesSummary>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetImagesSummaryAsync(42, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesSummaryAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;
            const string Route = "/series/42/images/query?keyType=Fanart&resolution=1280x720";

            var query = new ImagesQuery
            {
                KeyType = KeyType.Fanart,
                Resolution = "1280x720"
            };

            var expectedData = new TvDbResponse<Image[]>();

            jsonClient.GetJsonAsync<TvDbResponse<Image[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetImagesAsync(Id, query, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Image[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesSummaryAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient, this.ErrorMessages);

            var query = new ImagesQuery
            {
                KeyType = KeyType.Fanart,
                Resolution = "1280x720"
            };

            jsonClient.GetJsonAsync<TvDbResponse<Image[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex =
                await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetImagesAsync(42, query, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Series.GetImagesAsync[statusCode], ex.Message);
        }
    }
}