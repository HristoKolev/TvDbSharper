namespace TvDbSharper.Tests
{
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.JsonApi.Series;
    using TvDbSharper.JsonApi.Series.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class SeriesClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetActorsAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/actors";

            var expectedData = new TvDbResponse<Actor[]>();

            jsonClient.GetJsonAsync<TvDbResponse<Actor[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetActorsAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Actor[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42";

            var expectedData = new TvDbResponse<Series>();

            jsonClient.GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_With_Filter_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/filter?keys=added,id";
            const SeriesFilter Filter = SeriesFilter.Id | SeriesFilter.Added;

            var expectedData = new TvDbResponse<Series>();

            jsonClient.GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, Filter, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Series>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const int Page = 2;
            const string Route = "/series/42/episodes?page=2";

            var expectedData = new TvDbResponse<BasicEpisode[]>();

            jsonClient.GetJsonAsync<TvDbResponse<BasicEpisode[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetEpisodesAsync(Id, Page, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<BasicEpisode[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesAsync_With_Query_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

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

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisodesSummaryAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/episodes/summary";

            var expectedData = new TvDbResponse<EpisodesSummary>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodesSummary>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetEpisodesSummaryAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodesSummary>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/images";

            var expectedData = new TvDbResponse<ImagesSummary>();

            jsonClient.GetJsonAsync<TvDbResponse<ImagesSummary>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetImagesAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<ImagesSummary>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesAsync_With_Query_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

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
    }
}