//namespace TvDbSharper.Tests
//{
//    using System;
//    using System.Linq.Expressions;
//    using System.Net;
//    using System.Threading;

//    using NSubstitute;
//    using NSubstitute.ExceptionExtensions;

//    using TvDbSharper.Clients.Authentication;
//    using TvDbSharper.Clients.Authentication.Json;
//    using TvDbSharper.Errors;
//    using TvDbSharper.JsonClient;

//    using Xunit;

//    public class AuthenticationClientTest
//    {
//        public AuthenticationClientTest()
//        {
//            this.ErrorMessages = new ErrorMessages();
//        }

//        private IErrorMessages ErrorMessages { get; }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/login";

//            var authenticationRequest = new AuthenticationData("ApiKey", "Username", "UserKey");

//            var response = new AuthenticationResponse("token_content");

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None)
//                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None).Returns(response);

//            await client.AuthenticateAsync(authenticationRequest, CancellationToken.None);

//            await jsonClient.Received().PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Throws_When_authenticationData_Is_null()
//        {
//            var client = this.CreateClient();

//            await Assert.ThrowsAsync<ArgumentNullException>(() => client.AuthenticateAsync((AuthenticationData)null, CancellationToken.None));
//        }

//        [Theory]
//        [InlineData(401)]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            var authenticationRequest = new AuthenticationData("ApiKey", "UserKey", "Username");

//            jsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None)
//                      .Throws(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            var ex =
//                await Assert.ThrowsAsync<TvDbServerException>(() => client.AuthenticateAsync(authenticationRequest, CancellationToken.None));

//            Assert.Equal(this.ErrorMessages.Authentication.AuthenticateAsync[statusCode], ex.Message);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Updates_JsonClient_AuthorizationHeader()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            var authenticationRequest = new AuthenticationData("ApiKey", "UserKey", "Username");

//            jsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None)
//                      .Returns(new AuthenticationResponse("token_content"));

//            await client.AuthenticateAsync(authenticationRequest, CancellationToken.None);

//            Assert.Equal("Bearer", jsonClient.AuthorizationHeader?.Scheme);
//            Assert.Equal("token_content", jsonClient.AuthorizationHeader?.Parameter);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/login";

//            const string ApiKey = "ApiKey";
//            const string Username = "Username";
//            const string UserKey = "UserKey";

//            var response = new AuthenticationResponse("token_content");
//            var defaultResponse = new AuthenticationResponse("default_token_content");

//            Expression<Predicate<AuthenticationData>> requestCheck =
//                request => (request.ApiKey == ApiKey) && (request.Username == Username) && (request.UserKey == UserKey);

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, Arg.Is(requestCheck), CancellationToken.None)
//                      .ReturnsForAnyArgs(defaultResponse);

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, Arg.Is(requestCheck), CancellationToken.None).Returns(response);

//            await client.AuthenticateAsync(ApiKey, Username, UserKey, CancellationToken.None);

//            await jsonClient.Received().PostJsonAsync<AuthenticationResponse>(Route, Arg.Is(requestCheck), CancellationToken.None);
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData(" ")]
//        [InlineData("  ")]
//        [InlineData("\t")]
//        [InlineData("\r")]
//        [InlineData("\n")]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Throws_When_Passed_Empty_ApiKey(string value)
//        {
//            var client = this.CreateClient();

//            const string Username = "Username";
//            const string UserKey = "UserKey";

//            await
//                Assert.ThrowsAsync<ArgumentException>(
//                    async () => await client.AuthenticateAsync(value, Username, UserKey, CancellationToken.None));
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData(" ")]
//        [InlineData("  ")]
//        [InlineData("\t")]
//        [InlineData("\r")]
//        [InlineData("\n")]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Throws_When_Passed_Empty_UserKey(string value)
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string Username = "Username";

//            await
//                Assert.ThrowsAsync<ArgumentException>(
//                    async () => await client.AuthenticateAsync(ApiKey, Username, value, CancellationToken.None));
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData(" ")]
//        [InlineData("  ")]
//        [InlineData("\t")]
//        [InlineData("\r")]
//        [InlineData("\n")]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Throws_When_Passed_Empty_Username(string value)
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string UserKey = "UserKey";

//            await
//                Assert.ThrowsAsync<ArgumentException>(
//                    async () => await client.AuthenticateAsync(ApiKey, value, UserKey, CancellationToken.None));
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Throws_When_Passed_Null_ApiKey()
//        {
//            var client = this.CreateClient();

//            const string Username = "Username";
//            const string UserKey = "UserKey";

//            await
//                Assert.ThrowsAsync<ArgumentNullException>(
//                    async () => await client.AuthenticateAsync(null, Username, UserKey, CancellationToken.None));
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Throws_When_Passed_Null_UserKey()
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string Username = "Username";

//            await
//                Assert.ThrowsAsync<ArgumentNullException>(
//                    async () => await client.AuthenticateAsync(ApiKey, Username, null, CancellationToken.None));
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Throws_When_Passed_Null_Username()
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string UserKey = "UserKey";

//            await
//                Assert.ThrowsAsync<ArgumentNullException>(
//                    async () => await client.AuthenticateAsync(ApiKey, null, UserKey, CancellationToken.None));
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData(" ")]
//        [InlineData("  ")]
//        [InlineData("\t")]
//        [InlineData("\r")]
//        [InlineData("\n")]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Without_CancellationToken_Throws_When_Passed_Empty_ApiKey(string value)
//        {
//            var client = this.CreateClient();

//            const string Username = "Username";
//            const string UserKey = "UserKey";

//            await Assert.ThrowsAsync<ArgumentException>(async () => await client.AuthenticateAsync(value, Username, UserKey));
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData(" ")]
//        [InlineData("  ")]
//        [InlineData("\t")]
//        [InlineData("\r")]
//        [InlineData("\n")]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Without_CancellationToken_Throws_When_Passed_Empty_UserKey(string value)
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string Username = "Username";

//            await Assert.ThrowsAsync<ArgumentException>(async () => await client.AuthenticateAsync(ApiKey, Username, value));
//        }

//        [Theory]
//        [InlineData("")]
//        [InlineData(" ")]
//        [InlineData("  ")]
//        [InlineData("\t")]
//        [InlineData("\r")]
//        [InlineData("\n")]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Without_CancellationToken_Throws_When_Passed_Empty_Username(string value)
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string UserKey = "UserKey";

//            await Assert.ThrowsAsync<ArgumentException>(async () => await client.AuthenticateAsync(ApiKey, value, UserKey));
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Without_CancellationToken_Throws_When_Passed_Null_ApiKey()
//        {
//            var client = this.CreateClient();

//            const string Username = "Username";
//            const string UserKey = "UserKey";

//            await Assert.ThrowsAsync<ArgumentNullException>(async () => await client.AuthenticateAsync(null, Username, UserKey));
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Without_CancellationToken_Throws_When_Passed_Null_UserKey()
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string Username = "Username";

//            await Assert.ThrowsAsync<ArgumentNullException>(async () => await client.AuthenticateAsync(ApiKey, Username, null));
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_With_Inline_Login_Data_Without_CancellationToken_Throws_When_Passed_Null_Username()
//        {
//            var client = this.CreateClient();

//            const string ApiKey = "ApiKey";
//            const string UserKey = "UserKey";

//            await Assert.ThrowsAsync<ArgumentNullException>(async () => await client.AuthenticateAsync(ApiKey, null, UserKey));
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Without_CancellationToken_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/login";

//            var authenticationRequest = new AuthenticationData("ApiKey", "Username", "UserKey");

//            var response = new AuthenticationResponse("token_content");

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None)
//                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None).Returns(response);

//            await client.AuthenticateAsync(authenticationRequest);

//            await jsonClient.Received().PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Without_CancellationToken_Throws_When_authenticationData_Is_null()
//        {
//            var client = this.CreateClient();

//            await Assert.ThrowsAsync<ArgumentNullException>(() => client.AuthenticateAsync((AuthenticationData)null));
//        }

//        [Theory]
//        [InlineData(401)]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Without_CancellationToken_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            var authenticationRequest = new AuthenticationData("ApiKey", "UserKey", "Username");

//            jsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None)
//                      .Throws(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            var ex = await Assert.ThrowsAsync<TvDbServerException>(() => client.AuthenticateAsync(authenticationRequest));

//            Assert.Equal(this.ErrorMessages.Authentication.AuthenticateAsync[statusCode], ex.Message);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Without_CancellationToken_Updates_JsonClient_AuthorizationHeader()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            var authenticationRequest = new AuthenticationData("ApiKey", "UserKey", "Username");

//            jsonClient.PostJsonAsync<AuthenticationResponse>("/login", authenticationRequest, CancellationToken.None)
//                      .Returns(new AuthenticationResponse("token_content"));

//            await client.AuthenticateAsync(authenticationRequest);

//            Assert.Equal("Bearer", jsonClient.AuthorizationHeader?.Scheme);
//            Assert.Equal("token_content", jsonClient.AuthorizationHeader?.Parameter);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void AuthenticateAsync_Without_CancellationToken_With_Inline_Login_Data_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/login";

//            const string ApiKey = "ApiKey";
//            const string Username = "Username";
//            const string UserKey = "UserKey";

//            var response = new AuthenticationResponse("token_content");
//            var defaultResponse = new AuthenticationResponse("default_token_content");

//            Expression<Predicate<AuthenticationData>> requestCheck =
//                request => (request.ApiKey == ApiKey) && (request.Username == Username) && (request.UserKey == UserKey);

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, Arg.Is(requestCheck), CancellationToken.None)
//                      .ReturnsForAnyArgs(defaultResponse);

//            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, Arg.Is(requestCheck), CancellationToken.None).Returns(response);

//            await client.AuthenticateAsync(ApiKey, Username, UserKey);

//            await jsonClient.Received().PostJsonAsync<AuthenticationResponse>(Route, Arg.Is(requestCheck), CancellationToken.None);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void RefreshTokenAsync_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/refresh_token";

//            var response = new AuthenticationResponse("token_content");

//            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None)
//                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

//            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None).Returns(response);

//            await client.RefreshTokenAsync(CancellationToken.None);

//            await jsonClient.Received().GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None);
//        }

//        [Theory]
//        [InlineData(401)]

//        // ReSharper disable once InconsistentNaming
//        public async void RefreshTokenAsync_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
//                      .Throws(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            var ex = await Assert.ThrowsAsync<TvDbServerException>(() => client.RefreshTokenAsync(CancellationToken.None));

//            Assert.Equal(this.ErrorMessages.Authentication.RefreshTokenAsync[statusCode], ex.Message);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void RefreshTokenAsync_Updates_JsonClient_AuthorizationHeader()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
//                      .Returns(new AuthenticationResponse("token_content"));

//            await client.RefreshTokenAsync(CancellationToken.None);

//            Assert.Equal("Bearer", jsonClient.AuthorizationHeader.Scheme);
//            Assert.Equal("token_content", jsonClient.AuthorizationHeader.Parameter);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void RefreshTokenAsync_Without_CancellationToken_Makes_The_Right_Request()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            const string Route = "/refresh_token";

//            var response = new AuthenticationResponse("token_content");

//            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None)
//                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

//            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None).Returns(response);

//            await client.RefreshTokenAsync();

//            await jsonClient.Received().GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None);
//        }

//        [Theory]
//        [InlineData(401)]

//        // ReSharper disable once InconsistentNaming
//        public async void RefreshTokenAsync_Without_CancellationToken_Throws_With_The_Correct_Message(int statusCode)
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
//                      .Throws(info => new TvDbServerException(null, (HttpStatusCode)statusCode, null));

//            var ex = await Assert.ThrowsAsync<TvDbServerException>(() => client.RefreshTokenAsync());

//            Assert.Equal(this.ErrorMessages.Authentication.RefreshTokenAsync[statusCode], ex.Message);
//        }

//        [Fact]

//        // ReSharper disable once InconsistentNaming
//        public async void RefreshTokenAsync_Without_CancellationToken_Updates_JsonClient_AuthorizationHeader()
//        {
//            var jsonClient = CreateJsonClient();
//            var client = this.CreateClient(jsonClient);

//            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
//                      .Returns(new AuthenticationResponse("token_content"));

//            await client.RefreshTokenAsync();

//            Assert.Equal("Bearer", jsonClient.AuthorizationHeader.Scheme);
//            Assert.Equal("token_content", jsonClient.AuthorizationHeader.Parameter);
//        }

//        private static IJsonClient CreateJsonClient()
//        {
//            return Substitute.For<IJsonClient>();
//        }

//        private IAuthenticationClient CreateClient()
//        {
//            return this.CreateClient(Substitute.For<IJsonClient>());
//        }

//        private IAuthenticationClient CreateClient(IJsonClient jsonClient)
//        {
//            return new AuthenticationClient(jsonClient, this.ErrorMessages);
//        }
//    }
//}