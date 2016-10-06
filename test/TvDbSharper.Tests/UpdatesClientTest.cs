namespace TvDbSharper.Tests
{
    using System;
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.Api.Updates;
    using TvDbSharper.Api.Updates.Json;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient.Json;

    using Xunit;

    public class UpdatesClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsync_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UpdatesClient(jsonClient);

            const string Route = "/updated/query?fromTime=1475280000";
            DateTime from = new DateTime(2016, 10, 1);

            var expectedData = new TvDbResponse<Update[]>();

            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(from, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetAsyncWithInterval_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new UpdatesClient(jsonClient);

            const string Route = "/updated/query?fromTime=1475280000&toTime=1475625600";
            DateTime from = new DateTime(2016, 10, 1);
            DateTime to = new DateTime(2016, 10, 5);

            var expectedData = new TvDbResponse<Update[]>();

            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await client.GetAsync(from, to, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}