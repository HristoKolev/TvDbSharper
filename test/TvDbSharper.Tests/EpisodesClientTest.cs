namespace TvDbSharper.Tests
{
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.JsonApi.Episodes;
    using TvDbSharper.JsonApi.Episodes.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class EpisodesClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new EpisodesClient(jsonClient);

            const int Id = 42;

            const string Route = "/episodes/42";

            var expectedData = new TvDbResponse<EpisodeRecord>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeRecord>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodeRecord>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}