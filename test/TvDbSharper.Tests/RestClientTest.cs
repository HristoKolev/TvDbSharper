namespace TvDbSharper.Tests
{
    using System;
    using System.Threading;

    using NSubstitute;

    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient;
    using TvDbSharper.RestClient.JsonSchemas;
    using TvDbSharper.RestClient.Models;

    using Xunit;

    public class RestClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const string Route = "/login";

            var authenticationRequest = new AuthenticationRequest("ApiKey", "UserKey", "Username");

            var response = new AuthenticationResponse("token_content");

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
            var restClient = new RestClient(Substitute.For<IJsonClient>());

            await Assert.ThrowsAsync<ArgumentNullException>(() => restClient.AuthenticateAsync(null, CancellationToken.None));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void Authenticate_Updates_JsonClient_AuthorizationHeader()
        {
            var jsonClient = Substitute.For<IJsonClient>();
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
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42";

            var expectedData = new TvDbResponse<SeriesModel>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await restClient.GetSeriesAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesActors_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/actors";

            var expectedData = new TvDbResponse<ActorModel[]>();

            jsonClient.GetJsonAsync<TvDbResponse<ActorModel[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await restClient.GetSeriesActorsAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<ActorModel[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesEpisodes_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const int Page = 2;
            const string Route = "/series/42/episodes?page=2";

            var expectedData = new TvDbResponse<EpisodeModel[]>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await restClient.GetSeriesEpisodesAsync(Id, Page, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesFilter_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/filter?keys=added,id";
            const SeriesFilter Filter = SeriesFilter.Id | SeriesFilter.Added;

            var expectedData = new TvDbResponse<SeriesModel>();

            jsonClient.GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await restClient.GetSeriesFilterAsync(Id, Filter, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<SeriesModel>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void GetSeriesImages_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const string Route = "/series/42/images";

            var expectedData = new TvDbResponse<ImagesSummary>();

            jsonClient.GetJsonAsync<TvDbResponse<ImagesSummary>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await restClient.GetSeriesImagesAsync(Id, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<ImagesSummary>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void RefreshToken_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const string Route = "/refresh_token";

            var response = new AuthenticationResponse("token_content");

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
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            jsonClient.GetJsonAsync<AuthenticationResponse>("/refresh_token", CancellationToken.None)
                      .Returns(new AuthenticationResponse("token_content"));

            await restClient.RefreshTokenAsync(CancellationToken.None);

            Assert.Equal("Bearer", jsonClient.AuthorizationHeader.Scheme);
            Assert.Equal("token_content", jsonClient.AuthorizationHeader.Parameter);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public async void SearchSeriesEpisodes_Makes_The_Right_Request()
        {
            var jsonClient = Substitute.For<IJsonClient>();
            var restClient = new RestClient(jsonClient);

            const int Id = 42;
            const int Page = 2;
            const string Route = "/series/42/episodes/query?page=2&airedSeason=1&imdbId=tt0118480";

            var query = new EpisodeQuery
            {
                ImdbId = "tt0118480",
                AiredSeason = 1
            };

            var expectedData = new TvDbResponse<EpisodeModel[]>();

            jsonClient.GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None).Returns(expectedData);

            var responseData = await restClient.SearchSeriesEpisodesAsync(Id, query, Page, CancellationToken.None);

            await jsonClient.Received().GetJsonAsync<TvDbResponse<EpisodeModel[]>>(Route, CancellationToken.None);

            Assert.Equal(expectedData, responseData);
        }
    }
}