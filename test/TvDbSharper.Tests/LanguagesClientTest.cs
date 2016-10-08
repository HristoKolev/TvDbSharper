namespace TvDbSharper.Tests
{
    using System.Net;
    using System.Threading;

    using NSubstitute;
    using NSubstitute.ExceptionExtensions;

    using TvDbSharper.JsonApi.Languages;
    using TvDbSharper.JsonApi.Languages.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.JsonClient.Exceptions;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class LanguagesClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAllAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new LanguagesClient(jsonClient);

            const string Route = "/languages";

            var expectedData = new TvDbResponse<Language[]>();

            jsonClient.GetJsonAsync<TvDbResponse<Language[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAllAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Language[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]

        // ReSharper disable once InconsistentNaming
        public async void GetAllAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new LanguagesClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<Language[]>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAllAsync(CancellationToken.None));

            Assert.Equal(ErrorMessages.Languages.GetAllAsync[statusCode], ex.Message);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new LanguagesClient(jsonClient);

            const int Id = 42;
            const string Route = "/languages/42";

            var expectedData = new TvDbResponse<Language>();

            jsonClient.GetJsonAsync<TvDbResponse<Language>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Language>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Theory]
        [InlineData(401)]
        [InlineData(404)]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Throws_With_The_Correct_Message(int statusCode)
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new LanguagesClient(jsonClient);

            jsonClient.GetJsonAsync<TvDbResponse<Language>>(null, CancellationToken.None)
                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(42, CancellationToken.None));

            Assert.Equal(ErrorMessages.Languages.GetAsync[statusCode], ex.Message);
        }
    }
}