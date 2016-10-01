namespace TvDbSharper.Tests
{
    using System;
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.JsonSchemas;

    using Xunit;

    public class RestClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Sends_The_Right_Json()
        {
            var jsonClient = Substitute.For<IHttpJsonClient>();
            var restClient = new RestClient(jsonClient);

            var authenticationRequest = new AuthenticationRequest("ApiKey", "UserKey", "Username");

            jsonClient.PostJsonAsync<AuthenticationResponse>(null, null, CancellationToken.None)
                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

            jsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None)
                      .Returns(new AuthenticationResponse("token_content"));

            await restClient.Authenticate(authenticationRequest, CancellationToken.None);

            await jsonClient.Received().PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Throws_When_authenticationData_Is_null()
        {
            var restClient = new RestClient(Substitute.For<IHttpJsonClient>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => restClient.Authenticate(null, CancellationToken.None));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Updates_JsonClient_AuthorizationHeader()
        {
            var jsonClient = Substitute.For<IHttpJsonClient>();

            var restClient = new RestClient(jsonClient);

            var authenticationRequest = new AuthenticationRequest("ApiKey", "UserKey", "Username");

            jsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None)
                      .Returns(new AuthenticationResponse("token_content"));

            await restClient.Authenticate(authenticationRequest, CancellationToken.None);

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader.Parameter);
        }
    }
}