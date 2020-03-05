using System.Net.Http.Headers;

namespace TvDbSharper.Tests
{
    using System;
    using System.Threading.Tasks;

    using TvDbSharper.Clients;
    using TvDbSharper.Dto;
    using TvDbSharper.Infrastructure;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class AuthenticationClientTest
    {
        private const string ContentTypeHeaderName = "Content-Type";

        #region AuthenticateAsync tests

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_Makes_The_Right_Request()
        {
            var authenticationRequest = new AuthenticationData("test1", "test2", "test3");

            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync(authenticationRequest, token))
                .ShouldRequest("POST", "/login", "{\"ApiKey\":\"test1\",\"UserKey\":\"test3\",\"Username\":\"test2\"}")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_Updates_The_Auth_Token()
        {
            var authenticationRequest = new AuthenticationData("test1", "test2", "test3");

            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync(authenticationRequest, token))
                .AssertThat((client, parser) => Assert.Equal("Bearer auth_token", client.HttpClient.DefaultRequestHeaders.Authorization.ToString()))
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_Without_CT_Makes_The_Right_Request()
        {
            var authenticationRequest = new AuthenticationData("test1", "test2", "test3");

            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync(authenticationRequest))
                .ShouldRequest("POST", "/login", "{\"ApiKey\":\"test1\",\"UserKey\":\"test3\",\"Username\":\"test2\"}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_With_Plain_Values_Makes_The_Right_Request()
        {
            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync("test1", "test2", "test3", token))
                .ShouldRequest("POST", "/login", "{\"ApiKey\":\"test1\",\"UserKey\":\"test3\",\"Username\":\"test2\"}")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_With_Plain_Values__With_No_CT_Makes_The_Right_Request()
        {
            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync("test1", "test2", "test3"))
                .ShouldRequest("POST", "/login", "{\"ApiKey\":\"test1\",\"UserKey\":\"test3\",\"Username\":\"test2\"}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_With_ApiKey_Only_Makes_The_Right_Request()
        {
            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync("test1", token))
                .ShouldRequest("POST", "/login", "{\"ApiKey\":\"test1\"}")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_With_ApiKey_Only__With_No_CT_Makes_The_Right_Request()
        {
            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync("test1"))
                .ShouldRequest("POST", "/login", "{\"ApiKey\":\"test1\"}")
                .WithNoCancellationToken()
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task AuthenticateAsync_Throws_When_Passed_Null_AuthenticationData()
        {
            return AuthenticateAsyncTest()
                .WhenCallingAMethod((client, token) => client.AuthenticateAsync((AuthenticationData)null, token))
                .ShouldThrow<ArgumentNullException>()
                .RunAsync();
        }

        #endregion

        #region RefreshToken tests

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task RefreshTokenAsync_Makes_The_Right_Request()
        { 
            return RefreshTokenAsyncTest()
                .WhenCallingAMethod((client, token) => client.RefreshTokenAsync(token))
                .ShouldRequest("GET", "/refresh_token")
                .RunAsync();
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public Task RefreshTokenAsync_Without_CT_Makes_The_Right_Request()
        {
            return RefreshTokenAsyncTest()
                .WhenCallingAMethod((client, token) => client.RefreshTokenAsync())
                .ShouldRequest("GET", "/refresh_token")
                .WithNoCancellationToken()
                .RunAsync();
        }

        #endregion

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Token_Returns_null_if_not_Authenticated()
        {
            var client = new ApiClientMock();
            var parser = new ParserMock();

            var auth = new AuthenticationClient(client, parser);

            Assert.Null(auth.Token);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("456")]
        [InlineData("789")]

        // ReSharper disable once InconsistentNaming
        public void Token_Passes_The_Token_To_The_API_Client(string token)
        {
            var client = new ApiClientMock();
            var parser = new ParserMock();

            var auth = new AuthenticationClient(client, parser)
            {
                Token = token
            };

            Assert.Equal(token, client.HttpClient.DefaultRequestHeaders.Authorization.Parameter);
            Assert.Equal("Bearer", client.HttpClient.DefaultRequestHeaders.Authorization.Scheme);
        }


        [Theory]
        [InlineData("123")]
        [InlineData("456")]
        [InlineData("789")]

        // ReSharper disable once InconsistentNaming
        public void Token_Gets_The_Token_From_The_API_Client(string token)
        {
            var client = new ApiClientMock();
            client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var parser = new ParserMock();

            var auth = new AuthenticationClient(client, parser);

            Assert.Equal(token, auth.Token);
        }


        private static ApiTest<AuthenticationClient> AuthenticateAsyncTest()
        {
            return new ApiTest<AuthenticationClient>()
                .WithErrorMap(ErrorMessages.Authentication.AuthenticateAsync)
                .WithConstructor((client, parser) => new AuthenticationClient(client, parser))
                .SetApiResponse(new ApiResponse())
                .SetResultObject(new AuthenticationResponse("auth_token"))
                .ShouldIgnoreParserResult();
        }

        private static ApiTest<AuthenticationClient> RefreshTokenAsyncTest()
        {
            return new ApiTest<AuthenticationClient>()
                .WithErrorMap(ErrorMessages.Authentication.RefreshTokenAsync)
                .WithConstructor((client, parser) => new AuthenticationClient(client, parser))
                .SetApiResponse(new ApiResponse())
                .SetResultObject(new AuthenticationResponse("auth_token"))
                .ShouldIgnoreParserResult();
        }
    }
}