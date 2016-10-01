namespace TVdbSharper.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    using NSubstitute;

    using Xunit;

    public class RestClientTest
    {
        // {
        // [Fact]

        // // ReSharper disable once InconsistentNaming
        // public async void Authenticate_Sends_The_Right_Content()
        // {
        // AuthenticationRequest authenticationData = new AuthenticationRequest
        // {
        // ApiKey = "ApiKey",
        // UserKey = "UserKey",
        // Username = "Username"
        // };

        // var jsonClient = Substitute.For<IHttpJsonClient>();

        // var restClient = new RestClient(jsonClient);

        // jsonClient.PostAsync("/login", Arg.Any<StringContent>()).Returns(this.StringResponse("{\"token\": \"token_content\"}"));

        // await restClient.Authenticate(authenticationData);

        // string dataJson = JsonConvert.SerializeObject(authenticationData);

        // await
        // jsonClient.Received().PostAsync("/login", Arg.Is<StringContent>(content => content.ReadAsStringAsync().Result == dataJson));
        // }
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Throws_When_authenticationData_Is_null()
        {
            var restClient = new RestClient(Substitute.For<IHttpJsonClient>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => restClient.Authenticate(null, CancellationToken.None));
        }

        private HttpResponseMessage StringResponse(string content)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            if (content != null)
            {
                response.Content = new StringContent(content);
            }

            return response;
        }
    }
}