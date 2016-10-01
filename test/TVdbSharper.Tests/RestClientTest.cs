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
        public async void Authenticate_Makes_The_Right_Request()
        {
            var authenticationRequest = new AuthenticationRequest("ApiKey", "UserKey", "Username");

            var apiTest = new RestApiTest<AuthenticationResponse>(RestTestDependencies.DefaultDependencies)
            {
                TriggerAsync = async client => await client.Authenticate(authenticationRequest, CancellationToken.None),
                ExpectedCallAsync =
                    client => client.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None),
                ReturnValue = new AuthenticationResponse("token_content"),
                ReturnsValueForAnyArgs = new AuthenticationResponse("default_token")
            };

            await apiTest.RunAsync();
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

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader?.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader?.Parameter);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RefreshToken_Makes_The_Right_Request()
        {
            var apiTest = new RestApiTest<AuthenticationResponse>(RestTestDependencies.DefaultDependencies)
            {
                TriggerAsync = async client => await client.RefreshToken(CancellationToken.None),
                ExpectedCallAsync = client => client.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None),
                ReturnValue = new AuthenticationResponse("token_content"),
                ReturnsValueForAnyArgs = new AuthenticationResponse("default_token")
            };

            await apiTest.RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RefreshToken_Updates_JsonClient_AuthorizationHeader()
        {
            var jsonClient = Substitute.For<IHttpJsonClient>();

            var restClient = new RestClient(jsonClient);

            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
                      .Returns(new AuthenticationResponse("token_content"));

            await restClient.RefreshToken(CancellationToken.None);

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader.Parameter);
        }
    }
}