namespace TvDbSharper.Tests
{
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.Api.Episodes;
    using TvDbSharper.Api.Episodes.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class EpisodesClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetEpisode_Makes_The_Right_Request()
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