namespace TvDbSharper.Tests
{
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.Api.Languages;
    using TvDbSharper.Api.Languages.Json;
    using TvDbSharper.JsonClient;
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

            var expectedData = new TvDbResponse<LanguageData[]>();

            jsonClient.GetJsonAsync<TvDbResponse<LanguageData[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAllAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<LanguageData[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new LanguagesClient(jsonClient);

            const int Id = 42;
            const string Route = "/languages/42";

            var expectedData = new TvDbResponse<LanguageData>();

            jsonClient.GetJsonAsync<TvDbResponse<LanguageData>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<LanguageData>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}