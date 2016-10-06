namespace TvDbSharper.Tests
{
    using NSubstitute;

    using TvDbSharper.Api.Authentication;
    using TvDbSharper.Api.Episodes;
    using TvDbSharper.Api.Languages;
    using TvDbSharper.Api.Search;
    using TvDbSharper.Api.Series;
    using TvDbSharper.Api.Updates;
    using TvDbSharper.Api.Users;
    using TvDbSharper.JsonClient;
    using TvDbSharper.RestClient;

    using Xunit;

    public class RestClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AuthenticationClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Authentication);
            Assert.IsType<AuthenticationClient>(client.Authentication);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void EpisodesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Episodes);
            Assert.IsType<EpisodesClient>(client.Episodes);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void LanguagesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Languages);
            Assert.IsType<LanguagesClient>(client.Languages);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void SearchClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Search);
            Assert.IsType<SearchClient>(client.Search);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void SeriesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Series);
            Assert.IsType<SeriesClient>(client.Series);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void UpdatesClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Updates);
            Assert.IsType<UpdatesClient>(client.Updates);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void UsersClient_Should_Be_Initialized()
        {
            var client = CreateClient();

            Assert.NotNull(client.Users);
            Assert.IsType<UsersClient>(client.Users);
        }

        private static RestClient CreateClient()
        {
            return new RestClient(Substitute.For<IJsonClient>());
        }
    }
}