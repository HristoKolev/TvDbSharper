namespace TvDbSharper.Tests
{
    using NSubstitute;

    using TvDbSharper.Clients.Authentication;
    using TvDbSharper.Clients.Episodes;
    using TvDbSharper.Clients.Languages;
    using TvDbSharper.Clients.Search;
    using TvDbSharper.Clients.Series;
    using TvDbSharper.Clients.Updates;
    using TvDbSharper.Clients.Users;
    using TvDbSharper.Errors;
    using TvDbSharper.JsonClient;

    using Xunit;

    public class TvDbClientTest
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

        private static TvDbClient CreateClient()
        {
            return new TvDbClient(Substitute.For<IJsonClient>(), new ErrorMessages());
        }
    }
}