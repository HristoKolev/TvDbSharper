namespace TvDbSharper.Tests
{
    using System;
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.Authentication;
    using TvDbSharper.Authentication.Json;
    using TvDbSharper.JsonClient;

    using Xunit;

    public class AuthenticationClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new AuthenticationClient(jsonClient);

            const string Route = "/login";

            var authenticationRequest = new AuthenticationRequest("ApiKey", "UserKey", "Username");

            var response = new AuthenticationResponse("token_content");

            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None)
                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None).Returns(response);

            await client.AuthenticateAsync(authenticationRequest, CancellationToken.None);

            await jsonClient.Received().PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Throws_When_authenticationData_Is_null()
        {
            var client = new AuthenticationClient(Substitute.For<IJsonClient>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => client.AuthenticateAsync(null, CancellationToken.None));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Updates_JsonClient_AuthorizationHeader()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new AuthenticationClient(jsonClient);

            var authenticationRequest = new AuthenticationRequest("ApiKey", "UserKey", "Username");

            jsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None)
                      .Returns(new AuthenticationResponse("token_content"));

            await client.AuthenticateAsync(authenticationRequest, CancellationToken.None);

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader?.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader?.Parameter);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RefreshToken_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new AuthenticationClient(jsonClient);

            const string Route = "/refresh_token";

            var response = new AuthenticationResponse("token_content");

            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None)
                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None).Returns(response);

            await client.RefreshTokenAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RefreshToken_Updates_JsonClient_AuthorizationHeader()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var client = new AuthenticationClient(jsonClient);

            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
                      .Returns(new AuthenticationResponse("token_content"));

            await client.RefreshTokenAsync(CancellationToken.None);

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader.Parameter);
        }
    }
}