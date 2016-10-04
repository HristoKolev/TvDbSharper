namespace TvDbSharper.Tests
{
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;
    using TvDbSharper.Series;
    using TvDbSharper.Series.Json;

    using Xunit;

    public class SeriesClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetImagesQuery_Makes_The_Right_Request()
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

            var expectedData = new TvDbResponse<ImageModel[]>();

            jsonClient.GetJsonAsync<TvDbResponse<ImageModel[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetImagesQueryAsync(Id, query, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<ImageModel[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeries_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42";

            var expectedData = new TvDbResponse<SeriesModel>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesActors_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/actors";

            var expectedData = new TvDbResponse<ActorModel[]>();

            jsonClient.GetJsonAsync<TvDbResponse<ActorModel[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetActorsAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<ActorModel[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesEpisodes_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const int Page = 2;
            const string Route = "/series/42/episodes?page=2";

            var expectedData = new TvDbResponse<EpisodeModel[]>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetEpisodesAsync(Id, Page, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesEpisodesSummary_Makes_The_Right_Request()
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
        public async void GetSeriesFilter_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new SeriesClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/filter?keys=added,id";
            const SeriesFilter Filter = SeriesFilter.Id | SeriesFilter.Added;

            var expectedData = new TvDbResponse<SeriesModel>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.FilterAsync(Id, Filter, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesImages_Makes_The_Right_Request()
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
        public async void SearchSeriesEpisodes_Makes_The_Right_Request()
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

            var expectedData = new TvDbResponse<EpisodeModel[]>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.SearchEpisodesAsync(Id, query, Page, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}