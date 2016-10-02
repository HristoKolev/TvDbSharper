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
            var jsonClient = Substitute.For<IHttpJsonClient>();
            var restClient = new RestClient(jsonClient);

            var authenticationRequest = new AuthenticationRequest("ApiKey", "UserKey", "Username");

            var response = new AuthenticationResponse("token_content");

            const string Route = "/login";

            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None)
                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

            jsonClient.PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None).Returns(response);

            await restClient.AuthenticateAsync(authenticationRequest, CancellationToken.None);

            await jsonClient.Received().PostJsonAsync<AuthenticationResponse>(Route, authenticationRequest, CancellationToken.None);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Throws_When_authenticationData_Is_null()
        {
            var restClient = new RestClient(Substitute.For<IHttpJsonClient>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => restClient.AuthenticateAsync(null, CancellationToken.None));
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

            await restClient.AuthenticateAsync(authenticationRequest, CancellationToken.None);

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader?.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader?.Parameter);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeries_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IHttpJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42";

            var expectedShow = new SeriesResponse();

            jsonClient.GetJsonDataAsync<SeriesResponse>(Route, CancellationToken.None)
                      .Returns(new DataResponse<SeriesResponse>(expectedShow));

            var responseShow = await restClient.GetSeriesAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonDataAsync<SeriesResponse>(Route, CancellationToken.None);

            Assert.Equal(expectedShow, responseShow);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesActors_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IHttpJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/actors";

            var expectedActors = new ActorResponse[0];

            jsonClient.GetJsonDataAsync<ActorResponse[]>(Route, CancellationToken.None)
                      .Returns(new DataResponse<ActorResponse[]>(expectedActors));

            var responseActors = await restClient.GetSeriesActorsAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonDataAsync<ActorResponse[]>(Route, CancellationToken.None);

            Assert.Equal(expectedActors, responseActors);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesEpisodes_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IHttpJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const int Page = 2;
            const string Route = "/series/42/episodes?page=2";

            var expectedEpisodes = new EpisodeResponse[0];

            jsonClient.GetJsonDataAsync<EpisodeResponse[]>(Route, CancellationToken.None)
                      .Returns(new DataResponse<EpisodeResponse[]>(expectedEpisodes));

            var responseEpisodes = await restClient.GetSeriesEpisodesAsync(Id, Page, CancellationToken.None);

            await jsonClient.Received().GetJsonDataAsync<EpisodeResponse[]>(Route, CancellationToken.None);

            Assert.Equal(expectedEpisodes, responseEpisodes);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RefreshToken_Makes_The_Right_Request()
        {
            var response = new AuthenticationResponse("token_content");

            var jsonClient = Substitute.For<IHttpJsonClient>();
            var restClient = new RestClient(jsonClient);

            const string Route = "/refresh_token";

            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None)
                      .ReturnsForAnyArgs(new AuthenticationResponse("default_token"));

            jsonClient.GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None).Returns(response);

            await restClient.RefreshTokenAsync(CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<AuthenticationResponse>(Route, CancellationToken.None);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RefreshToken_Updates_JsonClient_AuthorizationHeader()
        {
            var jsonClient = Substitute.For<IHttpJsonClient>();
            var restClient = new RestClient(jsonClient);

            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
                      .Returns(new AuthenticationResponse("token_content"));

            await restClient.RefreshTokenAsync(CancellationToken.None);

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader.Parameter);
        }
    }
}