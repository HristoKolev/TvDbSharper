namespace TvDbSharper.Tests
{
    using System;

    using TvDbSharper.Clients;
    using TvDbSharper.Infrastructure;
    using TvDbSharper.Tests.Mocks;

    using Xunit;

    public class TvDbClientTest
    {
        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Should_Add_Header_To_The_HttpClient()
        {
            var apiClient = CreateApiClient();
            var parser = CreateParser();

            var client = CreateClient(apiClient, parser);

            const string Language = "de";

            client.AcceptedLanguage = Language;

            Assert.True(apiClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.ToString() == Language);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Should_Return_DefaultLanguage_If_Non_Is_Set()
        {
            var httpClient = CreateApiClient();
            var parser = CreateParser();

            const string DefaultLanguage = "en";

            var client = CreateClient(httpClient, parser);

            Assert.Equal(DefaultLanguage, client.AcceptedLanguage);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Should_Return_The_Current_AcceptedLanguage()
        {
            var apiClient = CreateApiClient();
            var parser = CreateParser();

            const string Language = "zh";

            apiClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
            apiClient.HttpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd(Language);

            var client = CreateClient(apiClient, parser);

            Assert.Equal(Language, client.AcceptedLanguage);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Throws_When_Passed_Empty_String()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.AcceptedLanguage = string.Empty);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Throws_When_Passed_Null_Value()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentNullException>(() => client.AcceptedLanguage = null);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void AcceptedLanguage_Throws_When_Passed_White_Space()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.AcceptedLanguage = " \t ");
        }

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
        public void BaseUrl_Sets_HttpClient_BaseAddress_To_The_Value()
        {
            var apiClient = CreateApiClient();
            var parser = CreateParser();

            var client = CreateClient(apiClient, parser);

            const string Value = "http://example.com";

            client.BaseUrl = Value;

            Assert.Equal(Value, apiClient.HttpClient.BaseAddress.ToString().TrimEnd('/'));
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Should_Return_The_Same_Value_That_Is_Passed_In()
        {
            var client = CreateClient();

            const string Value = "http://example.com";

            client.BaseUrl = Value;

            Assert.Equal(Value, client.BaseUrl);
        }
        
        [Fact]
        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Should_Not_Be_Ovveriden_If_Present_In_The_HttpClient()
        {
            var apiClient = CreateApiClient();
            var parser = CreateParser();

            const string Value = "http://example.com";
            
            apiClient.HttpClient.BaseAddress = new Uri(Value);
            
            var client = CreateClient(apiClient, parser);

            Assert.Equal(Value, client.BaseUrl);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_Empty_String()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.BaseUrl = string.Empty);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_Null_Value()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentNullException>(() => client.BaseUrl = null);
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void BaseUrl_Throws_When_Passed_White_Space()
        {
            var client = CreateClient();

            Assert.Throws<ArgumentException>(() => client.BaseUrl = " \t ");
        }

        [Fact]

        // ReSharper disable once InconsistentNaming
        public void Constructor_If_HttpClient_BaseUrl_Is_Null_Should_Set_To_Default()
        {
            var apiClient = CreateApiClient();
            var parser = CreateParser();

            var client = CreateClient(apiClient, parser);

            Assert.Equal("https://api.thetvdb.com", apiClient.HttpClient.BaseAddress.ToString().TrimEnd('/'));
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

        private static ITvDbClient CreateClient(IApiClient httpClient, IParser parser)
        {
            return new TvDbClient(httpClient, parser);
        }

        private static ITvDbClient CreateClient()
        {
            return new TvDbClient();
        }

        private static ApiClientMock CreateApiClient()
        {
            return new ApiClientMock();
        }

        private static ParserMock CreateParser()
        {
            return new ParserMock();
        }
    }
}