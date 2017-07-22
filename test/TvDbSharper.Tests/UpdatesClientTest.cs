//namespace TvDbSharper.Tests
//{
//    using System;
//    using System.Net;
//    using System.Threading;

//    using NSubstitute;
//    using NSubstitute.ExceptionExtensions;

//    using TvDbSharper.BaseSchemas;
//    using TvDbSharper.Clients.Updates;
//    using TvDbSharper.Clients.Updates.Json;
//    using TvDbSharper.Errors;
//    using TvDbSharper.JsonClient;

//    using Xunit;

//    public class UpdatesClientTest
//    {
//        public UpdatesClientTest()
//        {
//            this.ErrorMessages = new ErrorMessages();
//        }

//        private IErrorMessages ErrorMessages { get; }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsync_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/updated/query?fromTime=1475280000";
//            DateTime from = new DateTime(2016, 10, 1);

//            var expectedData = new TvDbResponse<Update[]>();

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None).Returns(expectedData);

//            var responseData = await client.GetAsync(from, CancellationToken.None);

//            await jsonClient.Received().GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None);

//            Assert.Equal(expectedData, responseData);
//        }

//        [Theory]
//        [InlineData(401)]
//        [InlineData(404)]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsync_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(null, CancellationToken.None)
//                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            var fromParam = new DateTime(2016, 10, 1);

//            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(fromParam, CancellationToken.None));

//            Assert.Equal(this.ErrorMessages.Updates.GetAsync[statusCode], ex.Message);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsync_Without_CancellationToken_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/updated/query?fromTime=1475280000";
//            DateTime from = new DateTime(2016, 10, 1);

//            var expectedData = new TvDbResponse<Update[]>();

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None).Returns(expectedData);

//            var responseData = await client.GetAsync(from);

//            await jsonClient.Received().GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None);

//            Assert.Equal(expectedData, responseData);
//        }

//        [Theory]
//        [InlineData(401)]
//        [InlineData(404)]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsync_Without_CancellationToken_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(null, CancellationToken.None)
//                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            var fromParam = new DateTime(2016, 10, 1);

//            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(fromParam));

//            Assert.Equal(this.ErrorMessages.Updates.GetAsync[statusCode], ex.Message);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsyncWithInterval_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/updated/query?fromTime=1475280000&toTime=1475625600";
//            DateTime from = new DateTime(2016, 10, 1);
//            DateTime to = new DateTime(2016, 10, 5);

//            var expectedData = new TvDbResponse<Update[]>();

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None).Returns(expectedData);

//            var responseData = await client.GetAsync(from, to, CancellationToken.None);

//            await jsonClient.Received().GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None);

//            Assert.Equal(expectedData, responseData);
//        }

//        [Theory]
//        [InlineData(401)]
//        [InlineData(404)]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsyncWithInterval_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(null, CancellationToken.None)
//                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            DateTime from = new DateTime(2016, 10, 1);
//            DateTime to = new DateTime(2016, 10, 5);

//            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(from, to, CancellationToken.None));

//            Assert.Equal(this.ErrorMessages.Updates.GetAsync[statusCode], ex.Message);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsyncWithInterval_Without_CancellationToken_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/updated/query?fromTime=1475280000&toTime=1475625600";
//            DateTime from = new DateTime(2016, 10, 1);
//            DateTime to = new DateTime(2016, 10, 5);

//            var expectedData = new TvDbResponse<Update[]>();

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None).Returns(expectedData);

//            var responseData = await client.GetAsync(from, to);

//            await jsonClient.Received().GetJsonAsync<TvDbResponse<Update[]>>(Route, CancellationToken.None);

//            Assert.Equal(expectedData, responseData);
//        }

//        [Theory]
//        [InlineData(401)]
//        [InlineData(404)]

//        // ReSharper disable once InconsistentNaming
//        public async void GetAsyncWithInterval_Without_CancellationToken_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<TvDbResponse<Update[]>>(null, CancellationToken.None)
//                      .ThrowsForAnyArgs(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            DateTime from = new DateTime(2016, 10, 1);
//            DateTime to = new DateTime(2016, 10, 5);

//            var ex = await Assert.ThrowsAsync<TvDbServerException>(async () => await client.GetAsync(from, to));

//            Assert.Equal(this.ErrorMessages.Updates.GetAsync[statusCode], ex.Message);
//        }

//        private static IJsonClient CreateJsonClient()
//        {
//            return Substitute.For<IJsonClient>();
//        }

//        private IUpdatesClient CreateClient(IJsonClient jsonClient)
//        {
//            return new UpdatesClient(jsonClient, this.ErrorMessages);
//        }
//    }
//}