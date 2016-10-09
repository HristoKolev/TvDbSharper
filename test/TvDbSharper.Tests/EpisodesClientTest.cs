namespace TvDbSharper.Tests
{
    using System.Net;
    using System.Threading;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using TvDbSharper.BaseSchemas;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Clients.Episodes.Json;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    using Xunit;

    public class EpisodesClientTest
    {
        public EpisodesClientTest()
        {
            this.ErrorMessages = new ErrorMessages();
        }

        private IErrorMessages ErrorMessages { get; }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new EpisodesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;

            const string Route = "/episodes/42";

            var expectedData = new TvDbResponse<EpisodeRecord>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeRecord>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodeRecord>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new EpisodesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeRecord>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(42, CancellationToken.None));

            Assert.Equal(this.ErrorMessages.Episodes.GetAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Without_CancellationToken_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new EpisodesClient(jsonClient, this.ErrorMessages);

            const int Id = 42;

            const string Route = "/episodes/42";

            var expectedData = new TvDbResponse<EpisodeRecord>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeRecord>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodeRecord>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Without_CancellationToken_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new EpisodesClient(jsonClient, this.ErrorMessages);

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeRecord>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(42));

            Assert.Equal(this.ErrorMessages.Episodes.GetAsync[statusCode], ex.Message);
        }
    }
}